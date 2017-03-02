Imports Isocraft.Web.Convert
Imports Isocraft.Web.Http
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Data
Imports Benavides.POSAdmin.Commons

'====================================================================
' Class         : SucursalProveedoresEditarArticulosAutorizados
' Title         :
' Description   :
' Copyright     : Sistemas Benavides 
' Company       : Farmacias Benavides
' Author        : J.Antonio Hernandez
' Last Modified : 01 Junio 2007
'====================================================================

Public Class SucursalProveedoresEditarArticulosAutorizados
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArticulosArchivo As System.Web.UI.HtmlControls.HtmlInputFile


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

    Const strComitasDobles As String = """"
    Private strmJavascriptWindowOnLoadCommands As String

    Private intmOpcAct As Integer


#End Region


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
    ' Name       : intFolioActualCarga 
    ' Description: Folio para importacion desde archivo
    ' Accessor   : Read
    ' Output     : Long
    '====================================================================
    Public ReadOnly Property lngFolioActualCarga() As Long
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("hdnFolioActualCarga"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CLng(strTemporal)
            End If

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
            Return Request("strCmd")
        End Get
    End Property

    '====================================================================
    ' Name       : intOpcAct
    ' Description: Value of a HTML form field
    ' Accessor   : Read / Write
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intOpcAct() As Integer
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("intOpcAct"))

            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If

        End Get
    End Property

    Public ReadOnly Property intProveedorDestinoId() As Integer
        Get
            Return CInt(Request("intProveedorDestinoId"))
        End Get

    End Property

    Public ReadOnly Property strProveedorDestinoNombreId() As String
        Get
            Return Request("strProveedorDestinoNombreId")
        End Get
    End Property

    Public ReadOnly Property strProveedorDestinoRazonSocial() As String
        Get
            Return Request("strProveedorDestinoRazonSocial")
        End Get
    End Property


    Public ReadOnly Property intProveedorId() As Integer
        Get
            Return CInt(Request("hdnProveedorId"))
        End Get

    End Property

    Public ReadOnly Property strProveedorNombreId() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtProveedorNombreId"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If

        End Get
    End Property

    Public ReadOnly Property strProveedorRazonSocial() As String
        Get
            Dim strTemporal As String

            strTemporal = Trim(Request("txtProveedorRazonSocial"))

            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strConsultarArticulos
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strConsultarArticulos() As String

        ' Declaramos e inicializamos las constantes locales
        Const intElementsPerPage As Integer = 60
        Const strRecordBrowserName As String = "SucursalProveedoresConsultarArticulos"

        ' Generamos el URL destino de las páginas
        Dim strTargetURL As String = strThisPageName & _
        "?intproveedorDestinoId=" & intProveedorDestinoId.ToString & _
        "&strProveedorDestinoNombreId=" & strProveedorDestinoNombreId & _
        "&strProveedorDestinoRazonSocial=" & strProveedorDestinoRazonSocial & _
        "&intOpcAct= " & intOpcAct.ToString & _
        "&txtProveedorNombreId=" & strProveedorNombreId & _
        "&txtProveedorRazonSocial=" & strProveedorRazonSocial & "&"

        ' Declaramos e inicializamos las variables locales
        Dim intSelectedPage As Integer = GetPageParameter("intNavegadorRegistrosPagina", 1)

        Dim objDataArrayProveedoresArticulos As Array = clsProveedor.strBuscarProveedorArticulosAutorizados(intProveedorDestinoId, Benavides.CC.Commons.clsRecordBrowser.clsIndicator.intCalculateFirstElement(intSelectedPage, intElementsPerPage), intElementsPerPage, strConnectionString)

        Return Benavides.CC.Commons.clsRecordBrowser.strGetHTML(strRecordBrowserName, objDataArrayProveedoresArticulos, intSelectedPage, intElementsPerPage, strTargetURL)


    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If intProveedorDestinoId < 0 Or Len(strProveedorDestinoNombreId) < 1 Or Len(strProveedorDestinoRazonSocial) < 1 Then

            Call Response.Redirect("SucursalProveedoresConsultar.aspx")

        End If


        Dim objArrayConsulta As Array = Nothing
        Dim strRegistroConsulta As String() = Nothing
        Dim intResultado As Integer
        Dim lngFolioCargaId As Long

        Dim strHTML As StringBuilder

        strHTML = New StringBuilder

        If lngFolioActualCarga < 1 Then
            lngFolioCargaId = Now.Ticks
        Else
            lngFolioCargaId = lngFolioActualCarga
        End If

        Select Case strCmd

            Case "BuscarProveedor"

                Dim objArrayProveedor As Array = Nothing
                Dim objRegistroProveedor As System.Collections.SortedList = Nothing

                Dim strBusquedaProveedorId As String = ""
                Dim strBusquedaProveedorNombreId As String = ""
                Dim strBusquedaProveedorRazonSocial As String = ""
                Dim strBusquedaProveedorRFC As String = ""
                Dim strBusquedaProveedorError As String = "-100"

                If IsNumeric(Mid(strProveedorNombreId, 1, 4)) Then

                    objArrayProveedor = clsProveedor.strBuscar("", strProveedorNombreId, 0, 0, strConnectionString)

                    If IsArray(objArrayProveedor) AndAlso objArrayProveedor.Length > 0 Then

                        objRegistroProveedor = DirectCast(objArrayProveedor.GetValue(0), System.Collections.SortedList)

                        ' Asignamos los datos del proveedor

                        strBusquedaProveedorId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("intProveedorId")))
                        strBusquedaProveedorNombreId = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorNombreId")))
                        strBusquedaProveedorRazonSocial = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRazonSocial")))
                        strBusquedaProveedorRFC = clsCommons.strFormatearDescripcion(CStr(objRegistroProveedor.Item("strProveedorRFC")))
                        strBusquedaProveedorError = "0"

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpBuscarProveedor( " & _
                               strComitasDobles & strBusquedaProveedorId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorNombreId & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRazonSocial & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorRFC & strComitasDobles & "," & _
                               strComitasDobles & strBusquedaProveedorError & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "PrevioArchivoArticulo"

                Dim intCargaArchivo As Integer = intCargarArchivoArticulos(lngFolioCargaId)

                strHTML.Append("<script language='Javascript'> parent.fnVerPrevioArchivo( " & _
                          strComitasDobles & intCargaArchivo.ToString & strComitasDobles & "," & _
                          strComitasDobles & lngFolioCargaId.ToString & strComitasDobles & _
                          "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarArticulo"

                Dim intContadorAlta As Integer = 0
                Dim intErrorAgregar As Integer = 0


                If intOpcAct = 1 Then ' Desde Archivo

                    Dim intCargaArchivo As Integer = intCargarArchivoArticulos(lngFolioCargaId)

                    If intCargaArchivo >= 0 Then
                        intContadorAlta = clsProveedor.intCargaProveedorArticulosAutorizados(lngFolioCargaId, intProveedorDestinoId, 0, strUsuarioNombre, strConnectionString)
                    Else
                        intErrorAgregar = intCargaArchivo ' Error desde la carga del archivo
                    End If

                End If '-- Final de la opcion de carga desde archivo


                If intOpcAct = 2 Then ' Desde otro proveedor

                    intContadorAlta += clsProveedor.intCopiarProveedorArticulosAutorizados(intProveedorId, intProveedorDestinoId, 0, strUsuarioNombre, strConnectionString)

                    If intContadorAlta < 0 Then

                        intErrorAgregar = -200 'No se pudo obtener datos del proveedor origen

                    End If


                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarArticulo( " & _
                           strComitasDobles & intErrorAgregar.ToString & strComitasDobles & "," & _
                           strComitasDobles & intContadorAlta.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "RemplazarArticulo"

                Dim intContadorAlta As Integer = 0
                Dim intErrorAgregar As Integer = 0


                If intOpcAct = 1 Then ' Desde Archivo

                    Dim intCargaArchivo As Integer = intCargarArchivoArticulos(lngFolioCargaId)

                    If intCargaArchivo >= 0 Then
                        intContadorAlta = clsProveedor.intCargaProveedorArticulosAutorizados(lngFolioCargaId, intProveedorDestinoId, 1, strUsuarioNombre, strConnectionString)
                    Else
                        intErrorAgregar = intCargaArchivo ' Error desde la carga del archivo
                    End If

                End If '-- Final de la opcion de carga desde archivo

                If intOpcAct = 2 Then ' Desde otro proveedor

                    intContadorAlta += clsProveedor.intCopiarProveedorArticulosAutorizados(intProveedorId, intProveedorDestinoId, 1, strUsuarioNombre, strConnectionString)

                    If intContadorAlta < 0 Then

                        intErrorAgregar = -200 'No se pudo obtener datos del proveedor origen

                    End If

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpAgregarArticulo( " & _
                           strComitasDobles & intErrorAgregar.ToString & strComitasDobles & "," & _
                           strComitasDobles & intContadorAlta.ToString & strComitasDobles & _
                           "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()


        End Select

    End Sub

    Function intCargarArchivoArticulos(ByVal lngFolioCargaId As Long) As Integer

        Dim intErrorCarga As Integer = 0
        Dim intContadorCarga As Integer = 0

        ' Obtenemos un arreglo con los renglones del archivo
        Dim objArchivoCarga As Array = CreateArrayFromCSVHttpPostedFile(txtArticulosArchivo.PostedFile)

        If IsNothing(objArchivoCarga) = False AndAlso objArchivoCarga.Length > 0 Then

            Dim dblArticuloArchivoId As Double = 0
            Dim dblArticuloAlta As Double = 0

            For Each astrColumns As Array In objArchivoCarga

                If astrColumns.Length = 1 Then ' Se lee si el renglón tiene el número de columnas adecuadas

                    ' Obtenemos el valor que vienen en el archivo
                    dblArticuloArchivoId = CDbl(ConvertObject(astrColumns.GetValue(0), TypeCode.Double))

                    If dblArticuloArchivoId > 0 Then 'Inicio busqueda articulo

                        ' Obtenemos la descripcion del articulo seleccionado
                        Dim objArrayDataArticulo As Array = clstblArticulo.strBuscar(CInt(dblArticuloArchivoId), 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", 0, "", "", "", "", 0, 0, 0, "", 0, 0, "", Now(), 0, 0, strConnectionString)

                        ' Si encontramos informacion
                        If IsArray(objArrayDataArticulo) = True AndAlso objArrayDataArticulo.Length > 0 Then
                            dblArticuloAlta = CDbl(DirectCast(objArrayDataArticulo.GetValue(0), Array).GetValue(0))
                        Else
                            dblArticuloAlta = 0
                        End If

                        If dblArticuloAlta > 0 Then ' Solo se pasa si el articulo existe en el catalogo

                            intContadorCarga += clsProveedor.intActualizarAgregarCargaProveedorArticulo(lngFolioCargaId, dblArticuloAlta, strConnectionString)

                        End If


                    End If '-- Final de busqueda de atticulo

                Else

                    intErrorCarga = -110 'El registro no tiene la estructura correcta


                End If '-- Final de lectura de registro

            Next

        Else

            intErrorCarga = -100 'No se pudo abrir el archivo a cargar

        End If

        If intErrorCarga < 0 Then
            Return intErrorCarga
        Else
            Return intContadorCarga
        End If


    End Function

End Class

