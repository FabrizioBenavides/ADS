Imports Isocraft.Web.Http

'====================================================================
' Class         : clsVentasProductosComplementariosConsultar
' Title         : VentasProductosComplementariosConsultar
' Description   : En esta parte usted puede consultar los productos que cuentan con artículos complementarios
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : First name Last name (account@isocraft.com)
' Last Modified : Wednesday, September 28, 2005
'====================================================================

Public Class clsVentasProductosComplementariosConsultar
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

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Initialize class properties
        strtxtArticuloDescripcion = GetPageParameter("txtArticuloDescripcion", "")
        strtxtArticuloEncontrado = GetPageParameter("txtArticuloEncontrado", "")
        intProducto = GetPageParameter("optProducto", 0)
        intArticuloId = GetPageParameter("intArticuloId", 0)

    End Sub

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


#Region " Class Private Attributes"

    Private intmProducto As Integer
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtArticuloDescripcion As String
    Private strmtxtArticuloEncontrado As String
    Private intmArticuloId As Integer

#End Region

    '====================================================================
    ' Name       : intProducto
    ' Description: Nombre del usuario actual
    ' Accessor   : Read/Write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intProducto() As Integer
        Get
            Return intmProducto
        End Get
        Set(ByVal intValue As Integer)
            intmProducto = intValue
        End Set
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
    ' Name       : strtxtArticuloDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloDescripcion() As String
        Get
            Return strmtxtArticuloDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strtxtArticuloEncontrado
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloEncontrado() As String
        Get
            Return strmtxtArticuloEncontrado
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloEncontrado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property intArticuloId() As Integer
        Get
            Return intmArticuloId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerProductosConArticulosComplementarios
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerProductosConArticulosComplementarios() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasProductosComplementariosConsultar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Data.clsArticulo.aobjObtenerArticulosConArticulosComplementarios(intArticuloId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
                                     "?"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las variables locales
        Dim aobjData As Array = Nothing
        Dim objRow As System.Collections.SortedList = Nothing

        ' Execute the selected command
        Select Case strCmd

            Case "Ver"

                Call Response.Redirect("VentasProductosComplementariosDetalle.aspx?strCmd=Ver&intArticuloId=" & intArticuloId)

            Case "Agregar"

                Call Response.Redirect("VentasProductosComplementariosAgregar.aspx?strCmd=Agregar&intArticuloId=" & intArticuloId)

            Case "Editar"

                Call Response.Redirect("VentasProductosComplementariosAgregar.aspx?strCmd=Registrar&strOrigen=Editar&intArticuloId=" & intArticuloId)

            Case "Eliminar"

                ' Si el identificador del artículo es válido
                If intArticuloId > 0 Then

                    ' Buscamos los articulos complementarios del artículo seleccionado
                    aobjData = Benavides.CC.Data.clstblArticuloComplementario.strBuscar(intArticuloId, 0, 0, "", #1/1/2000#, 0, 0, strConnectionString)

                    ' Si encontramos artículos complementarios
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Leemos las tiendas
                        Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si la dirección IP del concentrador es correcta y existen tiendas a quienes enviar la información
                        If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                            ' Enviamos los datos hacia los servidores de los puntos de venta
                            Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblArticuloComplementario", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "POS", aobjData, objStoresArray)

                        End If


                    End If

                    ' Por cada artículo complementario existente
                    For Each objRow In aobjData

                        ' Eliminamos su información de la base de datos
                        Call Benavides.CC.Data.clstblArticuloComplementario.intEliminar(intArticuloId, CInt(objRow.Item("intArticuloComplementarioId")), 0, strUsuarioNombre, Now(), strConnectionString)

                    Next

                End If

                ' Reiniciamos el valor del identificador del artículo
                intArticuloId = 0

            Case "Consultar"

                ' Si el identificador del artículo es válido
                If intArticuloId > 0 Then

                    ' Buscamos la información del artículo
                    aobjData = Benavides.CC.Data.clstblArticulo.strBuscar(intArticuloId, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, "", "", "", "", 0, 0, 0, "", 0, 0, "", #1/1/2000#, 0, 0, strConnectionString)

                    ' Si encontramos la información del artículo
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Actualizamos los campos de la forma
                        strtxtArticuloDescripcion = CStr(intArticuloId)
                        strtxtArticuloEncontrado = CStr(DirectCast(aobjData.GetValue(0), Array).GetValue(8))

                    End If

                End If

        End Select

    End Sub

End Class
