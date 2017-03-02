Imports Benavides.CC.Data

Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript

Imports System.Text
Imports System.Collections

Public Class popVentasPromocionesMonederoRelacionSucursal
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

        'Put user code to initialize the page here
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        'Inicializa Propiedades


        intDireccionOperativaId = GetPageParameter("cboDireccion", 0)
        intZonaOperativaId = GetPageParameter("cboZona", 0)
        strSucursalId = GetPageParameter("cboSucursal", "")

    End Sub

#End Region

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmDireccionOperativaId As Integer
    Private intmZonaOperativaId As Integer
    Private strmSucursalId As String

    Private strmcboDireccion As String
    Private strmcboZona As String
    Private strmCboSucursal As String

#End Region

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
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
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
            Return Request("strCmd")
        End Get
    End Property


    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 2)

    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionOperativaId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaOperativaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, 0, strConnectionString), 0, 1, 2)
        End If
    End Function

    '====================================================================
    ' Name       : strLlenarSucursalComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboSucursal"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String

    '====================================================================
    Public Function strLlenarSucursalComboBox() As String

        If intDireccionOperativaId > 0 AndAlso intZonaOperativaId > 0 Then

            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursal", strSucursalId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionOperativaId, intZonaOperativaId, strConnectionString), New Integer(1) {0, 1}, 2, 2)

        End If

    End Function

    '====================================================================
    ' Name       : intDireccionOperativaId 
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intDireccionOperativaId() As Integer
        Get
            Return intmDireccionOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionOperativaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaOperativaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intZonaOperativaId() As Integer
        Get
            Return intmZonaOperativaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaOperativaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strSucursalId() As String
        Get
            Return strmSucursalId
        End Get
        Set(ByVal intValue As String)
            strmSucursalId = intValue
        End Set
    End Property

    Public ReadOnly Property intCompaniaid() As Integer
        Get
            Dim intmCompaniaid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmCompaniaid = CInt(astrCompaniaSucursal.GetValue(0))
                End If
            End If

            Return intmCompaniaid

        End Get

    End Property

    Public ReadOnly Property intSucursalid() As Integer
        Get
            Dim intmSucursalid As Integer = 0

            If Len(strSucursalId) > 3 Then
                Dim astrCompaniaSucursal As Array = Split(strSucursalId, "|")
                If astrCompaniaSucursal.Length > 0 Then
                    intmSucursalid = CInt(astrCompaniaSucursal.GetValue(1))
                End If
            End If

            Return intmSucursalid

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

    Public ReadOnly Property intDireccionEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intDireccionEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intZonaEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intZonaEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intCompaniaEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intCompaniaEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intSucursalEliminarId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intSucursalEliminarId"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarSucursales
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarSucursales() As String

        Dim htmlResult As String = ""

        If intDireccionOperativaId = -1 Then
            intZonaOperativaId = -1
        End If

        If intZonaOperativaId = -1 Then
            strSucursalId = "-1|-1"
        End If

        If intDireccionOperativaId <> 0 And intZonaOperativaId <> 0 And Len(strSucursalId) > 0 Then
            ' Declaramos e inicializamos las constantes locales

            Dim strRecordBrowserName As String = "SucursalProveedoresConsultarRelacion"

            ' Declaramos e inicialziamos las variables locales
            Dim intSelectedPage As Integer = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intNavegadorRegistrosPagina", "0", Request))

            If intSelectedPage <= 0 Then
                intSelectedPage = CInt(com.isocraft.commons.clsWeb.strGetPageParameter("intCurrentPage", "1", Request))
            End If

            Dim objDataArraySucursales As Array = clsPromocionMonedero.strBuscarSucursal(intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, intPromocionId.ToString, 0, 0, strConnectionString)

            Dim maxPerPage As Integer = 15

            Dim headers As ArrayList = New ArrayList
            headers.Add("Sucursal")
            headers.Add("Nombre")
            headers.Add("Acciones")
            Dim columnOrder As Integer() = {0, 1}

            Dim pkNames As String() = {"intPromocionEliminarId", "intCompaniaEliminarId", "intSucursalEliminarId"}
            Dim pkIndexes As Integer() = {2, 3, 4}

            Dim actions As ArrayList = New ArrayList
            actions.Add(New Benavides.CC.Commons.clsActionLink("EliminarSucursal", pkNames, pkIndexes, "imgNRborrar.gif", "Haga clic aquí para eliminar esta sucursal de la promoción"))

            Dim AccionRB As String = ""

            If intCompaniaid > 0 And intSucursalid > 0 Then
                accionRB = "<table cellSpacing='0' cellPadding='0' width='100%' border='0'><tr><td align='right' class='tdpadleft5' > <input name='cmdAgregar' type='button' class='boton' value='Agregar Sucursal(es)' language='javascript' onclick='return doSubmit(""AgregarSucursal"")'></td></tr></table>"
            Else
                AccionRB = "<table cellSpacing='0' cellPadding='0' width='100%' border='0'><tr><td align='right' class='tdpadleft5' ><input name='cmdEliminar' type='button' class='boton' value='Eliminar Sucursal(es)' language='javascript' onclick='return doSubmit(""EliminarMasiva"")'>&nbsp;<input name='cmdAgregar' type='button' class='boton' value='Agregar Sucursal(es)' language='javascript' onclick='return doSubmit(""AgregarSucursal"")'></td></tr></table>"
            End If

            htmlResult = Benavides.CC.Commons.clsRecordBrowserNew.displayScroll(objDataArraySucursales.Length, intSelectedPage, maxPerPage, "popVentasPromocionesMonederoRelacionSucursal.aspx", Nothing)
            htmlResult &= AccionRB
            htmlResult &= Benavides.CC.Commons.clsRecordBrowserNew.displayTable(headers, objDataArraySucursales, columnOrder, actions, intSelectedPage, maxPerPage, -1)

        End If

        Return htmlResult

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strHTML As New StringBuilder

        Select Case strCmd

            Case "AgregarSucursal"

                Dim intContadorAlta As Integer = 0
                Dim intErrorAgregar As Integer = 0

                intContadorAlta = clsPromocionMonedero.intActualizarAgregarSucursalPromocionMonedero(intPromocionId, intDireccionOperativaId, intZonaOperativaId, intCompaniaid, intSucursalid, strUsuarioNombre, strConnectionString)

                If intContadorAlta < 0 Then

                    intErrorAgregar = -100 'Error al aplicar el proveedor a las sucursales

                End If


                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarSucursal ( " & _
                           strComitasDobles & intErrorAgregar.ToString & strComitasDobles & "," & _
                           strComitasDobles & intContadorAlta.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarSucursal"

                Dim intEliminar As Integer = 0

                intEliminar = clsPromocionMonedero.intEliminarSucursalPromocionMonedero(intPromocionEliminarId, intDireccionEliminarId, intZonaEliminarId, intCompaniaEliminarId, intSucursalEliminarId, strUsuarioNombre, strConnectionString)

                strHTML.Append("<script language='Javascript'> parent.fnUpEliminarSucursal( " & _
                           strComitasDobles & intEliminar.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()



        End Select


    End Sub

End Class
