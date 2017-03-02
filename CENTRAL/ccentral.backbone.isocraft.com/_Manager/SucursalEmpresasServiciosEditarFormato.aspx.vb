Imports Isocraft.Web.Http
Imports Isocraft.Web.Javascript
Imports Isocraft.Web.Convert

Public Class SucursalEmpresasServiciosEditarFormato
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

        intEmpresaServicioId = GetPageParameter("txtEmpresaServicioId", GetPageParameter("intEmpresaServicioId", 0))
        strEmpresaServicioNombre = GetPageParameter("txtEmpresaServicioNombre", "")

        intEmpresaServicioTipoDatoFormatoId = GetPageParameter("cboDatos", 0)

        intRowCounter = GetPageParameter("txtRowCounter", GetPageParameter("intRowCounter", 0))

        strInterfazHTML = GetPageParameter("strInterfazHTML", "")

        blnModoAgregarDatos = GetPageParameter("blnModoAgregarDatos", False)

    End Sub

#End Region

#Region " Class Private Attributes"

    'EmpresaServicio
    Private intmEmpresaServicioId As Integer
    Private strmEmpresaServicioNombre As String

    'EmpresaServicioFormato
    Private intmEmpresaServicioFormatoId As Integer
    Private strmEmpresaServicioFormatoDescripcion As String
    Private intmEmpresaServicioFormatoLongitud As Integer
    Private intmEmpresaServicioFormatoPosicion As Integer
    Private blnmEmpresaServicioFormatoConfirmacionPOS As Boolean
    Private blnmEmpresaServicioFormatoSolicitarCapturaManual As Boolean
    Private blnmEmpresaServicioFormatoSolicitarRecaptura As Boolean
    Private blnmEmpresaServicioFormatoAplica As Boolean

    'EmpresaServicioDatoAdicionalFormato
    Private strmEmpresaServicioDatoAdicionalFormatoNombre As String
    Private strmEmpresaServicioDatoAdicionalFormatoValor As String

    'EmpresaServicioTipoDatoFormato
    Private intmEmpresaServicioTipoDatoFormatoId As Integer
    Private strmEmpresaServicioTipoDatoFormatoNombre As String

    'EmpresaServicioTipoDatoAdicionalFormato
    Private strmEmpresaServicioTipoDatoAdicionalFormatoNombre As String
    Private strmEmpresaServicioTipoDatoAdicionalFormatoComponente As String

    'Counter of Editor Rows
    Private intmRowCounter As Integer

    'Add Data Mode
    Dim blnmModoAgregarDatos As Boolean

    'Infertaz HTML Principal
    Private strmInterfazHTML As String

    Private strmJavascriptWindowOnLoadCommands As String

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
    ' Name       : intRowCounter
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intRowCounter() As Integer
        Get
            Return intmRowCounter
        End Get
        Set(ByVal intValue As Integer)
            intmRowCounter = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnModoAgregarDatos
    ' Description: Specify if Data Mode in ON/OFF
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnModoAgregarDatos() As Boolean
        Get
            Return blnmModoAgregarDatos
        End Get
        Set(ByVal blnValue As Boolean)
            blnmModoAgregarDatos = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaServicioId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
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
    ' Name       : intEmpresaServicioFormatoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioFormatoId() As Integer
        Get
            Return intmEmpresaServicioFormatoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioFormatoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioFormatoDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioFormatoDescripcion() As String
        Get
            Return strmEmpresaServicioFormatoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioFormatoDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaServicioFormatoLongitud
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioFormatoLongitud() As Integer
        Get
            Return intmEmpresaServicioFormatoLongitud
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioFormatoLongitud = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intEmpresaServicioFormatoPosicion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioFormatoPosicion() As Integer
        Get
            Return intmEmpresaServicioFormatoPosicion
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioFormatoPosicion = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEmpresaServicioFormatoConfirmacionPOS
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioFormatoConfirmacionPOS() As Boolean
        Get
            Return blnmEmpresaServicioFormatoConfirmacionPOS
        End Get
        Set(ByVal blnValue As Boolean)
            blnmEmpresaServicioFormatoConfirmacionPOS = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEmpresaServicioFormatoSolicitarCapturaManual
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioFormatoSolicitarCapturaManual() As Boolean
        Get
            Return blnmEmpresaServicioFormatoSolicitarCapturaManual
        End Get
        Set(ByVal blnValue As Boolean)
            blnmEmpresaServicioFormatoSolicitarCapturaManual = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEmpresaServicioFormatoSolicitarRecaptura
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioFormatoSolicitarRecaptura() As Boolean
        Get
            Return blnmEmpresaServicioFormatoSolicitarRecaptura
        End Get
        Set(ByVal blnValue As Boolean)
            blnmEmpresaServicioFormatoSolicitarRecaptura = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : blnEmpresaServicioFormatoAplica
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Boolean
    '====================================================================
    Public Property blnEmpresaServicioFormatoAplica() As Boolean
        Get
            Return blnmEmpresaServicioFormatoAplica
        End Get
        Set(ByVal blnValue As Boolean)
            blnmEmpresaServicioFormatoAplica = blnValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioDatoAdicionalFormatoNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioDatoAdicionalFormatoNombre() As String
        Get
            Return strmEmpresaServicioDatoAdicionalFormatoNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioDatoAdicionalFormatoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioDatoAdicionalFormatoValor
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioDatoAdicionalFormatoValor() As String
        Get
            Return strmEmpresaServicioDatoAdicionalFormatoValor
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioDatoAdicionalFormatoValor = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : intEmpresaServicioTipoDatoFormatoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intEmpresaServicioTipoDatoFormatoId() As Integer
        Get
            Return intmEmpresaServicioTipoDatoFormatoId
        End Get
        Set(ByVal intValue As Integer)
            intmEmpresaServicioTipoDatoFormatoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioTipoDatoFormatoNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioTipoDatoFormatoNombre() As String
        Get
            Return strmEmpresaServicioTipoDatoFormatoNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioTipoDatoFormatoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioTipoDatoAdicionalFormatoNombre
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioTipoDatoAdicionalFormatoNombre() As String
        Get
            Return strmEmpresaServicioTipoDatoAdicionalFormatoNombre
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioTipoDatoAdicionalFormatoNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strEmpresaServicioTipoDatoAdicionalFormatoNombreComponente
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strEmpresaServicioTipoDatoAdicionalFormatoComponente() As String
        Get
            Return strmEmpresaServicioTipoDatoAdicionalFormatoComponente
        End Get
        Set(ByVal strValue As String)
            strmEmpresaServicioTipoDatoAdicionalFormatoComponente = strValue
        End Set
    End Property


    '====================================================================
    ' Name       : strHTMLFormatHeaders
    ' Description: HTML for Headers Construction
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strHTMLFormatHeaders() As String
        Get
            Dim strHeaders As String

            strHeaders = strHeaders & "<tr>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=3%><label>Dato Activo</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=3%><label>Mostrar POS</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=3%><label>Captura Manual</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=3%><label>Recapturar</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=10%><label>Descripción</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=15%><label>Tipo de Dato</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=10%><label>Longitud</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center width=10%><label>Posición</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 align=center colspan=3 width=10%><label>Datos Adicionales a Configurar</label></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 width=10%></td>"
            strHeaders = strHeaders & "<td class=tdtittablas3 width=10%>&nbsp;</td>"
            strHeaders = strHeaders & "</tr>"

            Return strHeaders
        End Get
    End Property

    '====================================================================
    ' Name       : strInterfazHTML
    ' Description: HTML for Headers Construction
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strInterfazHTML() As String
        Get
            Return strmInterfazHTML
        End Get
        Set(ByVal strValue As String)
            strmInterfazHTML = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strLlenarDatosComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDatos"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDatosComboBox() As String

        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDatos", intEmpresaServicioTipoDatoFormatoId, Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioTipoDatoFormato.strBuscarDatos(0, "", "", CDate("01/01/1900"), "", 0, 0, strConnectionString), 0, 1, 0)

    End Function

    '====================================================================
    ' Name       : strGenerarInterfazInicial
    ' Description: Returns a HTML to UI Initial Dinamic creation
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGenerarInterfazInicial() As String

        intRowCounter = 0

        'Recuperar datos cargados para el editor de la empresa seleccionada
        Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioFormato.strBuscarFormato(intEmpresaServicioId, strConnectionString)

        ' Si el elemento fue encontrado
        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

            Dim Counter As Integer = 0

            ' Recorremos los elementos existentes
            For Each strRecord As System.Collections.SortedList In aobjData

                Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(Counter), System.Collections.SortedList)

                intEmpresaServicioFormatoId = CInt(aobjRow.Item("intEmpresaServicioFormatoId"))
                intEmpresaServicioTipoDatoFormatoId = CInt(aobjRow.Item("intEmpresaServicioTipoDatoFormatoId"))
                strEmpresaServicioTipoDatoFormatoNombre = CStr(aobjRow.Item("strEmpresaServicioTipoDatoFormatoNombre"))
                strEmpresaServicioFormatoDescripcion = CStr(aobjRow.Item("strEmpresaServicioFormatoDescripcion"))
                intEmpresaServicioFormatoLongitud = CInt(aobjRow.Item("intEmpresaServicioFormatoLongitud"))
                intEmpresaServicioFormatoPosicion = CInt(aobjRow.Item("intEmpresaServicioFormatoPosicion"))
                blnEmpresaServicioFormatoConfirmacionPOS = CBool(aobjRow.Item("blnEmpresaServicioFormatoConfirmacionPOS"))
                blnEmpresaServicioFormatoSolicitarCapturaManual = CBool(aobjRow.Item("blnEmpresaServicioFormatoSolicitarCapturaManual"))
                blnEmpresaServicioFormatoSolicitarRecaptura = CBool(aobjRow.Item("blnEmpresaServicioFormatoSolicitarRecaptura"))
                blnEmpresaServicioFormatoAplica = CBool(aobjRow.Item("blnEmpresaServicioFormatoAplica"))

                'Generar cada fila gráfica para los datos de inicio
                strInterfazHTML = strInterfazHTML & strGenerarFilaTipoDato(intEmpresaServicioFormatoId, intEmpresaServicioTipoDatoFormatoId, strEmpresaServicioTipoDatoFormatoNombre, strEmpresaServicioFormatoDescripcion, intEmpresaServicioFormatoLongitud, intEmpresaServicioFormatoPosicion, blnEmpresaServicioFormatoConfirmacionPOS, blnEmpresaServicioFormatoSolicitarCapturaManual, blnEmpresaServicioFormatoSolicitarRecaptura, blnEmpresaServicioFormatoAplica)

                'Establecer datos iniciales en los controles

                Counter = Counter + 1

                'Aumentar número de fila
                intRowCounter = intRowCounter + 1

            Next

        End If

        Return strInterfazHTML

    End Function

    '====================================================================
    ' Name       : strGenerarFilaTipoDato
    ' Description: Returns a HTML to create a Row for UI Editor
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGenerarFilaTipoDato( _
                                            ByVal intEmpresaServicioFormatoId As Integer, _
                                            ByVal intEmpresaServicioTipoDatoFormatoId As Integer, _
                                            ByVal strEmpresaServicioTipoDatoFormatoNombre As String, _
                                            ByVal strEmpresaServicioFormatoDescripcion As String, _
                                            ByVal intEmpresaServicioFormatoLongitud As Integer, _
                                            ByVal intEmpresaServicioFormatoPosicion As Integer, _
                                            ByVal blnEmpresaServicioFormatoConfirmacionPOS As Boolean, _
                                            ByVal blnEmpresaServicioFormatoSolicitarCapturaManual As Boolean, _
                                            ByVal blnEmpresaServicioFormatoSolicitarRecaptura As Boolean, _
                                            ByVal blnEmpresaServicioFormatoAplica As Boolean) As String


        Dim strFilaTipoDato As String
        'Set the number of default components for each row
        'WARNING: Change tis value in Load Page Event as Well
        Dim intColumnCounter As Integer = 10

        'Start Row
        strFilaTipoDato = "<tr>"

        'Set Default Components For The Row
        strFilaTipoDato = strFilaTipoDato & strHTMLDefaultRowComponents(intEmpresaServicioFormatoId, strEmpresaServicioTipoDatoFormatoNombre, strEmpresaServicioFormatoDescripcion, intEmpresaServicioFormatoLongitud, intEmpresaServicioFormatoPosicion, blnEmpresaServicioFormatoConfirmacionPOS, blnEmpresaServicioFormatoSolicitarCapturaManual, blnEmpresaServicioFormatoSolicitarRecaptura, blnEmpresaServicioFormatoAplica)

        'Get All Individual Components
        Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioTipoDatoAdicionalFormato.strBuscarDatosAdicionales(0, intEmpresaServicioTipoDatoFormatoId, "", "", CDate("01/01/1900"), "", 0, 0, strConnectionString)

        ' Si se encontraron elementos
        If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

            Dim Counter As Integer = 0

            'Create Internal Tabla for Individual Componentes
            strFilaTipoDato = strFilaTipoDato & "<td class=tdpadleft5 align=center width=70%>"
            strFilaTipoDato = strFilaTipoDato & "<table>"
            strFilaTipoDato = strFilaTipoDato & "<tr>"

            ' Recorremos los elementos existentes
            For Each strRecord As System.Collections.SortedList In aobjData

                Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(Counter), System.Collections.SortedList)

                strEmpresaServicioTipoDatoAdicionalFormatoNombre = CStr(aobjRow.Item("strEmpresaServicioTipoDatoAdicionalFormatoNombre"))
                strEmpresaServicioTipoDatoAdicionalFormatoComponente = CStr(aobjRow.Item("strEmpresaServicioTipoDatoAdicionalFormatoComponente"))

                'Get Aditional Data to Set the Aditional Componet Initial Value
                If intEmpresaServicioFormatoId > 0 Then

                    'Nota: se envia strEmpresaServicioTipoDatoAdicionalFormatoNombre al campo strEmpresaServicioDatoAdicionalFormatoNombre
                    Dim aobjStoredData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioDatoAdicionalFormato.strBuscarDatosAdicionales(0, intEmpresaServicioFormatoId, strEmpresaServicioTipoDatoAdicionalFormatoNombre, "", CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    ' Si se encontraron elementos
                    If IsNothing(aobjStoredData) = False AndAlso aobjStoredData.Length > 0 Then

                        Dim aobjRowData As System.Collections.SortedList = DirectCast(aobjStoredData.GetValue(0), System.Collections.SortedList)

                        strEmpresaServicioDatoAdicionalFormatoValor = CStr(aobjRowData.Item("strEmpresaServicioDatoAdicionalFormatoValor"))

                    End If

                End If

                'Set Specific Components
                Select Case strEmpresaServicioTipoDatoAdicionalFormatoComponente

                    Case "CHK"

                        Dim strCHECKED As String = ""

                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "1" Then
                                strCHECKED = "CHECKED"
                            End If
                        End If

                        strFilaTipoDato = strFilaTipoDato & "<td class=tdpadleft5 align=left width=1%><input class=fieldborderless title='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre + "' id=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=checkbox " & strCHECKED & " name=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
                        intColumnCounter = intColumnCounter + 1
                        'Set Aditional Data Name and Component in a Hidden Input
                        strFilaTipoDato = strFilaTipoDato & "<input type=hidden value='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre & "|" & strEmpresaServicioTipoDatoAdicionalFormatoComponente & "' name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
                        intColumnCounter = intColumnCounter + 1

                    Case "TXT"

                        If intEmpresaServicioFormatoId <= 0 Then
                            strEmpresaServicioDatoAdicionalFormatoValor = ""
                        End If

                        strFilaTipoDato = strFilaTipoDato & "<td class=tdpadleft5 align=left width=5%><input class=field title='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre + "' value='" & strEmpresaServicioDatoAdicionalFormatoValor & "' id=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=text maxLength=50 size=5 name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
                        intColumnCounter = intColumnCounter + 1
                        'Set Aditional Data Name and Component in a Hidden Input
                        strFilaTipoDato = strFilaTipoDato & "<input type=hidden value='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre & "|" & strEmpresaServicioTipoDatoAdicionalFormatoComponente & "' name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
                        intColumnCounter = intColumnCounter + 1

                    Case "TXTINT"

                        If intEmpresaServicioFormatoId <= 0 Then
                            strEmpresaServicioDatoAdicionalFormatoValor = ""
                        End If

                        'If Data Name is Presicion change to Decimales
                        'This is only for Tool Tip presentation
                        Dim strTXTINTTitle As String
                        If strEmpresaServicioTipoDatoAdicionalFormatoNombre = "Precision" Then
                            strTXTINTTitle = "Decimales"
                        Else
                            strTXTINTTitle = strEmpresaServicioTipoDatoAdicionalFormatoNombre
                        End If

                        strFilaTipoDato = strFilaTipoDato & "<td class=tdpadleft5 align=left width=5%><input class=field title='" & strTXTINTTitle + "' value='" & strEmpresaServicioDatoAdicionalFormatoValor & "' id=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=text maxLength=5 size=5 name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
                        intColumnCounter = intColumnCounter + 1
                        'Set Aditional Data Name and Component in a Hidden Input
                        strFilaTipoDato = strFilaTipoDato & "<input type=hidden value='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre & "|" & strEmpresaServicioTipoDatoAdicionalFormatoComponente & "' name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
                        intColumnCounter = intColumnCounter + 1

                    Case "TXTFLT"

                        If intEmpresaServicioFormatoId <= 0 Then
                            strEmpresaServicioDatoAdicionalFormatoValor = ""
                        End If

                        'If Data Name is Presicion change to Decimales
                        'This is only for Tool Tip presentation
                        Dim strTXTFLTTitle As String
                        If strEmpresaServicioTipoDatoAdicionalFormatoNombre = "Precision" Then
                            strTXTFLTTitle = "Decimales"
                        Else
                            strTXTFLTTitle = strEmpresaServicioTipoDatoAdicionalFormatoNombre
                        End If

                        strFilaTipoDato = strFilaTipoDato & "<td class=tdpadleft5 align=left width=5%><input class=field title='" & strTXTFLTTitle + "' value='" & strEmpresaServicioDatoAdicionalFormatoValor & "' id=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=text maxLength=10 size=5 name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
                        intColumnCounter = intColumnCounter + 1
                        'Set Aditional Data Name and Component in a Hidden Input
                        strFilaTipoDato = strFilaTipoDato & "<input type=hidden value='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre & "|" & strEmpresaServicioTipoDatoAdicionalFormatoComponente & "' name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
                        intColumnCounter = intColumnCounter + 1

                    Case "CBODATEFORMAT"

                        Dim strSELECTED As String = ""

                        strFilaTipoDato = strFilaTipoDato & "<td class=tdpadleft5 align=left width=5%><select language=javascript onchange='return cmdCboFecha_onchange(" & intRowCounter.ToString() & "," & intColumnCounter.ToString() & ")' class=field title='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre + "' value=" & strEmpresaServicioDatoAdicionalFormatoValor & " id=cbo" & intRowCounter.ToString() & intColumnCounter.ToString() & " name=cbo" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled>"

                        'aaddmm
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "aaddmm" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=aaddmm " & strSELECTED & " >aaddmm</option>"
                        strSELECTED = ""

                        'aaaaddmm
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "aaaaddmm" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=aaaaddmm " & strSELECTED & " >aaaaddmm</option>"
                        strSELECTED = ""

                        'aammdd
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "aammdd" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=aammdd " & strSELECTED & " >aammdd</option>"
                        strSELECTED = ""

                        'aaaammdd
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "aaaammdd" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=aaaammdd " & strSELECTED & " >aaaammdd</option>"
                        strSELECTED = ""

                        'ddaamm
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "ddaamm" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=ddaamm " & strSELECTED & " >ddaamm</option>"
                        strSELECTED = ""

                        'ddaaaamm
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "ddaaaamm" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=ddaaaamm " & strSELECTED & " >ddaaaamm</option>"
                        strSELECTED = ""

                        'ddmmaa
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "ddmmaa" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=ddmmaa " & strSELECTED & " >ddmmaa</option>"
                        strSELECTED = ""

                        'ddmmaaaa
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "ddmmaaaa" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=ddmmaaaa " & strSELECTED & " >ddmmaaaa</option>"
                        strSELECTED = ""

                        'mmaadd
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "mmaadd" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=mmaadd " & strSELECTED & " >mmaadd</option>"
                        strSELECTED = ""

                        'mmaaaadd
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "mmaaaadd" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=mmaaaadd " & strSELECTED & " >mmaaaadd</option>"
                        strSELECTED = ""

                        'mmddaa
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "mmddaa" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=mmddaa " & strSELECTED & " >mmddaa</option>"
                        strSELECTED = ""

                        'mmddaaaa
                        If intEmpresaServicioFormatoId > 0 Then
                            If strEmpresaServicioDatoAdicionalFormatoValor = "mmddaaaa" Then
                                strSELECTED = "SELECTED"
                            End If
                        End If
                        strFilaTipoDato = strFilaTipoDato & "<option value=mmddaaaa " & strSELECTED & " >mmddaaaa</option>"
                        strSELECTED = ""

                        strFilaTipoDato = strFilaTipoDato & "</select></td>"

                        'Script de selección de longitud en base al formato de la fecha
                        strFilaTipoDato = strFilaTipoDato & "<script language='javascript'>cmdCboFecha_onchange(" & intRowCounter.ToString() & "," & intColumnCounter.ToString() & ")</script>"

                        intColumnCounter = intColumnCounter + 1

                        'Set Aditional Data Name and Component in a Hidden Input
                        strFilaTipoDato = strFilaTipoDato & "<input type=hidden value='" & strEmpresaServicioTipoDatoAdicionalFormatoNombre & "|" & strEmpresaServicioTipoDatoAdicionalFormatoComponente & "' name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
                        intColumnCounter = intColumnCounter + 1

                End Select

                Counter = Counter + 1

            Next

            'End of Internal Table
            strFilaTipoDato = strFilaTipoDato & "</tr>"
            strFilaTipoDato = strFilaTipoDato & "</table>"
            strFilaTipoDato = strFilaTipoDato & "</td>"

        End If

        'End Row
        strFilaTipoDato = strFilaTipoDato & "</tr>"

        Return strFilaTipoDato

    End Function

    '====================================================================
    ' Name       : strHTMLDefaultRowComponents
    ' Description: Returns a HTML to create Default Components for each Row
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strHTMLDefaultRowComponents(ByVal intEmpresaServicioFormatoId As Integer, _
                                                ByVal strEmpresaServicioTipoDatoFormatoNombre As String, _
                                                ByVal strEmpresaServicioFormatoDescripcion As String, _
                                                ByVal intEmpresaServicioFormatoLongitud As Integer, _
                                                ByVal intEmpresaServicioFormatoPosicion As Integer, _
                                                ByVal blnEmpresaServicioFormatoConfirmacionPOS As Boolean, _
                                                ByVal blnEmpresaServicioFormatoSolicitarCapturaManual As Boolean, _
                                                ByVal blnEmpresaServicioFormatoSolicitarRecaptura As Boolean, _
                                                ByVal blnEmpresaServicioFormatoAplica As Boolean) As String

        Dim strDefaultComponents As String
        Dim strCHECKED As String

        strDefaultComponents = ""
        strCHECKED = ""

        'Column counter
        Dim intColumnCounter As Integer = 0

        'Append default components

        'intEmpresaServicioFormatoId en Campo Hidden
        strDefaultComponents = strDefaultComponents & "<input type=hidden value=" & intEmpresaServicioFormatoId & " name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
        intColumnCounter = intColumnCounter + 1
        'Aplica
        If blnEmpresaServicioFormatoAplica = True Then
            strCHECKED = "CHECKED"
        End If
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=1%><input class=fieldborderless id=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=checkbox " & strCHECKED & " name=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
        strCHECKED = ""
        intColumnCounter = intColumnCounter + 1
        'Confirma
        If blnEmpresaServicioFormatoConfirmacionPOS = True Then
            strCHECKED = "CHECKED"
        End If
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=1%><input class=fieldborderless id=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=checkbox " & strCHECKED & " name=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
        strCHECKED = ""
        intColumnCounter = intColumnCounter + 1
        'Solicitar
        If blnEmpresaServicioFormatoSolicitarCapturaManual = True Then
            strCHECKED = "CHECKED"
        End If
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=1%><input class=fieldborderless id=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=checkbox " & strCHECKED & " name=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
        strCHECKED = ""
        intColumnCounter = intColumnCounter + 1
        'Recapturar
        If blnEmpresaServicioFormatoSolicitarRecaptura = True Then
            strCHECKED = "CHECKED"
        End If
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=1%><input class=fieldborderless id=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=checkbox " & strCHECKED & " name=chk" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
        strCHECKED = ""
        intColumnCounter = intColumnCounter + 1
        'Descripción
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=5%><input class=field value='" & strEmpresaServicioFormatoDescripcion & "' id=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=text maxLength=50 size=30 name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
        intColumnCounter = intColumnCounter + 1
        'Tipo de Dato
        strDefaultComponents = strDefaultComponents & "<td class=tdtittablas3 align=center width=5%><label id=lbl" & intRowCounter.ToString() & intColumnCounter.ToString() & ">" & strEmpresaServicioTipoDatoFormatoNombre & "</label></td>"
        intColumnCounter = intColumnCounter + 1
        strDefaultComponents = strDefaultComponents & "<input type=hidden value='" & strEmpresaServicioTipoDatoFormatoNombre & "' name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & ">"
        intColumnCounter = intColumnCounter + 1
        'Longitud
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=5%><input class=field value='" & intEmpresaServicioFormatoLongitud.ToString() & "' id=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=text maxLength=2 size=5 name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"
        intColumnCounter = intColumnCounter + 1
        'Posición
        strDefaultComponents = strDefaultComponents & "<td class=tdpadleft5 align=center width=5%><input class=field value='" & intEmpresaServicioFormatoPosicion.ToString() & "' id=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " type=text maxLength=2 size=5 name=txt" & intRowCounter.ToString() & intColumnCounter.ToString() & " disabled=disabled></td>"

        Return strDefaultComponents

    End Function

    '====================================================================
    ' Name       : strHabilitarEdicion
    ' Description: Regresa el HTML con los componentes habilitados
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strHabilitarEdicion() As String

        Dim strEnabled As String = ""

        Return strInterfazHTML.Replace("disabled=disabled", strEnabled)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Execute the selected command
        Select Case strCmd

            Case "EdiA"

                strGenerarInterfazInicial()

                ' Obtenemos el elemento
                Dim aobjData As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.strBuscarEmpresas(intEmpresaServicioId, "", "", 0, 0, "", False, False, CDate("01/01/1900"), strUsuarioNombre, 0, 0, strConnectionString)

                ' Si el elemento fue encontrado
                If IsNothing(aobjData) = False AndAlso aobjData.Length > 0 Then

                    Dim aobjRow As System.Collections.SortedList = DirectCast(aobjData.GetValue(0), System.Collections.SortedList)

                    ' Recuperamos sus datos
                    strEmpresaServicioNombre = CStr(aobjRow.Item("strEmpresaServicioNombre"))

                End If


            Case "AgregarDato"

                'Agregar Tipo de Dato a EmpresaServicioFormato
                Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioFormato.intAgregarDatoPorDefecto(intEmpresaServicioId, intEmpresaServicioTipoDatoFormatoId, "Descripción", 0, 0, True, False, False, True, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                'Generar la Interfaz HTML
                strGenerarInterfazInicial()

            Case "Habilitar"

                strGenerarInterfazInicial()
                strInterfazHTML = strHabilitarEdicion()

            Case "Salvar"

                Dim Row As Integer = 0

                'Recorrer por cada dato del formato
                While Row < intRowCounter

                    'Índice para comenzar a leer datos adicionales
                    Dim Column As Integer = 10

                    'Obtener los datos obligatorios del primer tipo de dato
                    intEmpresaServicioFormatoId = CInt(Request.Form("txt" & Row & "0"))
                    'Aplica
                    If Request.Form("chk" & Row & "1") = "on" Then
                        blnEmpresaServicioFormatoAplica = True
                    Else
                        blnEmpresaServicioFormatoAplica = False
                    End If
                    'Confirmar
                    If Request.Form("chk" & Row & "2") = "on" Then
                        blnEmpresaServicioFormatoConfirmacionPOS = True
                    Else
                        blnEmpresaServicioFormatoConfirmacionPOS = False
                    End If
                    'Solicitar
                    If Request.Form("chk" & Row & "3") = "on" Then
                        blnEmpresaServicioFormatoSolicitarCapturaManual = True
                    Else
                        blnEmpresaServicioFormatoSolicitarCapturaManual = False
                    End If
                    'Recapturar
                    If Request.Form("chk" & Row & "4") = "on" Then
                        blnEmpresaServicioFormatoSolicitarRecaptura = True
                    Else
                        blnEmpresaServicioFormatoSolicitarRecaptura = False
                    End If
                    strEmpresaServicioFormatoDescripcion = Request.Form("txt" & Row & "5")
                    strEmpresaServicioTipoDatoFormatoNombre = Request.Form("txt" & Row & "7")
                    intEmpresaServicioFormatoLongitud = CInt(Request.Form("txt" & Row & "8"))
                    intEmpresaServicioFormatoPosicion = CInt(Request.Form("txt" & Row & "9"))

                    'Obtenemos el ID del Tipo de Dato
                    Dim aobjTipos As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioTipoDatoFormato.strBuscarDatosFormato(0, strEmpresaServicioTipoDatoFormatoNombre, "", CDate("01/01/1900"), "", 0, 0, strConnectionString)

                    ' Si se encontraron elementos
                    If IsNothing(aobjTipos) = False AndAlso aobjTipos.Length > 0 Then

                        Dim aobjRow As System.Collections.SortedList = DirectCast(aobjTipos.GetValue(0), System.Collections.SortedList)

                        intEmpresaServicioTipoDatoFormatoId = CInt(aobjRow.Item("intEmpresaServicioTipoDatoFormatoId"))

                    End If

                    'Actualizar datos obligatorios
                    Dim intReturnValue As Integer = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioFormato.intActualizarDato(intEmpresaServicioFormatoId, intEmpresaServicioId, intEmpresaServicioTipoDatoFormatoId, strEmpresaServicioFormatoDescripcion, intEmpresaServicioFormatoLongitud, intEmpresaServicioFormatoPosicion, blnEmpresaServicioFormatoConfirmacionPOS, blnEmpresaServicioFormatoSolicitarCapturaManual, blnEmpresaServicioFormatoSolicitarRecaptura, blnEmpresaServicioFormatoAplica, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                    'Actualizar datos adicionales
                    If intReturnValue > 0 Then

                        'Buscamos el número de componentes adicionales del Tipo de Dato
                        Dim aobjTiposDatoAdicionales As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioTipoDatoAdicionalFormato.strBuscarDatosAdicionales(0, intEmpresaServicioTipoDatoFormatoId, "", "", CDate("01/01/1900"), "", 0, 0, strConnectionString)
                        Dim intDatosAdicionales As Integer
                        Dim intDatosAdicionalesPointer As Integer

                        ' Si se encontraron elementos
                        If IsNothing(aobjTiposDatoAdicionales) = False AndAlso aobjTiposDatoAdicionales.Length > 0 Then
                            intDatosAdicionales = aobjTiposDatoAdicionales.Length
                        Else
                            intDatosAdicionales = 0
                        End If

                        'Leer el valor de cada dato adicional según su componente
                        For intDatosAdicionalesPointer = 1 To intDatosAdicionales

                            Dim strArray As String()
                            strArray = Request.Form("txt" & Row & Column + 1).Split(CChar("|"))

                            'Obtenemos el nombre del dato adicional
                            strEmpresaServicioDatoAdicionalFormatoNombre = CStr(strArray(0))
                            'Obtenemos el tipo de Componente
                            strEmpresaServicioTipoDatoAdicionalFormatoComponente = CStr(strArray(1))

                            Select Case strEmpresaServicioTipoDatoAdicionalFormatoComponente

                                Case "CHK"

                                    'Obtenemos el valor del dato adicional
                                    Dim strCHKValue As String

                                    If Request.Form("chk" & Row & Column) = "on" Then
                                        strCHKValue = "1"
                                    Else
                                        strCHKValue = "0"
                                    End If

                                    strEmpresaServicioDatoAdicionalFormatoValor = strCHKValue

                                Case "TXT"

                                    'Obtenemos el valor del dato adicional
                                    strEmpresaServicioDatoAdicionalFormatoValor = Request.Form("txt" & Row & Column)

                                Case "TXTINT"

                                    'Obtenemos el valor del dato adicional
                                    strEmpresaServicioDatoAdicionalFormatoValor = Request.Form("txt" & Row & Column)


                                Case "TXTFLT"

                                    'Obtenemos el valor del dato adicional
                                    strEmpresaServicioDatoAdicionalFormatoValor = Request.Form("txt" & Row & Column)


                                Case "CBODATEFORMAT"

                                    'Obtenemos el valor del dato adicional
                                    strEmpresaServicioDatoAdicionalFormatoValor = Request.Form("cbo" & Row & Column)


                            End Select

                            'Actualizar dato adicional
                            Benavides.CC.Business.clsConcentrador.clsSucursal.clsEmpresaServicio.clsEmpresaServicioDatoAdicionalFormato.intActualizarDatoAdicional(intEmpresaServicioFormatoId, strEmpresaServicioDatoAdicionalFormatoNombre, strEmpresaServicioDatoAdicionalFormatoValor, CDate("01/01/1900"), strUsuarioNombre, strConnectionString)

                            Column = Column + 2

                        Next intDatosAdicionalesPointer

                    End If

                    Row = Row + 1

                End While

                Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

            Case "Regresar"

                Response.Redirect("SucursalEmpresasServiciosAdministrarEmpresas.aspx")

        End Select
    End Sub

End Class
