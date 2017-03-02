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

Public Class RentaEspaciosConsulta
    Inherits System.Web.UI.Page

#Region "Propiedades"

    Private intDivisionArticulosId As Integer
    Private strCategoriaOperativaId As Integer
    Private intCatmanId As Integer
    Private intSocioComercialId As Integer
    Private intEstatusId As Integer
    Private intTipoRentaId As Integer
    Private intTipoExhibicionId As Integer
    Private intTipoEspacioPublicitarioId As Integer
    Private intPlanSalidaId As Integer
    Private intTipoPlanogramaId As Integer
    Private intmCatmanId As String = Nothing
    Private intmProveedorId As String = Nothing
    Private strmSocioComercial As String = Nothing
    Private intmTipoExhibicionId As String = Nothing
    Private intmTipoMuebleId As String = Nothing
    Private intmTipoEspacioPublicitarioId As String = Nothing
    Private intmTipoPlanogramaId As String = Nothing
    Private intmPlanogramaId As String = Nothing
    Private strmNombreExhibicion As String = Nothing
    Private intmPlanSalidaId As String = Nothing
    Private intExhibicionId As String = Nothing
    Public strAllIds As String = String.Empty
    Public allAuxIds As String = String.Empty
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

        intDivisionArticulosId = GetPageParameter("cboDivisionArticulos", 0)
        strCategoriaOperativaId = GetPageParameter("cboCategoriaArticulos", 0)
        intCatmanId = GetPageParameter("cboCatman", 0)
        intSocioComercialId = GetPageParameter("cboSocioComercial", 0)
        intTipoRentaId = GetPageParameter("cboTipoRenta", 0)
        intTipoExhibicionId = GetPageParameter("cboTipoExhibicion", 0)
        intTipoEspacioPublicitarioId = GetPageParameter("cboTipoEspacioPublicitario", 0)
        intPlanSalidaId = GetPageParameter("cboPlanSalida", 0)
        intTipoPlanogramaId = GetPageParameter("cboTipoPlanograma", 0)
        intEstatusId = GetPageParameter("cboEstatus", 0)


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
            Return System.Configuration.ConfigurationSettings.AppSettings("strImagenesExhibiciones")
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

    '====================================================================
    ' Name       : LlenarControlDivision
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDivision
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDivision() As String
        Dim returnedData As Array
        returnedData = Benavides.CC.Data.clstblDivisionArticulos.strBuscar(0, "", "", #1/1/2000#, "", 0, 0, strConnectionString)

        If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then

            Dim idDivision As String
            Dim divisionDescripcion As String
            Dim i As Integer

            For i = 0 To returnedData.Length - 1

                idDivision = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strDivisionArticulosNombreId").ToString()
                divisionDescripcion = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strDivisionArticulosNombre").ToString()

                DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strDivisionArticulosNombre") = idDivision & " " & divisionDescripcion
            Next
        End If

        Return CreateJavascriptComboBoxOptions("cboDivisionArticulos", CStr(intDivisionArticulosId), returnedData, "intDivisionArticulosId", "strDivisionArticulosNombre", 1)
    End Function

    '====================================================================
    ' Name       : LlenarControlCategoria
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategori
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCategoria() As String

        Dim returnedJavascript As String = String.Empty
        Dim returnedData As Array

        If intDivisionArticulosId > 0 Then

            returnedData = Benavides.CC.Data.clstblCategoriaArticulos.strBuscar(intDivisionArticulosId, 0, "", "", #1/1/2000#, "", 0, 0, strConnectionString)

            If Not returnedData Is Nothing AndAlso IsArray(returnedData) AndAlso returnedData.Length > 0 Then


                Dim idCategoria As String
                Dim CategoriaDescripcion As String
                Dim i As Integer

                'Ciclo para agregar el id a la division
                For i = 0 To returnedData.Length - 1

                    idCategoria = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strCategoriaArticulosNombreId").ToString()
                    CategoriaDescripcion = DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strCategoriaArticulosNombre").ToString()

                    DirectCast(returnedData.GetValue(i), System.Collections.SortedList).Item("strCategoriaArticulosNombre") = idCategoria & " " & CategoriaDescripcion
                Next

                returnedJavascript = CreateJavascriptComboBoxOptions("cboCategoriaArticulos", CStr(strCategoriaOperativaId), returnedData, "intCategoriaArticulosId", "strCategoriaArticulosNombre", 1)
            End If
        End If

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlCatman
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategori
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCatman() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboCatman", CStr(intCatmanId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarCatman(strConnectionString), "intCatmanId", "strCatmanDescripcion", 1)

        Return returnedJavascript

    End Function


    '====================================================================
    ' Name       : LlenarControlSocioComercial
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboSocioComercial
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlSocioComercial() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboSocioComercial", CStr(intSocioComercialId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarSocioComercial(strConnectionString), "intSocioComercialId", "strSocioComercialNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlEstatus
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboEstatus
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlEstatus() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboEstatus", CStr(intEstatusId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarEstatusRentaEspacios(strConnectionString), "intEstatusId", "strEstatusDescripcion", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlTipoExhibicion
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategori
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlTipoExhibicion() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboTipoExhibicion", CStr(intTipoExhibicionId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarTipoExhibicion(1, strConnectionString), "intTipoExhibicionId", "strTipoExhibicionNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlTipoRenta
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboTipoRenta
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlTipoRenta() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboTipoRenta", CStr(intTipoRentaId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarTipoRenta(strConnectionString), "intTipoRentaId", "strTipoRentaNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlEspacioPublicitario
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategori
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlEspacioPublicitario() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboTipoEspacioPublicitario", CStr(intTipoEspacioPublicitarioId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarEspacioPublicitario(2, strConnectionString), "intEspacioPublicitarioId", "strEspacioPublicitarioNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlPlanSalida
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategori
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlPlanSalida() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboPlanSalida", CStr(intPlanSalidaId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarPlanSalida(strConnectionString), "intPlanSalidaId", "strPlanSalidaNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : LlenarControlTipoPlanograma
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboTipoPlanograma
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlTipoPlanograma() As String

        Dim returnedJavascript As String = String.Empty

        returnedJavascript = CreateJavascriptComboBoxOptions("cboTipoPlanograma", CStr(intTipoPlanogramaId), Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarTipoPlanograma(strConnectionString), "intTipoPlanogramaId", "strTipoPlanogramaNombre", 1)

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : strFirstDayOfMonth
    ' Description: Regresa el primer dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFirstDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaIni")) Then
                Return New Date(Date.Today.Year, Date.Today.Month, 1).ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaIni")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strLastDayOfMonth
    ' Description: Regresa el ultimo dia del mes actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strLastDayOfMonth() As String
        Get
            If IsNothing(Request.Form("dtmFechaFin")) Then

                Dim dtmFechaFinal As Date

                dtmFechaFinal = New Date(Date.Today.Year, Date.Today.Month, 1)
                dtmFechaFinal = dtmFechaFinal.AddMonths(1)
                dtmFechaFinal = dtmFechaFinal.AddDays(-1)

                Return dtmFechaFinal.ToString("dd/MM/yyyy")
            Else
                Return Request.Form("dtmFechaFin")
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strExhibicionId
    ' Description: Codigo del la exhibicion a Editar
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strExhibicionId() As String
        Get
            If Not IsNothing(Request.QueryString("idExhibicion")) Then
                'Si es parametro de la pantalla anterior
                Return Request.QueryString("idExhibicion")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intDivisionId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDivisionId() As String
        Get
            If Not IsNothing(Request.Form("cboDivisionArticulos")) Then
                Return Request.Form("cboDivisionArticulos")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCategoriaId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCategoriaId() As String
        Get
            If Not IsNothing(Request.Form("cboCategoriaArticulos")) Then
                Return Request.Form("cboCategoriaArticulos")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intCatmanId
    ' Description: Leer la opcion marcada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCatmanIdII() As String
        Get
            If Not IsNothing(Request.Form("cboCatman")) Then
                Return Request.Form("cboCatman")
            Else
                Return "0"
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strSocioComercial
    ' Description: Promocion a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSocioComercial() As String
        Get
            If Not IsNothing(Request.Form("txtSocioComercial")) Then
                Return Request.Form("txtSocioComercial")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description: Promocion a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intProveedorId() As String
        Get
            If Not IsNothing(Request.Form("txtProveedorNombreId")) AndAlso IsNumeric(Request.Form("txtProveedorNombreId")) Then
                Return Request.Form("txtProveedorNombreId")
            Else
                Return String.Empty
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
            If Not IsNothing(Request.Form("txtNombreExhibicion")) Then
                Return Request.Form("txtNombreExhibicion")
            Else
                Return String.Empty
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intPlanogramaId
    ' Description: Promocion a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intPlanogramaId() As String
        Get
            If Not IsNothing(Request.Form("txtPlanograma")) AndAlso IsNumeric(Request.Form("txtPlanograma")) Then
                Return Request.Form("txtPlanograma")
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

#End Region

#Region "Plano"
    '====================================================================
    ' Name       : intPlanogramaCapturadoId
    ' Description: Planograma a Consultar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intPlanogramaCapturadoId() As String
        Get
            If Not IsNothing(Trim(Request.Form("txtPlanogramaId"))) And Not (Trim(Request.Form("txtPlanogramaId")) = String.Empty) Then
                Return Request.Form("txtPlanogramaId")
            Else
                Return "0"
            End If
        End Get
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load 'Me.Load 
        Const strComitasDobles As String = """"

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Exportar
        If Request.QueryString("strCmd") = "Exportar" Then

            Dim objArray As System.Array = Nothing
            objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarExhibicionesAdicionales(intDivisionArticulosId, strCategoriaOperativaId, CInt(intCatmanId), _
                                                                                                      strSocioComercial, intProveedorId, CInt(intTipoRentaId), _
                                                                                                      CInt(intTipoExhibicionId), CInt(intTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                      CInt(intPlanSalidaId), CInt(intTipoPlanogramaId), CInt(intPlanogramaCapturadoId), _
                                                                                                      intEstatusId, dtmFechaInicio, dtmFechaFin, strConnectionString)

            ' Establecemos en la respuesta los parámetros de configuración del archivo
            Response.ContentType = "application/vnd.ms-excel"
            Call Response.AddHeader("Content-Disposition", "attachment; filename=""Exhibiciones Adicionales.xls""")
            Call Response.Write(strTablaConsultaExhibicionesAdicionalesExportar(objArray))
            Call Response.End()

        End If

        'Eliminar Exhibicion
        If Request.QueryString("strCmd") = "cmdEliminar" Then
            Dim intResultado As Integer = 0
            intResultado = Benavides.CC.Data.clsExhibicionesAdicionales.intEliminarExhibicionAdicional(CInt(strExhibicionId), strConnectionString)

            'Codigo para eliminar una sucursal
            If (intResultado = 1) Then
                Call Response.Write("<script language='Javascript'>alert('La exhibicion se elimino con exito');</script>")
            Else
                Call Response.Write("<script language='Javascript'>alert('La exhibicion NO se pudo eliminar');</script>")
            End If

        End If

        'Imprimir Exhibiciones Adicionales
        If Request.QueryString("strCmd") = "cmdImprimir" Then


            Dim strHTML As New StringBuilder
            Dim objDataArrayExhibiciones As Array = Nothing
            Dim strRecordBrowserImpresion As String = ""

            'Resultados a mostrar en pantalla
            objDataArrayExhibiciones = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarExhibicionesAdicionales(intDivisionArticulosId, strCategoriaOperativaId, CInt(intCatmanId), _
                                                                                                      strSocioComercial, intProveedorId, CInt(intTipoRentaId), _
                                                                                                      CInt(intTipoExhibicionId), CInt(intTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                      CInt(intPlanSalidaId), CInt(intTipoPlanogramaId), CInt(intPlanogramaCapturadoId), _
                                                                                                      intEstatusId, dtmFechaInicio, dtmFechaFin, strConnectionString)

            If IsArray(objDataArrayExhibiciones) AndAlso objDataArrayExhibiciones.Length > 0 Then

                'Se envia la informacion a imprimir para darle formato de acuerdo a la tabla seleccionada por el usuario.  
                strRecordBrowserImpresion = clsCommons.strGenerateJavascriptString(strImpresionExhibiciones(objDataArrayExhibiciones))

                'Se ennvia a impresion.
                strHTML.Append("<script language='Javascript'>parent.fnImprimir( " & _
                strComitasDobles & strRecordBrowserImpresion.ToString & strComitasDobles & _
                "); </script>")
                Response.Write(strHTML.ToString)
                Response.End()

            End If
        End If
    End Sub

#Region "Exportar"

    Public Function strTablaConsultaExhibicionesAdicionalesExportar(ByVal objConsultaExhibiciones As Array) As String
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
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo de Renta</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>División</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Categoría</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Planograma</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Precio</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Fecha Ini</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Fecha Fin</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Sucursales</th>")
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

            'Nombre de Exhibición                
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & "</td>")
            'Tipo de Renta       
            strTablaEspaciosHTML.Append("<td id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaExhibiciones(2) & "</td>")
            'División                  
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(3)) & "</td>")
            'Categoría 
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(4)) & "</td>")
            'Planograma
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            'Precio
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(7)).ToString() & "</td>")
            'Fecha Ini
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(8)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(9)) & "</td>")
            'Sucursales
            strTablaEspaciosHTML.Append("<td class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(10)) & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaConsultaExhibicionesAdicionalesExportar = strTablaEspaciosHTML.ToString
    End Function
#End Region

#Region "Imprimir"

    '====================================================================
    ' Name       : strImpresionExhibiciones
    ' Description: Generacion de tabla HTML con formato para imprimir resultados de la consulta.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strImpresionExhibiciones(ByVal objDataArrayExhibiciones As Array) As String

        'Variables
        Dim strImpresionExhibicionesHTML As StringBuilder = New StringBuilder
        Dim strRegistroExhibiciones As String()
        Dim strclase As String = ""
        Dim intRenglonesxPagina As Integer = 58

        'Rutina que solo se ejecuta al contener informacion de la consulta.
        If IsArray(objDataArrayExhibiciones) AndAlso (objDataArrayExhibiciones.Length > 0) Then

            Dim intTotalRenglones As Integer = objDataArrayExhibiciones.Length
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
            For Each strRegistroExhibiciones In objDataArrayExhibiciones

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
                    strImpresionExhibicionesHTML.Append(strImprimeEncabezado(intPagina.ToString, intTotalPaginas.ToString))
                End If

                'Clases para renglones.
                If ((intRenglon Mod 2) = 0) Then
                    strclase = "tdtxtImpresionNormal"
                Else
                    strclase = "tdtxtImpresionBold"
                End If

                strImpresionExhibicionesHTML.Append("<tr>")
                ' Nombre de Exhibición
                strImpresionExhibicionesHTML.Append("<td width='20%' align='left' class='" & strclase & "' nowrap >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(1)).ToString & "</td>")
                ' Tipo de Renta
                strImpresionExhibicionesHTML.Append("<td width='15%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(2)).ToString & "</td>")
                ' División
                strImpresionExhibicionesHTML.Append("<td width='12%' align='left' class='" & strclase & "'>" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(3)) & "</td>")
                ' Categoría
                strImpresionExhibicionesHTML.Append("<td width='13%' align='left' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(4)) & "</td>")
                ' Planograma
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearDescripcion(strRegistroExhibiciones(5)) & "</td>")
                'Precio
                strImpresionExhibicionesHTML.Append("<td width='10%' align='right' class='" & strclase & "' >" & "$" & CDec(strRegistroExhibiciones(7)).ToString() & "</td>")
                'Fecha Ini
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroExhibiciones(8)) & "</td>")
                'Fecha Fin
                strImpresionExhibicionesHTML.Append("<td width='10%' align='center' class='" & strclase & "' >" & clsCommons.strFormatearFechaPresentacion(strRegistroExhibiciones(9)) & "</td>")
                strImpresionExhibicionesHTML.Append("</tr>")

                If intContadorRenglon = intTotalRenglones Or intRenglon = intRenglonesxPagina Then
                    strImpresionExhibicionesHTML.Append("</table>")
                    intRenglon = 0
                End If

            Next

        End If

        Return strImpresionExhibicionesHTML.ToString()

    End Function

    Private Function strImprimeEncabezado(ByVal strHojaActual As String, ByVal strHojaFinal As String) As String

        Dim strHtmlEncabezado As StringBuilder
        strHtmlEncabezado = New StringBuilder

        'Encabezado principal
        strHtmlEncabezado.Append("<tr>")
        strHtmlEncabezado.Append("<td colspan='8'>")
        strHtmlEncabezado.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

        'Titulo Reporte
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' align='center' colspan='8' class='tdtxtBold'>Exhibiciones Adicionales</th>")
        strHtmlEncabezado.Append("</tr>")

        ' Fecha de Hoy /  Sucursal  / Hoja
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='10%' align='left'   class='tdtxtBold'>" & Date.Now.Day.ToString & "/" & Date.Now.Month.ToString & "/" & Date.Now.Year.ToString & "</th>")
        strHtmlEncabezado.Append("<th width='50%' align='center' class='tdtxtBold' nowrap> ADS Central </th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='10%' align='center' class='tdtxtBold' nowrap></th>")
        strHtmlEncabezado.Append("<th width='20%' align='left'  class='tdtxtBold'>HOJA " & strHojaActual & " / " & strHojaFinal & " </th>")
        strHtmlEncabezado.Append("</tr>")
        strHtmlEncabezado.Append("</table>")

        strHtmlEncabezado.Append("</td>")
        strHtmlEncabezado.Append("</tr>")

        'Encabezado titulos
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='20%' class='tdtxtBold' align='center' nowrap>Nombre de Exhibición</th>")
        strHtmlEncabezado.Append("<th width='15%' class='tdtxtBold' align='center' nowrap>Tipo Renta</th>")
        strHtmlEncabezado.Append("<th width='12%' class='tdtxtBold' align='center' nowrap>División</th>")
        strHtmlEncabezado.Append("<th width='13%' class='tdtxtBold' align='center' nowrap>Categoría</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Planograma</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Precio</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha Ini</th>")
        strHtmlEncabezado.Append("<th width='10%' class='tdtxtBold' align='center' nowrap>Fecha Fin</th>")
        strHtmlEncabezado.Append("</tr>")

        'Raya Sola
        strHtmlEncabezado.Append("<tr class='trtxtBold'>")
        strHtmlEncabezado.Append("<th width='100%' class='rayita' colspan='8'>" & "&nbsp;" & "</th>")
        strHtmlEncabezado.Append("</tr>")

        strImprimeEncabezado = strHtmlEncabezado.ToString

    End Function

#End Region

#Region "Consulta"
    Public Function strTablaConsultaExhibiciones() As String
        Dim objArray As System.Array = Nothing

        'Paginacion
        If (Request.QueryString("strCmd") = "cmdConsultar") Or (Request.QueryString("strCmd") = "cmdEliminar") Then

            If (Request.QueryString("pager") = "true") Then
                If Not Cache("cacheExhibiciones") Is Nothing Then
                    objArray = CType(Cache("cacheExhibiciones"), System.Array)
                End If
            End If

            If objArray Is Nothing Then
                Cache.Remove("cacheExhibiciones")
                objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarExhibicionesAdicionales(intDivisionArticulosId, strCategoriaOperativaId, CInt(intCatmanId), _
                                                                                                      strSocioComercial, intProveedorId, CInt(intTipoRentaId), _
                                                                                                      CInt(intTipoExhibicionId), CInt(intTipoEspacioPublicitarioId), strNombreExhibicion, _
                                                                                                      CInt(intPlanSalidaId), CInt(intTipoPlanogramaId), CInt(intPlanogramaCapturadoId), _
                                                                                                      intEstatusId, dtmFechaInicio, dtmFechaFin, strConnectionString)
            End If

            Dim strResult As New StringBuilder()
            If Not objArray Is Nothing AndAlso IsArray(objArray) AndAlso objArray.Length > 0 Then
                Cache.Add("cacheExhibiciones", objArray, Nothing, Date.Today.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, Nothing)

                strResult.Append(strTablaConsultaExhibicionesAdicionalesHTML(objArray))
            Else
                strResult.Append(String.Empty)
                strResult.Append("<script language=""javascript"" type=""text/javascript"">")
                strResult.Append("</script>")
                Call Response.Write("<script language='Javascript'>alert('Busqueda sin resultados');</script>")

            End If

            strResult.Append("<script language=""javascript"" type=""text/javascript"">")
            strResult.Append("parent.document.getElementById('tblResultados').innerHTML = document.getElementById('divConsultaExhibiciones').innerHTML;")
            strResult.Append("</script>")

            Return strResult.ToString()
        End If

        Return String.Empty
    End Function

    Public Function strTablaConsultaExhibicionesAdicionalesHTML(ByVal objConsultaExhibiciones As Array) As String
        Dim strTablaEspaciosHTML As StringBuilder
        Dim strConsultaExhibiciones As String() = Nothing
        Dim strColorRegistro As String
        Dim intContador As Integer

        Dim imgAsignar As String = Nothing
        Dim imgEditar As String = Nothing
        Dim imgEliminar As String = Nothing
        Dim imgDetalle As String = Nothing

        Dim Imagen As String = Nothing

        Dim intPage As Integer
        Dim intTotal As Integer = 10
        If Trim(Request.QueryString("p")) = String.Empty Then
            intPage = 1
        Else
            intPage = CInt(Request.QueryString("p"))
        End If

        strTablaEspaciosHTML = New StringBuilder
        strTablaEspaciosHTML.Append(Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objConsultaExhibiciones.Length, intPage, intTotal, String.Empty, Nothing))

        strTablaEspaciosHTML.Append("<table border='0' cellpadding='0' cellspacing='0' style='width:100%;'>")
        strTablaEspaciosHTML.Append("<tr class='trtitulos'>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Nombre de Exhibición</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Tipo de Renta</th>")
        strTablaEspaciosHTML.Append("<th width='12%' align=center class='rayita' align='left' valign='top'>División</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Categoría</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>No. Plano</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Precio</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Fecha <br> Inicio</th>")
        strTablaEspaciosHTML.Append("<th width='8%' align=center class='rayita' align='left' valign='top'>Fecha <br> Fin</th>")
        strTablaEspaciosHTML.Append("<th width='4%' align=center class='rayita' align='left' valign='top'>Sucs</th>")
        strTablaEspaciosHTML.Append("<th width='10%' align=center class='rayita' align='left' valign='top'>Acción</th>")
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

            'Imagenes de la accion Formato 1x1
            imgAsignar = "<img id=Asi" & strConsultaExhibiciones(0) & " height='17' src='../static/images/imgNRAsignar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id)' alt='Asignar'>"
            imgEditar = "<img id=Edi" & strConsultaExhibiciones(0) & " height='17' src='../static/images/icono_editar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id)' alt='Editar'>"
            imgEliminar = "<img id=Eli" & strConsultaExhibiciones(0) & " height='17' src='../static/images/imgNREliminar.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id)' alt='Eliminar'>"
            imgDetalle = "<img id=Ver" & strConsultaExhibiciones(0) & " height='17' src='../static/images/icono_lupa.gif' width='17' align='absMiddle' border='0' style='cursor:pointer;margin:2px;' onClick='javascript:cmdVerificarAccion_onclick(this.id)' alt='Ver Detalle'>"

            strTablaEspaciosHTML.Append("<tr>")

            'Nombre de Exhibición       
            strTablaEspaciosHTML.Append("<td width='10%' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(1)) & "</td>")
            'Tipo de Renta       
            strTablaEspaciosHTML.Append("<td width='10%' id=tdCodigo" & intContador.ToString() & " class=" & strColorRegistro & ">" & strConsultaExhibiciones(2) & "</td>")
            'División                  
            strTablaEspaciosHTML.Append("<td width='12%' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(3)) & "</td>")
            'Categoría 
            strTablaEspaciosHTML.Append("<td width='10%' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(4)) & "</td>")
            'Planograma
            strTablaEspaciosHTML.Append("<td width='8%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(5)) & "</td>")
            'Precio
            strTablaEspaciosHTML.Append("<td width='10%' align=right class=" & strColorRegistro & ">" & "$" & CDec(strConsultaExhibiciones(7)).ToString() & "</td>")
            'Fecha Ini
            strTablaEspaciosHTML.Append("<td width='8%' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(8)) & "</td>")
            'Fecha Fin
            strTablaEspaciosHTML.Append("<td width='8%' class=" & strColorRegistro & ">" & clsCommons.strFormatearFechaPresentacion(strConsultaExhibiciones(9)) & "</td>")
            'Sucursales
            strTablaEspaciosHTML.Append("<td width='4%' class=" & strColorRegistro & " align='center'>" & clsCommons.strFormatearDescripcion(strConsultaExhibiciones(10)) & "</td>")
            'Acción                    
            strTablaEspaciosHTML.Append("<td width='10%' align=right class=" & strColorRegistro & ">" & imgAsignar & imgEditar & imgEliminar & imgDetalle & "</td>")
            strTablaEspaciosHTML.Append("</tr>")

        Next
        strTablaEspaciosHTML.Append("</tr>")
        strTablaEspaciosHTML.Append("</table>")
        strTablaEspaciosHTML.AppendFormat("<input type=""hidden"" id=""txtCurrentPage"" name=""txtCurrentPage"" value=""{0}"">", intPage)
        strTablaConsultaExhibicionesAdicionalesHTML = strTablaEspaciosHTML.ToString
    End Function
#End Region
End Class