Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clspopSucursalAsignarSucursalesAClienteEspecial
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Mantenimiento de Tablas.
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquín Hdz. G. (joaquin@isocraft.com)
' Last Modified : Tuesday, January 11, 2005
'====================================================================

Public Class clsPopSucursalAsignarSucursalesAClienteEspecial
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

        ' Initialize class properties
        intDireccionId = GetPageParameter("cboDireccion", 0)
        intZonaId = GetPageParameter("cboZona", 0)
        intClienteEspecialId = GetPageParameter("intClienteEspecialId", GetPageParameter("txtClienteEspecialId", 0))
        intGrupoClienteEspecialId = GetPageParameter("intGrupoClienteEspecialId", GetPageParameter("txtGrupoClienteEspecialId", 0))
        strClienteEspecialNombreId = GetPageParameter("strClienteEspecialNombreId", GetPageParameter("txtClienteEspecialNombreId", ""))

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmClienteEspecialId As Integer
    Private intmGrupoClienteEspecialId As Integer
    Private strmtxtClienteEspecialNombreId As String

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
            Return GetPageParameter("strCmd", "")
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
    ' Name       : intDireccionId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intDireccionId() As Integer
        Get
            Return intmDireccionId
        End Get
        Set(ByVal intValue As Integer)
            intmDireccionId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intZonaId() As Integer
        Get
            Return intmZonaId
        End Get
        Set(ByVal intValue As Integer)
            intmZonaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intClienteEspecialId() As Integer
        Get
            Return intmClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intGrupoClienteEspecialId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intGrupoClienteEspecialId() As Integer
        Get
            Return intmGrupoClienteEspecialId
        End Get
        Set(ByVal intValue As Integer)
            intmGrupoClienteEspecialId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strClienteEspecialNombreId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strClienteEspecialNombreId() As String
        Get
            Return strmtxtClienteEspecialNombreId
        End Get
        Set(ByVal strValue As String)
            strmtxtClienteEspecialNombreId = strValue
        End Set
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
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 2)
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
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 2)
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
        If intDireccionId > 0 AndAlso (intZonaId > 0 Or intZonaId = -1) Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursales", "", Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString), New Integer(1) {0, 1}, 2, 0)
        ElseIf intDireccionId = -1 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboSucursales", "", Benavides.CC.Data.clstblSucursal.strBuscar(0, 0, 0, 0, "", 0, 0, 0, Now(), "", "", "", "", 0, 0, strConnectionString), New Integer(1) {0, 1}, 4, 0)
        End If
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Check que page prerequisites
        If intClienteEspecialId = 0 Then
            Call Response.Write("<html>" & vbCrLf)
            Call Response.Write("<head>" & vbCrLf)
            Call Response.Write("<script language=""javascript"">" & vbCrLf)
            Call Response.Write("alert(""Esta página no debe ser ejecutada de manera independiente."");" & vbCrLf)
            Call Response.Write("window.close();" & vbCrLf)
            Call Response.Write("</script>" & vbCrLf)
            Call Response.Write("</head>" & vbCrLf)
            Call Response.Write("</html>" & vbCrLf)
            Call Response.End()
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "Asignar"

                Dim strSucursales As String = GetPageParameter("cboSucursales", "")

                ' Si se han seleccionado sucursales
                If Len(strSucursales) > 0 Then

                    ' Obtenemos el listado de pares de identificadores compañía y sucursal
                    Dim aobjSucursales As Array = Split(strSucursales, ",")

                    ' Si el listado tiene elementos
                    If IsNothing(aobjSucursales) = False AndAlso aobjSucursales.Length > 0 Then

                        ' Declaramos el identificador del emisor de formas de pago
                        Dim intEmisorFormaPagoId As Integer

                        ' Si el cliente especial es emisor de formas de pago
                        If intGrupoClienteEspecialId = 6 AndAlso Len(strClienteEspecialNombreId) > 0 Then

                            ' Buscamos su identificador como emisor de formas de pago
                            Dim aobjEmisorFormaPago As Array = Benavides.CC.Data.clstblEmisorFormaPago.strBuscar(0, strClienteEspecialNombreId, "", Now(), Now(), strUsuarioNombre, 0, 0, strConnectionString)

                            ' Si encontramos los datos del emisor
                            If IsNothing(aobjEmisorFormaPago) = False AndAlso aobjEmisorFormaPago.Length > 0 Then

                                ' Obtenemos el identificador del emisor
                                intEmisorFormaPagoId = CInt(DirectCast(aobjEmisorFormaPago.GetValue(0), Array).GetValue(0))

                            End If

                        End If

                        ' Recorremos los elementos existentes
                        For Each strRecord As String In aobjSucursales

                            ' Separamos identificadores
                            Dim aobjCompaniaSucursal As Array = Split(strRecord, "|")

                            If IsNothing(aobjCompaniaSucursal) = False AndAlso aobjCompaniaSucursal.Length > 0 Then

                                Dim intCompaniaId As Integer = CInt(ConvertObject(aobjCompaniaSucursal.GetValue(0), TypeCode.Int32))
                                Dim intSucursalId As Integer = CInt(ConvertObject(aobjCompaniaSucursal.GetValue(1), TypeCode.Int32))

                                ' Si los identificadores son válidos
                                If intCompaniaId > 0 AndAlso intSucursalId > 0 Then

                                    ' Asociamos el cliente especial con la sucursal
                                    Call Benavides.CC.Data.clstblClienteEspecialSucursal.intAgregar(intClienteEspecialId, intCompaniaId, intSucursalId, Now(), strUsuarioNombre, strConnectionString)

                                    ' Asociamos el cliente especial como emisor de formas de pago con la sucursal
                                    If intGrupoClienteEspecialId = 6 AndAlso intEmisorFormaPagoId > 0 Then
                                        Call Benavides.CC.Data.clstblEmisorFormaPagoSucursal.intAgregar(intEmisorFormaPagoId, intCompaniaId, intSucursalId, Now(), strUsuarioNombre, strConnectionString)
                                    End If

                                End If

                            End If

                        Next

                        ' Regresamos a la página padre mostrando las nuevas sucursales
                        Call Response.Write("<html>" & vbCrLf)
                        Call Response.Write("<head>" & vbCrLf)
                        Call Response.Write("<script language=""javascript"">" & vbCrLf)
                        Call Response.Write("window.opener.location.href=""SistemaEditarCliente.aspx?strCmd=Editar&intClienteEspecialId=" & intClienteEspecialId & """;" & vbCrLf)
                        Call Response.Write("window.close();" & vbCrLf)
                        Call Response.Write("</script>" & vbCrLf)
                        Call Response.Write("</head>" & vbCrLf)
                        Call Response.Write("</html>" & vbCrLf)
                        Call Response.End()

                    End If

                End If

        End Select

    End Sub

End Class
