Imports Benavides.POSAdmin.Commons
Imports System.Text
'====================================================================
' Class         : clsSucursalDetalleBrincosFoliosContables
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Consultar detalle de brincos en folios contables
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Armando Calzada Mezura
' Version       : 1.0
' Last Modified : Monday, July 22, 2004
'====================================================================
Public Class clsSucursalDetalleBrincosFoliosContables
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

    ' Variables locales privadas
    Private strmFechaInicial As String
    Private strmFechaFinal As String
    Private strmFolioNombre As String
    Private intmTotalBrincos As Integer

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

    '====================================================================
    ' Name       : strFolioNombre
    ' Description: Total de brincos
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strFolioNombre() As String
        Get
            Return strmFolioNombre
        End Get
        Set(ByVal strValue As String)
            strmFolioNombre = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTotalBrincos
    ' Description: Total de brincos
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property intTotalBrincos() As Integer
        Get
            Return intmTotalBrincos
        End Get
        Set(ByVal intValue As Integer)
            intmTotalBrincos = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strFolioNombreId
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFolioNombreId() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("strFolioNombreId", "")
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
    ' Name       : strHTMLAlcance
    ' Description: Generar el HTML de las fechas de consulta
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLAlcance() As String
        Get
            Return "Del " & Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(strFechaInicial) & " al " & Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(strFechaFinal)
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
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

    Private Function strComplete2Digit(ByVal strValue As String) As String
        If Len(strValue) = 1 Then
            Return "0" & strValue
        Else
            Return strValue
        End If
    End Function

    '====================================================================
    ' Name       : strFoliosFaltantesHTML
    ' Description: Regresa el HTML de los folios faltantes
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFoliosFaltantesHTML() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strDataArray As String()
            Dim strbldFoliosFaltantesHTML As StringBuilder
            Dim astrDataArray As Array = Nothing
            Dim intContadorRegistros As Integer

            ' Variables para el control del despliegue
            Dim intFolioCompaniaId As Integer
            Dim intFolioSucursalId As Integer
            Dim intConsecutivo As Integer

            ' Obtenemos el rango de fechas
            Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
            Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

            ' Inicializamos el StringBuilder
            strbldFoliosFaltantesHTML = New StringBuilder

            Select Case strFolioNombreId
                Case "ComprasDirectas"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesCompraDirecta(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "Devoluciones"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesDevolucion(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "FacturaElectronica"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesFacturaElectronica(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "InventarioAgotado"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesInventarioAgotado(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "InventarioNegado"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesInventarioNegado(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "InventarioSugerido"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesInventarioSugerido(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "Mermas"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesMerma(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "Reclamaciones"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesReclamacion(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "RemisionElectronica"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesRemisionElectronica(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "TransferenciasCanceladas"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesTransferenciaCancelada(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "TransferenciasEnviadas"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesTransferenciaEnviada(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "TransferenciasInternas"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesTransferenciaInterna(dtmFechaInicial, dtmFechaFinal, strConnectionString)
                Case "TransferenciasRecibidas"
                    astrDataArray = Benavides.CC.Data.clsFolio.strEjecutarBuscarFoliosFaltantesTransferenciaRecibida(dtmFechaInicial, dtmFechaFinal, strConnectionString)
            End Select

            ' Generamos el listado de folios faltantes
            If IsArray(astrDataArray) AndAlso (astrDataArray.Length > 0) Then

                intFolioCompaniaId = 0
                intFolioSucursalId = 0
                intConsecutivo = 1

                ' Recuperamos los registros
                For Each strDataArray In astrDataArray

                    If (intFolioSucursalId <> CInt(strDataArray(1))) OrElse (intFolioCompaniaId <> CInt(strDataArray(0))) Then

                        ' Tomo las variables actuales 
                        intFolioCompaniaId = CInt(strDataArray(0))
                        intFolioSucursalId = CInt(strDataArray(1))

                        ' Si no es el primer registro
                        If (intConsecutivo > 1) Then
                            strbldFoliosFaltantesHTML.Append("</table>")
                            strbldFoliosFaltantesHTML.Append("<table width=""60%""  border=""0"" cellspacing=""0"" cellpadding=""0"">")
                        Else
                            strbldFoliosFaltantesHTML.Append("<table width=""60%""  border=""0"" cellspacing=""0"" cellpadding=""0"">")
                        End If

                        strbldFoliosFaltantesHTML.Append("<tr><td width=""46%"" class=""tdtexttablebold"">[" & intConsecutivo & "] Sucursal " & strDataArray(1) & " " & strDataArray(2) & "</td></tr>")
                        strbldFoliosFaltantesHTML.Append("<tr><td class=""tdcontentableblue"">&gt; Folio " & strDataArray(3) & " </td></tr>")

                        intConsecutivo = intConsecutivo + 1
                    Else
                        strbldFoliosFaltantesHTML.Append("<tr><td class=""tdcontentableblue"">&gt; Folio " & strDataArray(3) & " </td></tr>")
                    End If

                Next

                ' Si se abrió una tabla
                If (intConsecutivo >= 1) Then
                    strbldFoliosFaltantesHTML.Append("</table>")
                End If

            End If

            Return clsCommons.strGenerateJavascriptString(strbldFoliosFaltantesHTML.ToString)

        End Get

    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Obtenemos el rango de fechas
        Dim dtmFechaInicial As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaInicial))
        Dim dtmFechaFinal As Date = CDate(Benavides.POSAdmin.Commons.clsCommons.strDMYtoMDY(strFechaFinal))

        ' Buscamos el nombre del folio y la cantidad de brincos
        Dim astrDataArray As Array = Benavides.CC.Data.clsFolio.strEjecutarBuscarBrincosFoliosContables(dtmFechaInicial, dtmFechaFinal, strConnectionString)
        Dim strDataArray As String()

        ' Recuperamos los registros
        For Each strDataArray In astrDataArray
            If strFolioNombreId.Equals(CStr(strDataArray.GetValue(2))) Then
                strFolioNombre = strDataArray(1)
                intTotalBrincos = CInt(strDataArray(3))
            End If
        Next

    End Sub

End Class
