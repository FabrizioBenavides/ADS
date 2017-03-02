'====================================================================
' Class         : clsSucursalAgregarEstadoOperativoCaja
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Agregar estados operativos de cajas
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Mario C. Menchaca Salgado
' Version       : 1.0
' Last Modified : Thursday, July 22, 2004
'====================================================================
Public Class clsSucursalAgregarEstadoOperativoCaja
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private strmNombreEstado As String
    Private strmNombreIdEstado As String
    Private strmOrdenEstado As String

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

    '====================================================================
    ' Name       : intEstadoOperativoCajaId
    ' Description: Obtiene el valor del campo "txtEstadoOperativoCajaId"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intEstadoOperativoCajaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intEstadoOperativoCajaId", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : strEstadoOperativoCajaNombre
    ' Description: Obtiene el valor del campo "txtEstadoOperativoCajaNombre"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEstadoOperativoCajaNombre() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtEstadoOperativoCajaNombre", "")
        End Get
    End Property

    '====================================================================
    ' Name       : strEstadoOperativoCajaNombreId
    ' Description: Obtiene el valor del campo "txtEstadoOperativoCajaNombreId"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strEstadoOperativoCajaNombreId() As String
        Get
            Return isocraft.commons.clsWeb.strGetPageParameter("txtEstadoOperativoCajaNombreId", "")
        End Get
    End Property

    '====================================================================
    ' Name       : intEstadoOperativoCajaOrden
    ' Description: Obtiene el valor del campo "txtEstadoOperativoCajaOrden"
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intEstadoOperativoCajaOrden() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("txtEstadoOperativoCajaOrden", "0"))
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
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strHTMLFechaHora() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")
        End Get
    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: URL de esta página
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
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
    ' Throws     : Ninguna
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
    ' Name       : strNombreEstado 
    ' Description: Obtiene o establece el nombre del estado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombreEstado() As String
        Get
            Return strmNombreEstado
        End Get
        Set(ByVal strValue As String)
            strmNombreEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strNombreIdEstado 
    ' Description: Obtiene o establece el identificador interno del estado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strNombreIdEstado() As String
        Get
            Return strmNombreIdEstado
        End Get
        Set(ByVal strValue As String)
            strmNombreIdEstado = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strOrdenEstado 
    ' Description: Obtiene o establece el orden de utilización del estado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strOrdenEstado() As String
        Get
            Return strmOrdenEstado
        End Get
        Set(ByVal strValue As String)
            strmOrdenEstado = strValue
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Variable para almacenar los resultados
        Dim intResultado As Integer

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")

        ' Ejecutamos el comando indicado
        Select Case strCmd
            Case "Agregar"
                'Validar que el Orden de utilización no haya sido previamente usado
                Dim astrDataArray As Array = Benavides.CC.Data.clstblEstadoOperativoCaja.strBuscar(0, "", "", 0, Now(), "", 0, 0, strConnectionString)
                Dim intContadorArreglo As Integer
                Dim blnFlagUsado As Boolean = False

                For intContadorArreglo = 0 To astrDataArray.Length - 1
                    If intEstadoOperativoCajaOrden = CInt(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(3)) Then
                        blnFlagUsado = True
                    End If

                    If blnFlagUsado Then
                        intResultado = Benavides.CC.Data.clstblEstadoOperativoCaja.intActualizar(CInt(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(0)), CStr(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(1)), CStr(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(2)), CInt(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(3)) + 1, Now(), strUsuarioNombre, strConnectionString)
                    End If
                Next

                ' Agregamos el formato
                intResultado = Benavides.CC.Data.clstblEstadoOperativoCaja.intAgregar(0, strEstadoOperativoCajaNombreId, strEstadoOperativoCajaNombre, intEstadoOperativoCajaOrden, Now(), strUsuarioNombre, strConnectionString)
                Call Response.Redirect("SucursalAdministrarEstadoOperativoCaja.aspx")

            Case "Modificar"
                'Validar que el Orden de utilización no haya sido previamente usado
                Dim astrDataArray As Array = Benavides.CC.Data.clstblEstadoOperativoCaja.strBuscar(0, "", "", 0, Now(), "", 0, 0, strConnectionString)
                Dim intContadorArreglo As Integer
                Dim blnFlagUsado As Boolean = False

                For intContadorArreglo = 0 To astrDataArray.Length - 1
                    If intEstadoOperativoCajaOrden = CInt(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(3)) Then
                        blnFlagUsado = True
                    End If

                    If blnFlagUsado Then
                        intResultado = Benavides.CC.Data.clstblEstadoOperativoCaja.intActualizar(CInt(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(0)), CStr(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(1)), CStr(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(2)), CInt(DirectCast(astrDataArray.GetValue(intContadorArreglo), Array).GetValue(3)) + 1, Now(), strUsuarioNombre, strConnectionString)
                    End If
                Next

                ' Modificamos el formato indicado
                intResultado = Benavides.CC.Data.clstblEstadoOperativoCaja.intActualizar(intEstadoOperativoCajaId, strEstadoOperativoCajaNombreId, strEstadoOperativoCajaNombre, intEstadoOperativoCajaOrden, Now(), strUsuarioNombre, strConnectionString)
                Call Response.Redirect("SucursalAdministrarEstadoOperativoCaja.aspx")

            Case "Editar"
                ' Consultamos la politica recibida
                Dim astrDataArray As Array = Benavides.CC.Data.clstblEstadoOperativoCaja.strBuscar(intEstadoOperativoCajaId, "", "", 0, Now(), "", 0, 0, strConnectionString)

                ' Verificamos la existencia de valores
                If IsArray(astrDataArray) AndAlso astrDataArray.Length > 0 Then

                    ' Obtenemos el nombre del estado
                    strNombreEstado = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(2))

                    ' Obtenemos el identificador del estado
                    strNombreIdEstado = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(1))

                    ' Obtenemos el orden del estado
                    strOrdenEstado = CStr(DirectCast(astrDataArray.GetValue(0), Array).GetValue(3))

                End If

        End Select

    End Sub

End Class
