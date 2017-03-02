Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Imports System.Text
Imports System.Collections
Imports System.Configuration
Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Data
Imports Benavides.CC.Business

Public Class SucursalSenalizacionAdministracionMarcaPropia
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

#Region " Class Private Attributes"

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmArticuloMarcaPropiaId As String
    Private strmArticuloMarcaPropiaDescripcion As String
    Private strmArticuloMarcaLiderId As String
    Private strmArticuloMarcaLiderDescripcion As String
    
#End Region

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
    ' Name       : intMPoML
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intMPoML() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("hdnMPoML"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property
    '====================================================================
    ' Name       : strArticuloMarcaPropiaId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloMarcaPropiaId() As String
        Get
            Return strmArticuloMarcaPropiaId
        End Get
        Set(ByVal strValue As String)
            strmArticuloMarcaPropiaId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloMarcaPropiaDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloMarcaPropiaDescripcion() As String
        Get
            Return strmArticuloMarcaPropiaDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloMarcaPropiaDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloMarcaLiderId
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloMarcaLiderId() As String
        Get
            Return strmArticuloMarcaLiderId
        End Get
        Set(ByVal strValue As String)
            strmArticuloMarcaLiderId = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strArticuloMarcaLiderDescripcion
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strArticuloMarcaLiderDescripcion() As String
        Get
            Return strmArticuloMarcaLiderDescripcion
        End Get
        Set(ByVal strValue As String)
            strmArticuloMarcaLiderDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intArticuloMarcaPropiaId 
    ' Description: Numero de Articulo
    ' Accessor   : Read
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property intArticuloMarcaPropiaId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtMarcaPropia"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intArticuloMarcaLiderId 
    ' Description: Numero de Articulo
    ' Accessor   : Read
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property intArticuloMarcaLiderId() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtMarcaLider"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property


    '====================================================================
    ' Name       : strGetRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGetRecordBrowserHTML() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 100
        Const strRecordBrowserName As String = "SucursalMarcaPropia"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)
        Dim aobjDataArray As Array = Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.strBuscarParejas(0, 0, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & "?"

        ' Generamos el navegador de registros
        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, aobjDataArray, intSelectedPage, intElementsPerPage, strTargetURL)

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If

        Dim strHTML As StringBuilder

        ' Execute the selected command
        Select Case strCmd

            Case "BuscarArticulo"

                strHTML = New StringBuilder

                Dim strAccion As String = "0" ' BUSCAR ARTICULO
                Dim strErrorBuscaArticulo As String = ""

                Dim objArrayArticulo As Array = Nothing
                Dim strRegistroArticulo As String()

                Dim intArticuloBuscadoId As Integer = 0
                Dim strArticuloBuscadoDescripcion As String = ""

                If intMPoML = 0 Then
                    ' Obtenemos la información del Articulo Marca Propia
                    objArrayArticulo = Benavides.CC.Data.clstblArticulo.strBuscar(intArticuloMarcaPropiaId, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, "", "", "", "", 0, 0, 0, "", 0, 0, "", Now(), 0, 0, strConnectionString)


                Else
                    ' Obtenemos la información del Articulo Marca Lider
                    objArrayArticulo = Benavides.CC.Data.clstblArticulo.strBuscar(intArticuloMarcaLiderId, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, "", "", "", "", 0, 0, 0, "", 0, 0, "", Now(), 0, 0, strConnectionString)

                End If

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then
                    strRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), String())

                    intArticuloBuscadoId = CInt(strRegistroArticulo(0))
                    strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(strRegistroArticulo(8))
                    strErrorBuscaArticulo = "0"
                Else
                    intArticuloBuscadoId = 0
                    strArticuloBuscadoDescripcion = ""
                    strErrorBuscaArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarArticulo( " & _
                               strComitasDobles & strErrorBuscaArticulo & strComitasDobles & "," & _
                               strComitasDobles & intMPoML.ToString() & strComitasDobles & "," & _
                               strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                               strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Agregar"

                Dim intResultado As Integer
                strHTML = New StringBuilder

                ' Verificamos si están completos los datos
                If intArticuloMarcaPropiaId > 0 And intArticuloMarcaLiderId > 0 Then

                    ' Buscamos el registro
                    Dim aobjDataToSearch As Array = Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.strBuscar(0, intArticuloMarcaPropiaId, 0, Now(), "", 0, 0, strConnectionString)

                    ' Si el registro existe
                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then

                        Dim intSeñalizacionMarcaPropiaLideresId As Integer = CInt(DirectCast(aobjDataToSearch.GetValue(0), Array).GetValue(0))
                        ' Actualizamos el registro
                        intResultado = Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.intActualizar(intSeñalizacionMarcaPropiaLideresId, intArticuloMarcaPropiaId, intArticuloMarcaLiderId, Now(), strUsuarioNombre, strConnectionString)

                    Else

                        ' Agregamos el nuevo registro
                        intResultado = Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.intAgregar(0, intArticuloMarcaPropiaId, intArticuloMarcaLiderId, Now(), strUsuarioNombre, strConnectionString)

                    End If
                Else

                    intResultado = -100

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarActualizar ( " & _
                               strComitasDobles & intResultado.ToString & strComitasDobles & "," & _
                               strComitasDobles & "Agregar" & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "Editar"

                Dim intArticuloMarcaPropiaId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intArticuloMarcaPropiaId", "0"))
                Dim intResultado As Integer
                strHTML = New StringBuilder

                ' Verificamos si esta el identificador
                If intArticuloMarcaPropiaId > 0 Then

                    ' Buscamos el registro
                    Dim aobjDataToSearch As Array = Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.strBuscarParejas(0, intArticuloMarcaPropiaId, 0, 0, strConnectionString)

                    ' Si el registro existe
                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then

                        Dim objRecordList As SortedList
                        
                        For Each objRecordList In aobjDataToSearch
                            strArticuloMarcaPropiaId = CStr(objRecordList.Item("intArticuloMarcaPropiaId"))
                            strArticuloMarcaPropiaDescripcion = CStr(objRecordList.Item("strArticuloMarcaPropiaDescripcion"))
                            strArticuloMarcaLiderId = CStr(objRecordList.Item("intArticuloMarcaLiderId"))
                            strArticuloMarcaLiderDescripcion = CStr(objRecordList.Item("strArticuloMarcaLiderDescripcion"))
                        Next

                    End If

                End If

            Case "Eliminar"

                Dim intArticuloMarcaPropiaId As Integer = CInt(isocraft.commons.clsWeb.strGetPageParameter("intArticuloMarcaPropiaId", "0"))
                Dim intResultado As Integer

                ' Verificamos si esta el identificador
                If intArticuloMarcaPropiaId > 0 Then

                    ' Buscamos el registro
                    Dim aobjDataToSearch As Array = Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.strBuscar(0, intArticuloMarcaPropiaId, 0, Now(), "", 0, 0, strConnectionString)

                    ' Si el registro existe
                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then

                        ' Buscamos las tiendas
                        'Dim objStoresArray As Array = Benavides.CC.Data.clstblTienda.strBuscar(0, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                        ' Si las encontramos (tiendas)
                        'If IsArray(objStoresArray) = True AndAlso objStoresArray.Length > 0 Then

                        ' Enviamos los datos hacia los servidores de los puntos de venta
                        'Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeCompletoHaciaServidoresPuntoDeVenta("clstblSeñalizacionMarcaPropiaLideres", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "", aobjDataToSearch, objStoresArray)

                        ' Eliminamos su información de la base de datos
                        Call Benavides.CC.Business.clsConcentrador.clsSeñalizacionMarcaPropiaLideres.intEliminar(0, intArticuloMarcaPropiaId, 0, Now(), strUsuarioNombre, strConnectionString)

                        ' End If

                    End If

                End If

        End Select

    End Sub

End Class
