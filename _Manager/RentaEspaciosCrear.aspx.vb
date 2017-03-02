
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Commons.clsCommons.clsMSMQ
Imports Benavides.CC.Data.clsPromociones
Imports System.Text
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert
Imports System.IO
Imports Benavides.CC.Business
Imports System.Configuration
Imports Isocraft.Web.Javascript
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Public Class RentaEspaciosCrear
    Inherits System.Web.UI.Page

    Private intDivisionArticulosId As Integer
    Private strCategoriaOperativaId As Integer
    Private intCatmanId As Integer
    Private intSocioComercialId As Integer
    Private intTipoRentaId As Integer
    Private intTipoExhibicionId As Integer
    Private intTipoEspacioPublicitarioId As Integer
    Private intPlanSalidaId As Integer
    Private strmComentarios As String
    Private strmDivision As String = "0"
    Private strmCategoria As String = "0"
    Private strmCatman As String
    Private strmSocioComercial As String
    Private strmProveedorId As String
    Private strmProveedorDescripcion As String
    Private strmTipoRenta As String
    Private strmTipoExhibicion As String
    Private strmEspacioPublicitario As String
    Private strmNombreExhibicion As String
    Private intTipoPlanogramaId As Integer
    Private strmPlanSalida As String
    Private strmTipoPlanograma As String
    Private strmPlanogramaId As String
    Private strmPlanogramaDescripcion As String
    Private strmEstatusId As String
    Private strmIngresoTotal As String
    Private strmCostoCatMan As String
    Private strmCostoMerchandising As String
    Private strmIngresoTotalMerch As String
    Private strmIngresoTotalCatman As String
    Private strmFechaInicio As String
    Private strmFechaFin As String
    Private intEstatusId As Integer

    'Imagen
    Private strmRutaImagen As String = String.Empty
    Private strmImagen As String = String.Empty
    Private intExhibicionId As Integer
    Private intResultado As Integer = 0
    Dim rutaImagenes As String = System.Configuration.ConfigurationSettings.AppSettings("strImagenesExhibiciones")
    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

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
        intTipoExhibicionId = GetPageParameter("cboTipoExhibicion", 0)
        intTipoRentaId = GetPageParameter("cboTipoRenta", 0)
        intTipoEspacioPublicitarioId = GetPageParameter("cboTipoEspacioPublicitario", 0)
        intPlanSalidaId = GetPageParameter("cboPlanSalida", 0)
        intTipoPlanogramaId = GetPageParameter("cboTipoPlanograma", 0)
        intEstatusId = GetPageParameter("cboEstatus", 0)
        intSocioComercialId = GetPageParameter("cboSocioComercial", 0)

    End Sub

#End Region

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

        'Si es "Edicion" se valida para que el combo de "Categoria" obtenga contenido
        If Not IsNothing(strExhibicionId) AndAlso CInt(strExhibicionId) > 0 And Not (Len(Request.Form("cboDivisionArticulos"))) > 0 Then
            intDivisionArticulosId = CInt(strmDivision)
        End If

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
    ' Name       : strDivision
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strDivision() As String
        Get
            If (Len(Request.Form("cboDivisionArticulos"))) > 0 Then
                Return CStr(intDivisionArticulosId)
            End If

            Return strmDivision
        End Get
        Set(ByVal strValue As String)
            strmDivision = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strCategoria
    ' Description: Nombre o descripcion del articulo.
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCategoria() As String
        Get
            If (Len(Request.Form("cboDivisionArticulos"))) > 0 Then
                Return CStr(strCategoriaOperativaId)
            End If

            Return strmCategoria
        End Get
        Set(ByVal strValue As String)
            strmCategoria = strValue
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

    '====================================================================
    ' Name       : strImagen
    ' Description: Ruta de la imagen
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strImagen() As String
        Get
            Return strmImagen
        End Get
        Set(ByVal Value As String)
            strmImagen = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strCatman
    ' Description: Nombre o descripcion del articulo.
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
    ' Name       : strProveedorId
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strProveedorId() As String
        Get
            Return strmProveedorId
        End Get
        Set(ByVal strValue As String)
            strmProveedorId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strProveedorDescripcion
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strProveedorDescripcion() As String
        Get
            Return strmProveedorDescripcion
        End Get
        Set(ByVal strValue As String)
            strmProveedorDescripcion = strValue
        End Set
    End Property

    ''====================================================================
    '' Name       : strTipoExhibicion
    '' Description: 
    '' Accessor   : Read and write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    Protected Property strTipoExhibicion() As String
        Get
            If (Len(Request.Form("cboTipoExhibicion"))) > 0 Then
                Return CStr(intTipoExhibicionId)
            End If

            Return strmTipoExhibicion
        End Get
        Set(ByVal strValue As String)
            strmTipoExhibicion = strValue
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
            If (Len(Request.Form("cboTipoRenta"))) > 0 Then
                Return CStr(intTipoRentaId)
            End If

            Return strmTipoRenta
        End Get
        Set(ByVal strValue As String)
            strmTipoRenta = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTipoEspacioPublicitario
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strTipoEspacioPublicitario() As String
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
    ' Name       : strPlanogramaId
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strPlanogramaId() As String
        Get
            Return strmPlanogramaId
        End Get
        Set(ByVal strValue As String)
            strmPlanogramaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strPlanogramaDescripcion
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strPlanogramaDescripcion() As String
        Get
            Return strmPlanogramaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmPlanogramaDescripcion = strValue
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
    ' Name       : strCostoMerchandising
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strCostoMerchandising() As String
        Get
            Return strmCostoMerchandising
        End Get
        Set(ByVal strValue As String)
            strmCostoMerchandising = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIngresoTotalMerch
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strIngresoTotalMerch() As String
        Get
            Return strmIngresoTotalMerch
        End Get
        Set(ByVal strValue As String)
            strmIngresoTotalMerch = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strIngresoTotalCatman
    ' Description: 
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strIngresoTotalCatman() As String
        Get
            Return strmIngresoTotalCatman
        End Get
        Set(ByVal strValue As String)
            strmIngresoTotalCatman = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strEstatusId
    ' Description: Estatus de la renta
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Property strEstatusId() As String
        Get
            Return strmEstatusId
        End Get
        Set(ByVal strValue As String)
            strmEstatusId = strValue
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
    ' Name       : strArchivoImagen
    ' Description: Ruta de la imagen 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strArchivoImagen() As String
        Get
            Return Request.Form("txtArchivoImagen")
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
    ' Description: Fecha de fin a Consultar
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
    ' Name       : strExhibicionId
    ' Description: Codigo del la exhibicion a Editar
    ' Accessor   : Read and write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strExhibicionId() As String
        Get
            If Not IsNothing(Request.QueryString("strExhibicionId")) Then
                'Si es parametro de la pantalla anterior
                Return Request.QueryString("strExhibicionId")
            ElseIf Not IsNothing(Request.Form("hdnExhibicionCodigo")) And CInt(Request.Form("hdnExhibicionCodigo")) > 0 Then
                'Si es parametro de la forma (misma pantalla)
                Return Request.Form("hdnExhibicionCodigo")
            ElseIf Not intResultado = 0 Then
                'El Id de la Exhibicion que se acaba de crear
                Return CStr(intResultado)
            Else
                Return "0"
            End If
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load  'Me.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If


        'Guardar
        If (Len(Request.Form("cmdGuardar"))) > 0 Then

            Try
                Dim _archivo As System.Web.HttpPostedFile
                _archivo = txtArchivo.PostedFile
                intExhibicionId = 0

                'Datos Generales
                strmCatman = CStr(intCatmanId)
                strmSocioComercial = CStr(intSocioComercialId)
                strmProveedorId = Request.Form("txtProveedorNombreId")
                strmProveedorDescripcion = Request.Form("txtProveedorRazonSocial")

                'Datos Exhibición
                strmTipoRenta = CStr(intTipoRentaId)
                strmTipoExhibicion = CStr(intTipoExhibicionId)
                strmEspacioPublicitario = CStr(intTipoEspacioPublicitarioId)
                strmNombreExhibicion = Request.Form("txtNombreExhibicion").ToUpper()
                strmPlanSalida = CStr(intPlanSalidaId)
                strmComentarios = Request.Form("txtComentariosPlanSalida").ToUpper()
                strmTipoPlanograma = CStr(intTipoPlanogramaId)
                strmPlanogramaId = Request.Form("txtPlanogramaId")
                strmPlanogramaDescripcion = Request.Form("txtPlanogramaDescripcion")

                strmEstatusId = "1"

                If Not IsNothing(strExhibicionId) AndAlso CInt(strExhibicionId) > 0 Then
                    strmEstatusId = intEstatusId.ToString()
                End If

                'Costos e Ingresos
                strmCostoMerchandising = Request.Form("txtCostoMerchandising")
                strmCostoCatMan = Request.Form("txtCostoCatman")
                strmIngresoTotalMerch = Request.Form("txtIngresoTotMerch")
                strmIngresoTotalCatman = Request.Form("txtIngresoTotCatman")
                strmIngresoTotal = Request.Form("txtIngresoTotal")

                'Vigencia
                strmFechaInicio = Request.Form("dtmFechaIni")
                strmFechaFin = Request.Form("dtmFechaFin")

                'Nombre de archivo
                Dim strNombreArchivo As String
                strNombreArchivo = Path.GetFileName(_archivo.FileName)

                If strNombreArchivo.Length = 0 Then
                    If txtArchivo.Value.Trim() = String.Empty Then
                        strmRutaImagen = String.Empty
                    End If
                Else
                    Dim strExtensionArchivo As String = Path.GetExtension(strNombreArchivo).ToUpper()

                    If strExtensionArchivo = ".PNG" Or strExtensionArchivo = ".JPG" Or strExtensionArchivo = ".GIF" Then
                        strmRutaImagen = strNombreArchivo
                    Else
                        'Mensaje al usuario
                        Response.Write("<script language=""JavaScript"" type=""text/javascript"">alert('El formato del archivo es incorrecto, debe ser .png, .jpg o .gif.');</script>")
                        Return
                    End If
                End If

                'If CInt(strExhibicionId) > 0 And txtArchivo.Value.Trim() = String.Empty Then
                '    strmRutaImagen = Request.Form("txtNombreArchivo")
                'End If

                intResultado = Benavides.CC.Data.clsExhibicionesAdicionales.intGuardarExhibicionAdicional(CInt(strExhibicionId), intDivisionArticulosId, strCategoriaOperativaId, intCatmanId, _
                                                                                                          strmProveedorId, intSocioComercialId, intTipoRentaId, intTipoExhibicionId, _
                                                                                                          intTipoEspacioPublicitarioId, strmNombreExhibicion, intPlanSalidaId, _
                                                                                                          strmComentarios, intTipoPlanogramaId, CInt(strmPlanogramaId), CInt(strmEstatusId), _
                                                                                                          CDbl(strmCostoMerchandising), CDbl(strmCostoCatMan), CDbl(strmIngresoTotalMerch), _
                                                                                                          CDbl(strmIngresoTotalCatman), CDbl(strmIngresoTotal), strmRutaImagen, _
                                                                                                          dtmFechaInicio, dtmFechaFin, strUsuarioNombre, strConnectionString)

                intExhibicionId = intResultado

                'Se redirecciona al usuario a la pantalla de la consulta.
                If intResultado > 0 Then

                    If strNombreArchivo.Length > 0 Then

                        'El nombre de la imagen se forma del nombre del archivo + el id de la Exhibicion
                        strmImagen = CStr(intExhibicionId) & strmRutaImagen

                        Dim result(CInt(_archivo.InputStream.Length)) As Byte
                        _archivo.InputStream.Read(result, 0, CInt(_archivo.InputStream.Length))

                        'Se envia a la pantalla de Imagen con sus parametros para la imagen.
                        Dim client As New System.Net.WebClient()
                        Dim values As New System.Collections.Specialized.NameValueCollection
                        values.Add("id", strmImagen)
                        values.Add("content", System.Convert.ToBase64String(result))

                        client.Headers("Content-Type") = "application/x-www-form-urlencoded"
                        client.UploadValues(ConfigurationSettings.AppSettings("strImagenesExhibiciones"), values)
                    End If

                    'Mensaje al usuario
                    Response.Write("<script language=""JavaScript"" type=""text/javascript"">alert('Se guardaron los cambios de la exhibicion');</script>")
                End If
            Catch ex As Exception
                Response.Write("<script language=""JavaScript"" type=""text/javascript"">alert('Ocurrio un error');</script>")
            End Try
        End If 'Termina GUARDAR


        Dim objArray As Array = Nothing

        'EDITAR EXHIBICION ADICIONAL 
        If Not IsNothing(strExhibicionId) AndAlso CInt(strExhibicionId) > 0 Then

            objArray = Benavides.CC.Data.clsExhibicionesAdicionales.strBuscarExhibicionDetalle(CInt(strExhibicionId), strConnectionString)

            If Not IsPostBack Or (Len(Request.Form("cmdGuardar"))) > 0 Then

                If IsArray(objArray) AndAlso objArray.Length > 0 Then

                    'Datos Generales
                    strmDivision = CStr(CType(objArray.GetValue(0), Array).GetValue(1))
                    strmCategoria = CStr(CType(objArray.GetValue(0), Array).GetValue(3))
                    strmCatman = CStr(CType(objArray.GetValue(0), Array).GetValue(5))
                    strmSocioComercial = CStr(CType(objArray.GetValue(0), Array).GetValue(7))
                    strmProveedorId = CStr(CType(objArray.GetValue(0), Array).GetValue(9))
                    strmProveedorDescripcion = CStr(CType(objArray.GetValue(0), Array).GetValue(10))

                    'Datos Exhibición
                    strmTipoRenta = CStr(CType(objArray.GetValue(0), Array).GetValue(11))
                    strmTipoExhibicion = CStr(CType(objArray.GetValue(0), Array).GetValue(13))
                    strmEspacioPublicitario = CStr(CType(objArray.GetValue(0), Array).GetValue(15))
                    strmNombreExhibicion = CStr(CType(objArray.GetValue(0), Array).GetValue(17))
                    strmPlanSalida = CStr(CType(objArray.GetValue(0), Array).GetValue(18))
                    strmComentarios = CStr(CType(objArray.GetValue(0), Array).GetValue(20))
                    strmTipoPlanograma = CStr(CType(objArray.GetValue(0), Array).GetValue(21))
                    strmPlanogramaId = CStr(CType(objArray.GetValue(0), Array).GetValue(23))
                    strmPlanogramaDescripcion = CStr(CType(objArray.GetValue(0), Array).GetValue(24))
                    strmEstatusId = CStr(CType(objArray.GetValue(0), Array).GetValue(25))

                    'Costos e Ingresos
                    strmCostoMerchandising = CStr(CType(objArray.GetValue(0), Array).GetValue(27))
                    strmCostoCatMan = CStr(CType(objArray.GetValue(0), Array).GetValue(28))
                    strmIngresoTotalMerch = CStr(CType(objArray.GetValue(0), Array).GetValue(29))
                    strmIngresoTotalCatman = CStr(CType(objArray.GetValue(0), Array).GetValue(30))
                    strmIngresoTotal = CStr(CType(objArray.GetValue(0), Array).GetValue(31))
                    strmRutaImagen = Trim(CStr(CType(objArray.GetValue(0), Array).GetValue(32)))

                    'Vigencia
                    strmFechaInicio = (CDate(CType(objArray.GetValue(0), Array).GetValue(33))).ToString("dd/MM/yyyy")
                    strmFechaFin = (CDate(CType(objArray.GetValue(0), Array).GetValue(34))).ToString("dd/MM/yyyy")

                    If Not strmRutaImagen = String.Empty Then
                        strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
                    End If

                End If

            Else
                'Datos de pantalla'
                RecargaDatosPantalla(objArray)

            End If 'Termina guarda o primera vez de la carga de la pantalla'

        Else
            'Datos de pantalla cuando es Nuevo el registro'
            RecargaDatosPantalla(objArray)
        End If
    End Sub

    Private Sub RecargaDatosPantalla(ByVal objArray As Array)

        'Datos Generales
        strmCatman = Request.Form("cboCatman")
        strmSocioComercial = Request.Form("txtSocioComercial")
        strmProveedorId = Request.Form("txtProveedorNombreId")
        strmProveedorDescripcion = Request.Form("txtProveedorRazonSocial")

        'Datos Exhibición
        strmEspacioPublicitario = Request.Form("cboTipoEspacioPublicitario")
        strmNombreExhibicion = Request.Form("txtNombreExhibicion")
        strmPlanSalida = Request.Form("cboPlanSalida")
        strmComentarios = Request.Form("txtComentariosPlanSalida")
        strmTipoPlanograma = Request.Form("cboTipoPlanograma")
        strmPlanogramaId = Request.Form("txtPlanogramaId")
        strmPlanogramaDescripcion = Request.Form("txtPlanogramaDescripcion")
        strmEstatusId = Request.Form("cboEstatus")

        'Costos e Ingresos
        strmCostoMerchandising = Request.Form("txtCostoMerchandising")
        strmCostoCatMan = Request.Form("txtCostoCatman")
        strmIngresoTotalMerch = Request.Form("txtIngresoTotMerch")
        strmIngresoTotalCatman = Request.Form("txtIngresoTotCatman")
        strmIngresoTotal = Request.Form("txtIngresoTotal")

        'Si NO es Nuevo
        If Not IsNothing(strExhibicionId) AndAlso CInt(strExhibicionId) > 0 Then
            strmRutaImagen = Trim(CStr(CType(objArray.GetValue(0), Array).GetValue(32)))
            If Not strmRutaImagen = String.Empty Then
                strmRutaImagen = String.Format("{0}?id={1}", rutaImagenes, strmRutaImagen)
            End If
        End If

        strmFechaInicio = Request.Form("dtmFechaIni")
        strmFechaFin = Request.Form("dtmFechaFin")
    End Sub
End Class