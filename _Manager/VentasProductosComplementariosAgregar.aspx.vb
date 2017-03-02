Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsVentasProductosComplementariosAgregar
' Title         : Isocraft. Grupo Benavides. Encuestas POST
' Description   : Data maintenance classes
' Copyright     : (c) Isocraft 2005 - 2010. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquin Hdz. G. (joaquin@isocraft.com)
' Last Modified : Wednesday, September 28, 2005
'====================================================================

Public Class clsVentasProductosComplementariosAgregar
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
        strtxtArticuloComplementarioDescripcion = GetPageParameter("txtArticuloComplementarioDescripcion", "")
        strtxtArticuloEncontrado = GetPageParameter("txtArticuloEncontrado", "")
        strtxtArticuloComplementarioEncontrado = GetPageParameter("txtArticuloComplementarioEncontrado", "")
        intArticuloId = GetPageParameter("intArticuloId", 0)
        intArticuloComplementarioId = GetPageParameter("intArticuloComplementarioId", 0)
        intArticuloComplementarioSeleccionadoId = GetPageParameter("intArticuloComplementarioSeleccionadoId", 0)

    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String
    Private strmtxtArticuloDescripcion As String
    Private strmtxtArticuloComplementarioDescripcion As String
    Private strmtxtArticuloEncontrado As String
    Private strmtxtArticuloComplementarioEncontrado As String
    Private intmArticuloId As Integer
    Private intmArticuloComplementarioId As Integer
    Private intmArticuloComplementarioSeleccionadoId As Integer

#End Region
    '====================================================================
    ' Name       : strtxtArticuloComplementarioEncontrado
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloComplementarioEncontrado() As String
        Get
            Return strmtxtArticuloComplementarioEncontrado
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloComplementarioEncontrado = strValue
        End Set
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
    ' Name       : strAgre
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strOrigen() As String
        Get
            Return GetPageParameter("strOrigen", "")
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
    ' Name       : strtxtArticuloComplementarioDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strtxtArticuloComplementarioDescripcion() As String
        Get
            Return strmtxtArticuloComplementarioDescripcion
        End Get
        Set(ByVal strValue As String)
            strmtxtArticuloComplementarioDescripcion = strValue
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
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloComplementarioId() As Integer
        Get
            Return intmArticuloComplementarioId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloComplementarioId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
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
    ' Name       : intArticuloComplementarioSeleccionadoId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public Property intArticuloComplementarioSeleccionadoId() As Integer
        Get
            Return intmArticuloComplementarioSeleccionadoId
        End Get
        Set(ByVal intValue As Integer)
            intmArticuloComplementarioSeleccionadoId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strObtenerProductosComplementariosDeUnArticulo
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strObtenerProductosComplementariosDeUnArticulo() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 50
        Const strRecordBrowserName As String = "VentasProductosComplementariosAgregar"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Data.clsArticulo.aobjObtenerArticulosComplementariosDeUnArticulo(intArticuloId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
                                     "?txtArticuloDescripcion=" & strtxtArticuloDescripcion & _
                                     "&txtArticuloEncontrado=" & strtxtArticuloEncontrado & _
                                     "&intArticuloId=" & intArticuloId & _
                                     "&intArticuloComplementarioId=" & intArticuloComplementarioId & _
                                     "&strOrigen=" & strOrigen & _
                                     "&"

        '"&intPagina=" & GetPageParameter("intNavegadorRegistrosPagina", 1) & _

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Declaramos las variables locales
        Dim aobjData As Array = Nothing
        Dim objRow As System.Collections.SortedList = Nothing
        Dim intArticuloComplementarioAnteriorId As Integer = 0
        Dim intArticuloComplementarioAnteriorOrden As Integer = 0
        Dim intArticuloComplementarioActualId As Integer = 0
        Dim intArticuloComplementarioActualOrden As Integer = 0
        Dim blnIntercambiarOrdenArticulos As Boolean = False
        Dim intCounter As Integer = 0
        Dim strArticuloEncontrado As String = ""


        ' Execute the selected command
        Select Case strCmd

            Case "Registrar"

                ' Si se cuenta con la clave del articulo padre
                If intArticuloId > 0 Then

                    ' Obtenemos la descripcion del articulo seleccionado
                    aobjData = Benavides.CC.Data.clstblArticulo.strBuscar(intArticuloId, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, "", "", "", "", 0, 0, 0, "", 0, 0, "", Now(), 0, 0, strConnectionString)

                    ' Si encontramos informacion
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Asignamos la descripcion del artículo 
                        strtxtArticuloEncontrado = CStr(DirectCast(aobjData.GetValue(0), Array).GetValue(8))
                        strtxtArticuloDescripcion = CStr(DirectCast(aobjData.GetValue(0), Array).GetValue(0))

                    End If

                End If


            Case "Limpiar"

                ' Limpiamos el contenido (campos) de la forma
                strtxtArticuloDescripcion = ""
                strtxtArticuloComplementarioDescripcion = ""
                strtxtArticuloEncontrado = ""
                strtxtArticuloComplementarioEncontrado = ""
                intArticuloId = 0
                intArticuloComplementarioId = 0

            Case "Subir"

                ' Establecemos el contador de posiciones
                intCounter = 1

                ' Si los identificadores de los artículos son válidos
                If intArticuloId > 0 AndAlso intArticuloComplementarioSeleccionadoId > 0 Then

                    ' Buscamos el artículo complementario como hijo del artículo padre
                    aobjData = Benavides.CC.Data.clsArticulo.aobjObtenerArticulosComplementariosDeUnArticulo(intArticuloId, 0, 0, strConnectionString)

                    ' Si encontramos información
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Por cada artículo complementario del artículo padre
                        For Each objRow In aobjData

                            ' Obtenemos el artículo complementario actual
                            intArticuloComplementarioActualId = CInt(objRow.Item("intArticuloComplementarioId"))
                            intArticuloComplementarioActualOrden = CInt(objRow.Item("intArticuloComplementarioOrden"))

                            ' Si intentamos subir el elemento y este ya se encuentra en la primera posición
                            If aobjData.Length = 1 AndAlso intArticuloComplementarioActualId = intArticuloComplementarioSeleccionadoId Then

                                ' Terminamos el proceso
                                Exit For

                            End If

                            ' Indicamos que hemos localizado el artículo seleccionado, si hemos llegado a él
                            If intArticuloComplementarioActualId = intArticuloComplementarioSeleccionadoId Then

                                ' Si la información del artículo anterior al seleccionado ya fue obtenida
                                If intArticuloComplementarioAnteriorId > 0 Then

                                    ' Subimos el artículo seleccionado
                                    Call Benavides.CC.Data.clstblArticuloComplementario.intActualizar(intArticuloId, intArticuloComplementarioActualId, intArticuloComplementarioAnteriorOrden, strUsuarioNombre, Now(), strConnectionString)

                                    ' Bajamos el artículo anterior
                                    Call Benavides.CC.Data.clstblArticuloComplementario.intActualizar(intArticuloId, intArticuloComplementarioAnteriorId, intArticuloComplementarioActualOrden, strUsuarioNombre, Now(), strConnectionString)

                                    ' Terminamos el proceso
                                    Exit For

                                End If

                            End If

                            ' Almacenamos el identificador del artículo actual
                            intArticuloComplementarioAnteriorId = intArticuloComplementarioActualId
                            intArticuloComplementarioAnteriorOrden = intArticuloComplementarioActualOrden

                            ' Incrementamos el contador de posiciones
                            intCounter += 1

                        Next

                    End If

                End If

            Case "Bajar"

                ' Establecemos el contador de posiciones
                intCounter = 1

                ' Si los identificadores de los artículos son válidos
                If intArticuloId > 0 AndAlso intArticuloComplementarioSeleccionadoId > 0 Then

                    ' Buscamos el artículo complementario como hijo del artículo padre
                    aobjData = Benavides.CC.Data.clsArticulo.aobjObtenerArticulosComplementariosDeUnArticulo(intArticuloId, 0, 0, strConnectionString)

                    ' Si encontramos información
                    If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                        ' Por cada artículo complementario del artículo padre
                        For Each objRow In aobjData

                            ' Obtenemos el artículo complementario actual
                            intArticuloComplementarioActualId = CInt(objRow.Item("intArticuloComplementarioId"))
                            intArticuloComplementarioActualOrden = CInt(objRow.Item("intArticuloComplementarioOrden"))

                            ' Si intentamos bajar el elemento y este ya se encuentra en la última posición
                            If aobjData.Length = intCounter AndAlso intArticuloComplementarioActualId = intArticuloComplementarioSeleccionadoId Then

                                ' Terminamos el proceso
                                Exit For

                            End If

                            ' Indicamos que hemos localizado el artículo seleccionado, si hemos llegado a él
                            If intArticuloComplementarioActualId = intArticuloComplementarioSeleccionadoId Then

                                blnIntercambiarOrdenArticulos = True

                            Else

                                ' Si ya hemos obtenido la información del siguiente artículo del artículo seleccionado
                                If blnIntercambiarOrdenArticulos = True AndAlso intArticuloComplementarioAnteriorId > 0 Then

                                    ' Subimos el artículo siguiente
                                    Call Benavides.CC.Data.clstblArticuloComplementario.intActualizar(intArticuloId, intArticuloComplementarioActualId, intArticuloComplementarioAnteriorOrden, strUsuarioNombre, Now(), strConnectionString)

                                    ' Bajamos el artículo seleccionado
                                    Call Benavides.CC.Data.clstblArticuloComplementario.intActualizar(intArticuloId, intArticuloComplementarioAnteriorId, intArticuloComplementarioActualOrden, strUsuarioNombre, Now(), strConnectionString)

                                    ' Terminamos el proceso
                                    Exit For

                                End If

                            End If

                            ' Almacenamos el identificador del artículo actual
                            intArticuloComplementarioAnteriorId = intArticuloComplementarioActualId
                            intArticuloComplementarioAnteriorOrden = intArticuloComplementarioActualOrden

                            ' Incrementamos el contador de posiciones
                            intCounter += 1

                        Next

                    End If

                End If

            Case "Eliminar"

                ' Si el identificador del artículo es válido
                If intArticuloId > 0 AndAlso intArticuloComplementarioSeleccionadoId > 0 Then

                    ' Buscamos los articulos complementarios del artículo seleccionado
                    aobjData = Benavides.CC.Data.clstblArticuloComplementario.strBuscar(intArticuloId, intArticuloComplementarioSeleccionadoId, 0, "", #1/1/2000#, 0, 0, strConnectionString)

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

                    ' Eliminamos su información de la base de datos
                    Call Benavides.CC.Data.clstblArticuloComplementario.intEliminar(intArticuloId, intArticuloComplementarioSeleccionadoId, 0, strUsuarioNombre, Now(), strConnectionString)

                End If

            Case "Salvar"

                ' Adición de un nuevo artículo complementario
                intCounter = 2

                ' Si los identificadores de los artículos son válidos
                If intArticuloId > 0 AndAlso intArticuloComplementarioId > 0 Then

                    ' Buscamos el artículo complementario como hijo del artículo padre
                    aobjData = Benavides.CC.Data.clstblArticuloComplementario.strBuscar(intArticuloId, intArticuloComplementarioId, 0, "", #1/1/2000#, 0, 0, strConnectionString)

                    ' Si no encontramos información
                    If IsArray(aobjData) = False OrElse (IsArray(aobjData) = True AndAlso aobjData.Length = 0) Then

                        ' Obtenemos todos los artículos complementarios del artículo padre
                        aobjData = Benavides.CC.Data.clsArticulo.aobjObtenerArticulosComplementariosDeUnArticulo(intArticuloId, 0, 0, strConnectionString)

                        ' Si encontramos artículos complementarios
                        If IsArray(aobjData) = True AndAlso aobjData.Length > 0 Then

                            ' Por cada artículo complementario del artículo padre
                            For Each objRow In aobjData

                                ' Incrementamos su orden en 1
                                Call Benavides.CC.Data.clstblArticuloComplementario.intActualizar(intArticuloId, CInt(objRow.Item("intArticuloComplementarioId")), intCounter, strUsuarioNombre, Now(), strConnectionString)
                                intCounter += 1

                            Next

                        End If

                        ' Agregamos el nuevo artículo complementario
                        Call Benavides.CC.Data.clstblArticuloComplementario.intAgregar(intArticuloId, intArticuloComplementarioId, 1, strUsuarioNombre, Now(), strConnectionString)

                    End If

                End If

                ' Limpiamos el contenido (campos) de la forma
                strtxtArticuloComplementarioDescripcion = ""
                strtxtArticuloComplementarioEncontrado = ""
                intArticuloComplementarioId = 0


        End Select

    End Sub

End Class
