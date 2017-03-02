Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections
Imports System.Configuration
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business

Public Class popVentasPromocionesMonederoDetalleCategoria
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

        ' Leemos los parámetros recibidos
        intDivisionArticulosId = GetPageParameter("cboDivisionArticulos", 0)
        intCategoriaArticulosId = GetPageParameter("cboCategoriaArticulos", 0)

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intDivisionArticulosId As Integer
    Private intCategoriaArticulosId As Integer


#End Region

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
    ' Name       : strAccion
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strAccion() As String
        Get
            Return Request("strAccion")
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
            Return Request("strCmd")
        End Get
    End Property


    '====================================================================
    ' Name       : LlenarControlDivisionArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboDivisionArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlDivisionArticulos() As String

        Return CreateJavascriptComboBoxOptions("cboDivisionArticulos", CStr(intDivisionArticulosId), Benavides.CC.Data.clstblDivisionArticulos.strBuscar(0, "", "", #1/1/2000#, "", 0, 0, strConnectionString), "intDivisionArticulosId", "strDivisionArticulosNombre", 1)

    End Function

    '====================================================================
    ' Name       : LlenarControlCategoriaArticulos
    ' Description: Regresa el codigo necesario en Javascript que permita
    '              llenar el control cboCategoriaArticulos
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Function LlenarControlCategoriaArticulos() As String

        Dim returnedJavascript As String = String.Empty

        If intDivisionArticulosId > 0 Then

            returnedJavascript = CreateJavascriptComboBoxOptions("cboCategoriaArticulos", CStr(intCategoriaArticulosId), Benavides.CC.Data.clstblCategoriaArticulos.strBuscar(intDivisionArticulosId, 0, "", "", #1/1/2000#, "", 0, 0, strConnectionString), "intCategoriaArticulosId", "strCategoriaArticulosNombre", 1)

        End If

        Return returnedJavascript

    End Function

    '====================================================================
    ' Name       : blnActualizaPromocion 
    ' Description: Id promocion
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property blnActualizaPromocion() As Byte
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("blnActualizaPromocion"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CByte(strTemporal)
            End If

        End Get

    End Property

    '====================================================================
    ' Name       : intPromocionId 
    ' Description: Id promocion
    ' Accessor   : Read
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intPromocionId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intPromocionId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get

    End Property

    '====================================================================
    ' Name       : dblPorcentaje 
    ' Description: Monto del descuento
    ' Accessor   : Read
    ' Output     : integer
    '====================================================================
    Public ReadOnly Property dblPorcentaje() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("dblPorcentaje"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property


    Public ReadOnly Property intPromocionEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intPromocionEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intDivisionEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intDivisionEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intCategoriaEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intCategoriaEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarDetalle
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarDetalle() As String

        Dim htmlResult As String = ""


        If intPromocionId > 0 Then


            Dim strRecordBrowserName As String = "popVentasPromocionesMonederoDetalleCategoria.aspx"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArrayCategorias As Array = clsPromocionMonedero.strBuscarCategorias(intPromocionId.ToString, 0, 0, strConnectionString)

            Dim maxPerPage As Integer = 15

            Dim headers As ArrayList = New ArrayList
            headers.Add("División")
            headers.Add("Descripción")
            headers.Add("Categoría")
            headers.Add("Descripción")
            headers.Add("% Monedero")
            headers.Add("Acciones")
            Dim columnOrder As Integer() = {3, 4, 5, 6, 7}

            Dim pkNames As String() = {"intPromocionEliminarId", "intDivisionEliminarId", "intCategoriaEliminarId"}
            Dim pkIndexes As Integer() = {0, 1, 2}

            Dim actions As ArrayList = New ArrayList
            actions.Add(New Benavides.CC.Commons.clsActionLink("EliminarCategoria", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para eliminar este categoría de la promoción"))

            htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArrayCategorias.Length, intSelectedPage, maxPerPage, "popVentasPromocionesMonederoDetalleCategoria.aspx", Nothing)
            htmlResult += Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArrayCategorias, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        End If

        Return htmlResult

    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strHTML As New StringBuilder

        Select Case strCmd

            Case "AgregarCategoria"

                Dim intActualizacion As Integer = 0

                Dim blnPedirConfirmacion As Boolean = False

                intActualizacion = clsPromocionMonedero.intActualizarAgregarCategoriaArticulosPromocionMonedero(intPromocionId, intDivisionArticulosId, intCategoriaArticulosId, dblPorcentaje, blnActualizaPromocion, strUsuarioNombre, strConnectionString)

                If intActualizacion = -99 Then    'El -99 Indica empalme de promoción por lo que hay que pedir confirmacion para afectar
                    blnPedirConfirmacion = True
                End If

                Dim strPromociones As String = ""

                If blnPedirConfirmacion Then

                    Dim objDataArrayEmpalmes As Array = clsPromocionMonedero.strBuscarEmpalme(0, 0, intDivisionArticulosId, intCategoriaArticulosId, 0, 0, strConnectionString)
                    Dim strDataRowEmpalmes As String()

                    If IsArray(objDataArrayEmpalmes) = True AndAlso objDataArrayEmpalmes.Length > 0 Then

                        For Each strDataRowEmpalmes In objDataArrayEmpalmes

                            strPromociones = strPromociones & "\n " & CStr(strDataRowEmpalmes.GetValue(0)) & " - " & CStr(strDataRowEmpalmes.GetValue(1))

                        Next

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarCategoria( " & _
                           strComitasDobles & intActualizacion.ToString & strComitasDobles & "," & _
                           strComitasDobles & strPromociones & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarCategoria"

                Dim intEliminar As Integer = 0

                intEliminar = clsPromocionMonedero.intEliminarDetallePromocionMonedero(intPromocionEliminarId.ToString, 0, intDivisionEliminarId, intCategoriaEliminarId, strUsuarioNombre, strConnectionString)

                strHTML.Append("<script language='Javascript'> parent.fnUpEliminarCategoria( " & _
                           strComitasDobles & intEliminar.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select


    End Sub

End Class
