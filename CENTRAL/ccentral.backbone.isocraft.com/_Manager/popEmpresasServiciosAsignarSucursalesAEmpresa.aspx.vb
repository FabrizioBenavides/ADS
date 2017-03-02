Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert
Public Class popEmpresasServiciosAsignarSucursalesAEmpresa
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.

    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        'Initialize class properties
        intDireccionId = GetPageParameter("cboDireccion", 0)
        intZonaId = GetPageParameter("cboZona", 0)

        intEmpresaServicioId = GetPageParameter("intEmpresaServicioId", GetPageParameter("txtEmpresaServicioId", 0))
        intEmpresaServicioIdOculto = GetPageParameter("intEmpresaServicioIdOculto", GetPageParameter("txtEmpresaServicioId", 0))
        strEmpresaServicioNombre = GetPageParameter("strEmpresaServicioNombre", GetPageParameter("txtEmpresaServicioNombre", ""))
        blnEmpresaServicioActiva = GetPageParameter("chkEmpresaServicioActiva", False)
        fltComision = GetPageParameter("fltComision", GetPageParameter("txtComisionOculto", 0.0))

    End Sub

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String

    Private intmDireccionId As Integer
    Private intmZonaId As Integer

    Private intmEmpresaServicioId As Integer
    Private intmEmpresaServicioIdOculto As Integer
    Private strmEmpresaServicioNombre As String
    Private blnmEmpresaServicioActiva As Boolean
    Private fltmComision As Double
    Private fltmMontoMaximo As Double
    Private intmFormaPagoId As Integer
#End Region

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
            Return GetPageParameter("strCmd", "Asignar")
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
    ' Name       : intEmpresaServicioId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioId() As Integer
        Get
            Return intmEmpresaServicioId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaServicioIdOculto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioIdOculto() As Integer
        Get
            Return intmEmpresaServicioIdOculto
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioIdOculto = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioNombre() As String
        Get
            Return strmEmpresaServicioNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEmpresaServicioActiva
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioActiva() As Boolean
        Get
            Return blnmEmpresaServicioActiva
        End Get
        Set(ByVal blnValue As Boolean)
            blnmEmpresaServicioActiva = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltComision
    ' Description: Identificador del monto maximo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property fltComision() As Double
        Get
            Return fltmComision
        End Get
        Set(ByVal fltValue As Double)
            fltmComision = fltValue
        End Set
    End Property

    '====================================================================
    ' Name       : fltMontoMaximo
    ' Description: Identificador del monto maximo
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property fltMontoMaximo() As Double
        Get
            If IsNumeric(Request.Form("txtMontoMaximo")) Then
                fltmMontoMaximo = CDbl(Request.Form("txtMontoMaximo"))
            Else
                fltmMontoMaximo = Nothing
            End If
            Return fltmMontoMaximo
        End Get
    End Property

    '====================================================================
    ' Name       : intFormaPagoId
    ' Description: Identificador de la forma de pago
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intFormaPagoId() As Integer
        Get
            If intmFormaPagoId = 0 Then
                intmFormaPagoId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboFormaPago", isocraft.commons.clsWeb.strGetPageParameter("intFormaPagoId", "0")))
            End If
            Return intmFormaPagoId
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
        Dim aobjDirecciones As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)
        Dim strRegistrosDirecciones As String()

        Dim aobjDirFarmacias As New System.Collections.ArrayList

        For Each strRegistrosDirecciones In aobjDirecciones
            aobjDirFarmacias.Add(strRegistrosDirecciones)
        Next
        'Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString)

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, aobjDirFarmacias.ToArray, 0, 1, 2)

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

    '====================================================================
    ' Name       : strLlenarFormaPagoComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboFormaPago"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarFormaPagoComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboFormaPago", intFormaPagoId, Benavides.CC.Business.clsConcentrador.clsSucursal.clsCorresponsaliaMonto.strObtenerFormaPago(strConnectionString), 0, 1, 1)
    End Function


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' Check if the current user can access this page
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Check que page prerequisites
        If intEmpresaServicioId = 0 Then
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

                        Dim selected() As String = Split(isocraft.commons.clsWeb.strGetPageParameter("cboFormaPago", isocraft.commons.clsWeb.strGetPageParameter("intFormaPagoId", "0")), ",")

                        'Si hay una forma de pago seleccionada y hay un monto maximo
                        If fltMontoMaximo <> Nothing And selected.Length > 0 Then

                            ' Recorremos los elementos existentes
                            For Each strRecord As String In aobjSucursales
                                For Each strFormaPago As String In selected
                                    ' Separamos identificadores
                                    Dim aobjCompaniaSucursal As Array = Split(strRecord, "|")

                                    If IsNothing(aobjCompaniaSucursal) = False AndAlso aobjCompaniaSucursal.Length > 0 Then

                                        Dim intCompaniaId As Integer = CInt(ConvertObject(aobjCompaniaSucursal.GetValue(0), TypeCode.Int32))
                                        Dim intSucursalId As Integer = CInt(ConvertObject(aobjCompaniaSucursal.GetValue(1), TypeCode.Int32))

                                        ' Si los identificadores son válidos
                                        If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                                            ' Asociamos la Empresa con la sucursal
                                            'Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.intAsignarSucursales(intCompaniaId, intSucursalId, intEmpresaServicioId, True, fltMontoMaximo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)
                                            Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.intAgregartblEmpresaServicioSucursalMontoMaximo(intCompaniaId, intSucursalId, intEmpresaServicioId, True, fltComision, CInt(strFormaPago), fltMontoMaximo, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)
                                        End If

                                    End If
                                Next
                            Next

                            ' Regresamos a la página padre mostrando las nuevas sucursales
                            Call Response.Write("<html>" & vbCrLf)
                            Call Response.Write("<head>" & vbCrLf)
                            Call Response.Write("<script language=""javascript"">" & vbCrLf)
                            Call Response.Write("window.opener.location.href=""SucursalEmpresasServiciosAsignarEmpresa.aspx?strCmd=Asignar&intEmpresaServicioId=" & intEmpresaServicioId & """;" & vbCrLf)
                            Call Response.Write("window.close();" & vbCrLf)
                            Call Response.Write("</script>" & vbCrLf)
                            Call Response.Write("</head>" & vbCrLf)
                            Call Response.Write("</html>" & vbCrLf)
                            Call Response.End()
                        End If
                    End If
                End If

        End Select

    End Sub

End Class
