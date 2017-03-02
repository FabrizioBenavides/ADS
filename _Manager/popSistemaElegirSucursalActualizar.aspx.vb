Public Class popSistemaElegirSucursalActualizar
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

    ' Variables privadas locales
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmEmpleadoId As Integer
    Private strmEmpleadoNombre As String
    Private strmGrupoUsuarioNombre As String
    Private strmDireccionId As String
    Private strmZonaId As String


    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If Len(strmDireccionId) = 0 Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", "0")
            End If
            If strmDireccionId.Equals("0") = True Then
                strmDireccionId = isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0")
            End If
            Return CInt(strmDireccionId)
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If Len(strmZonaId) = 0 Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("cboZona", "0")
            End If
            If strmZonaId.Equals("0") = True Then
                strmZonaId = isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")
            End If
            Return CInt(strmZonaId)
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

        If intDireccionId > 0 AndAlso intZonaId > 0 Then

            Dim strComboSucursal As System.Text.StringBuilder = Nothing

            Dim intCounter As Integer = 0

            Dim objArray As Array = Nothing
            Dim objRegistro As String() = Nothing

            Dim strOpcion As String = ""
            Dim strValor As String = ""


            objArray = Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, intZonaId, strConnectionString)

            If IsArray(objArray) AndAlso objArray.Length > 0 Then

                strComboSucursal = New System.Text.StringBuilder

                For Each objRegistro In objArray

                    strOpcion = objRegistro(0).ToString & "-" & objRegistro(1).ToString & " " & objRegistro(2).ToString
                    strValor = Right("0000" & Trim(objRegistro(0).ToString), 4) & Right("0000" & Trim(objRegistro(1).ToString), 4)

                    strComboSucursal.Append("  document.forms[0].elements['cboSucursal'].options[" & intCounter & "] = new Option(""" & strOpcion & """,""" & strValor & """);" & vbCrLf)

                    intCounter += 1
                Next

                Return strComboSucursal.ToString()

            End If
        Else
            Return ""
        End If

    End Function

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
    ' Name       : strThisPageName
    ' Description: Nombre de esta página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetPageName(Request)
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : None
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
    ' Description: Obtiene o establece el comando actual
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strConnectionString
    ' Description: Obtiene la cadena de conexión hacia la base de datos
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        Dim intDireccionActualizar As Integer = -1
        Dim intZonaActualizar As Integer = -1
        Dim strSucursalesActualizar As String = ""

        intDireccionActualizar = CInt(Request.Form("cboDireccion"))
        intZonaActualizar = CInt(Request.Form("cboZona"))
        strSucursalesActualizar = Request.Form("cboSucursal")


        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Cerrar"
                If intDireccionActualizar >= 0 And intZonaActualizar >= 0 Then

                    If intDireccionActualizar = 0 Or intZonaActualizar = 0 Then
                        strSucursalesActualizar = ""
                    Else
                        strSucursalesActualizar = Request.Form("cboSucursal")
                    End If

                    'Regresamos a la página padre con las sucursales seleccionadas
                    Call Response.Write("<html>" & vbCrLf)
                    Call Response.Write("<head>" & vbCrLf)
                    Call Response.Write("<script language=""javascript"">" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtDireccionId""].value=""" & intDireccionActualizar.ToString & """;" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtZonaId""].value=""" & intZonaActualizar.ToString & """;" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].elements[""txtSucursales""].value=""" & strSucursalesActualizar & """;" & vbCrLf)
                    Call Response.Write("window.opener.document.forms[0].submit();" & vbCrLf)
                    Call Response.Write("window.close();" & vbCrLf)
                    Call Response.Write("</script>" & vbCrLf)
                    Call Response.Write("</head>" & vbCrLf)
                    Call Response.Write("</html>" & vbCrLf)
                    Call Response.End()

                End If



        End Select
    End Sub

End Class
