Imports Isocraft.Web.Http

'====================================================================
' Class         : SucursalEmpresasServiciosConsultarPagos
' Description   : Consulta de pago de servicios a distintos niveles
' Copyright     : (c) Softtek 2008
' Company       : Softtek
' Author        : Oswaldo Laguna
' Last Modified : 5 de Mayo del 2008
'====================================================================

Public Class SucursalEmpresasServiciosConsultarPagos
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

        Select Case strCmd

            Case "Ver"

                strEmpresaIds = GetPageParameter("strEmpresaIds", GetPageParameter("txtEmpresas", ""))

        End Select

        intEmpresaServicioId = GetPageParameter("intEmpresaServicioId", 0)

        strEmpresaIds = GetPageParameter("strEmpresaIds", GetPageParameter("txtEmpresas", ""))
        strEmpresaServicioIdsOculto = GetPageParameter("strEmpresaIds", GetPageParameter("txtEmpresaServicioIdsOculto", ""))

        'String Format IDs -- Names -- Empresas

        'If Any Company is Selected  
        If (strEmpresaIds <> "") Then
            If (strEmpresaIds.IndexOf("|") > 0) Then
                strEmpresaIds = strEmpresaIds & ","
                Dim strEmpresaIdsTemp As String = ""

                'Remove All Ids
                While (strEmpresaIds.IndexOf("|") > 0)
                    strEmpresaIdsTemp = strEmpresaIdsTemp & strEmpresaIds.Substring(strEmpresaIds.IndexOf("|") + 1, (strEmpresaIds.IndexOf(",") - 1) - strEmpresaIds.IndexOf("|") + 1)
                    strEmpresaIds = strEmpresaIds.Remove(0, strEmpresaIds.IndexOf(",") + 1)
                End While

                'Remove Last ,
                strEmpresaIds = strEmpresaIdsTemp.Remove(strEmpresaIdsTemp.Length - 1, 1)
            End If
        End If

        'If Any Company is Selected  
        If (strEmpresaServicioIdsOculto <> "") Then
            If (strEmpresaServicioIdsOculto.IndexOf("|") > 0) Then
                'Mark End Point With ,
                strEmpresaServicioIdsOculto = strEmpresaServicioIdsOculto & ","
                Dim strEmpresaIdsTemp As String = ""

                'Remove All names
                While (strEmpresaServicioIdsOculto.IndexOf("|") > 0)
                    strEmpresaIdsTemp = strEmpresaIdsTemp & strEmpresaServicioIdsOculto.Substring(0, strEmpresaServicioIdsOculto.IndexOf("|")) & ","
                    strEmpresaServicioIdsOculto = strEmpresaServicioIdsOculto.Remove(0, strEmpresaServicioIdsOculto.IndexOf(",") + 1)
                End While

                'Remove Last ,
                strEmpresaServicioIdsOculto = strEmpresaIdsTemp.Remove(strEmpresaIdsTemp.Length - 1, 1)
            End If
        End If

        strEmpresaServicioNombre = GetPageParameter("strEmpresaServicioNombre", "")

        intFormaPagoId = GetPageParameter("cboFormaPago", 0)

        intFormaPagoIdOculto = GetPageParameter("cboFormaPago", GetPageParameter("txtFormaPagoIdOculto", 0))

        intFormaPagoIndexOculto = GetPageParameter("intFormaPagoIndexoculto", GetPageParameter("txtFormaPagoIndexOculto", 0))

        optTodasEmpresas = GetPageParameter("optTodasEmpresas", False)

        optBuscarEmpresas = GetPageParameter("optBuscarEmpresas", False)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private intmEmpresaServicioId As Integer
    Private strmEmpresaIds As String
    Private strmEmpresaServicioIdsOculto As String
    Private strmEmpresaServicioNombre As String
    Private strmFechaInicial As String
    Private strmFechaFinal As String
    Private intmFormaPagoId As Integer
    Private intmFormaPagoIdOculto As Integer
    Private intmFormaPagoIndexOculto As Integer
    Private optmBuscarEmpresas As Boolean
    Private optmTodasEmpresas As Boolean
    Private strmJavascriptWindowOnLoadCommands As String

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
    ' Name       : strEmpresaIds
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property strEmpresaIds() As String
        Get
            Return strmEmpresaIds
        End Get
        Set(ByVal strValue As String)
            strmEmpresaIds = strValue
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
    ' Name       : strEmpresaIds
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioIdsOculto() As String
        Get
            Return strmEmpresaServicioIdsOculto
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioIdsOculto = strValue
        End Set
    End Property
    '====================================================================
    ' Name       : blnEmpresaActiva
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property optBuscarEmpresas() As Boolean
        Get
            Return optmBuscarEmpresas
        End Get
        Set(ByVal blnValue As Boolean)
            optmBuscarEmpresas = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : optTodasEmpresas
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property optTodasEmpresas() As Boolean
        Get
            Return optmTodasEmpresas
        End Get
        Set(ByVal blnValue As Boolean)
            optmTodasEmpresas = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFormaPagoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intFormaPagoId() As Integer
        Get
            Return intmFormaPagoId
        End Get
        Set(ByVal intValue As Integer)
            intmFormaPagoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFormaPagoIdOculto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intFormaPagoIdOculto() As Integer
        Get
            Return intmFormaPagoIdOculto
        End Get
        Set(ByVal intValue As Integer)
            intmFormaPagoIdOculto = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intFormaPagoIndexOculto
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intFormaPagoIndexOculto() As Integer
        Get
            Return intmFormaPagoIndexOculto
        End Get
        Set(ByVal intValue As Integer)
            intmFormaPagoIndexOculto = intValue
        End Set
    End Property


    '====================================================================
    ' Name       : strFechaInicial
    ' Description: Fecha inicial
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaInicial() As String
        Get
            strmFechaInicial = isocraft.commons.clsWeb.strGetPageParameter("txtFechaInicial", isocraft.commons.clsWeb.strGetPageParameter("strFechaInicial", ""))
            If Len(strmFechaInicial) = 0 Then
                Dim dtmYesterday As Date = DateAdd(DateInterval.Day, -1, Now)
                strmFechaInicial = strComplete2Digit(CStr(Day(dtmYesterday))) & "/" & strComplete2Digit(CStr(Month(dtmYesterday))) & "/" & Year(dtmYesterday)
            Else
                Dim astrData As Array = strmFechaInicial.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaInicial = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaInicial
        End Get
        Set(ByVal strValue As String)
            strmFechaInicial = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFechaFinal
    ' Description: Fecha final
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFechaFinal() As String
        Get
            strmFechaFinal = isocraft.commons.clsWeb.strGetPageParameter("txtFechaFinal", isocraft.commons.clsWeb.strGetPageParameter("strFechaFinal", ""))
            If Len(strmFechaFinal) = 0 Then
                strmFechaFinal = strComplete2Digit(CStr(Day(Now))) & "/" & strComplete2Digit(CStr(Month(Now))) & "/" & Year(Now)
            Else
                Dim astrData As Array = strmFechaFinal.Split("/"c)
                If astrData.Length = 3 Then
                    strmFechaFinal = strComplete2Digit(CStr(astrData.GetValue(0))) & "/" & strComplete2Digit(CStr(astrData.GetValue(1))) & "/" & CStr(astrData.GetValue(2))
                End If
            End If
            Return strmFechaFinal
        End Get
        Set(ByVal strValue As String)
            strmFechaFinal = strValue
        End Set
    End Property

    Private Function strComplete2Digit(ByVal strValue As String) As String
        If Len(strValue) = 1 Then
            Return "0" & strValue
        Else
            Return strValue
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
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboFormaPago", 0, Benavides.CC.Data.clstblFormaPago.strBuscar(0, "", "", "", 0, 0, 0, 0, 0, Today(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strGetCSVData
    ' Description: Regresa el contenido CSV de la consulta
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetCSVData() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 200

        ' Obtenemos el rango de fechas
        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

        Dim intValueRadioButtons As Integer = CInt(Request.Form("optEmpresa"))
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array
        Dim aobjDataArrayEmpresas As Array

        Select Case strCmd

            Case "Exportar"

                'Evaluamos si estan seleccionadas todas las empresas 
                'para mandarle la cadena de las empresas existentes
                If (intValueRadioButtons = 1) Then

                    aobjDataArrayEmpresas = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(0, "", "", 0, 0, "", False, False, CDate("01/01/1900"), "", 0, 0, strConnectionString)
                    aobjDataArray = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strExportarEmpresas(aobjDataArrayEmpresas, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, strConnectionString)

                Else

                    aobjDataArray = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strExportarEmpresas(strEmpresaServicioIdsOculto, intFormaPagoId, dtmFechaInicial, dtmFechaFinal, strConnectionString)

                End If

            Case "Asignar"

                aobjDataArray = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strExportarEmpresas(Convert.ToString(intEmpresaServicioId), intFormaPagoId, dtmFechaInicial, dtmFechaFinal, strConnectionString)

        End Select

        ' Declaramos e inicializamos las variables locales
        Dim astrCSVData As System.Text.StringBuilder = New System.Text.StringBuilder

        ' Si encontramos información
        If IsNothing(aobjDataArray) = False AndAlso aobjDataArray.Length > 0 Then

            Dim blnPrintedHeaders As Boolean

            ' Por cada renglón existente
            For Each objRow As System.Collections.SortedList In aobjDataArray

                If blnPrintedHeaders = False Then

                    ' Por cada columna existente
                    For intCounter As Integer = 0 To objRow.Count - 1

                        ' Agregamos el encabezado
                        Call astrCSVData.Append(objRow.GetKey(intCounter))
                        Call astrCSVData.Append(",")

                    Next

                    ' Agregamos el separador de línea
                    Call astrCSVData.Append(vbCrLf)
                    blnPrintedHeaders = True

                End If

                ' Por cada columna existente
                For intCounter As Integer = 0 To objRow.Count - 1

                    ' Agregamos la columna
                    Call astrCSVData.Append(objRow.GetByIndex(intCounter))
                    Call astrCSVData.Append(",")

                Next

                ' Agregamos el separador de línea
                Call astrCSVData.Append(vbCrLf)

            Next

        End If

        Return astrCSVData.ToString()

    End Function

    '====================================================================
    ' Name       : strGetRecordBrowserHTML()
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "SucursalEmpresasServiciosConsultarPagosTodasTiendas"

        ' Obtenemos el rango de fechas
        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

        Select Case strCmd

            Case "Consultar"

                ' Declaramos e inicializamos las variables locales
                Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
                Dim aobjDataArray As Array
                Dim aobjDataArrayEmpresas As Array
                Dim intValueRadioButtons As Integer = CInt(Request.Form("optEmpresa"))

                'Evaluamos si estan seleccionadas todas las empresas 
                'para mandarle la cadena de las empresas existentes
                If (intValueRadioButtons = 1) Then

                    aobjDataArrayEmpresas = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(0, "", "", 0, 0, "", False, False, CDate("01/01/1900"), "", 0, 0, strConnectionString)
                    aobjDataArray = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioPago.strBuscarPagosDeEmpresasSeleccionadas(aobjDataArrayEmpresas, dtmFechaInicial, dtmFechaFinal, intFormaPagoId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

                Else

                    aobjDataArray = Benavides.CC.Data.clstblEmpresaServicioPago.strBuscarPagosDeEmpresasSeleccionadas(strEmpresaServicioIdsOculto, dtmFechaInicial, dtmFechaFinal, intFormaPagoId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

                End If



                ' Generamos el URL destino de las páginas
                Dim strQueryString As String = "txtEmpresas=" & strEmpresaIds & _
                                            "&txtEmpresaServicioIdsOculto=" & strmEmpresaServicioIdsOculto & _
                                            "&optTodasEmpresas=" & optTodasEmpresas & _
                                            "&optBuscarEmpresas=" & optBuscarEmpresas & _
                                            "&txtFormaPagoIdOculto=" & intFormaPagoId & _
                                            "&cboFormaPago=" & intFormaPagoId & _
                                            "&txtFechaInicial=" & strFechaInicial & _
                                            "&txtFechaFinal=" & strFechaFinal & _
                                            "&strRBCmd=Consultar"

                ' Generamos el navegador de registros

                Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strThisPageName & "?" & strQueryString & "&")

        End Select

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        Select Case strCmd

            Case "Ver"

                Call Response.Redirect("SucursalEmpresasServiciosConsultarPagosDetalle.aspx?strCmd=VerDireccion" & "&intEmpresaServicioId=" & intEmpresaServicioId & "&strEmpresaServicioNombre=" & strEmpresaServicioNombre & "&strFechaInicial=" & strFechaInicial & "&strFechaFinal=" & strFechaFinal & "&intFormaPagoId=" & intFormaPagoIdOculto & "&strNivel=" & "Direccion")

            Case "Asignar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""PagosDeServicios.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

            Case "Exportar"

                ' Establecemos en la respuesta los parámetros de configuración del archivo
                Response.ContentType = "application/octet-stream"
                Call Response.AddHeader("Content-Disposition", "attachment; filename=""PagosDeServicios.csv""")
                Call Response.Write(strGetCSVData())
                Call Response.End()

        End Select
    End Sub

End Class
