'====================================================================
' Class         : clsSucursalEditarPoliticaDePosDeUnaSucursal
' Title         : Grupo Benavides. Administrador POS y Backoffice.
' Description   : Editar política de POS de una sucursal
' Copyright     : 2003-2006 All rights reserved.
' Company       : Isocraft S.A. de C.V.
' Author        : Joaquín Hernández García
' Version       : 1.0
' Last Modified : Friday, July 01, 2004
'====================================================================
Public Class clsSucursalEditarPoliticaDePosDeUnaSucursal
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
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private intmCompaniaId As Integer
    Private intmSucursalId As Integer
    Private intmCajaId As Integer
    Private intmTipoDatoPoliticaPosId As Integer
    Private strmPoliticaPOSSucursalValor As String
    Private blnmErrorAgregarSalvar As Boolean

    '====================================================================
    ' Name       : intDireccionId
    ' Description: Identificador de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intDireccionId() As Integer
        Get
            If intmDireccionId = 0 Then
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0"))
            End If
            Return intmDireccionId
        End Get
    End Property

    '====================================================================
    ' Name       : intZonaId
    ' Description: Identificador de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intZonaId() As Integer
        Get
            If intmZonaId = 0 Then
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0"))
            End If
            Return intmZonaId
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compania
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            If intmCompaniaId = 0 Then
                intmCompaniaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
            End If
            Return intmCompaniaId
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            If intmSucursalId = 0 Then
                intmSucursalId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
            End If
            Return intmSucursalId
        End Get
    End Property

    '====================================================================
    ' Name       : intCajaId
    ' Description: Identificador de la Caja
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCajaId() As Integer
        Get
            If intmCajaId = 0 Then
                intmCajaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intCajaId", isocraft.commons.clsWeb.strGetPageParameter("cboCaja", "0")))
            End If
            Return intmCajaId
        End Get
    End Property

    '====================================================================
    ' Name       : strPoliticaPOSSucursalValor
    ' Description: Valor de la política de POS
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strPoliticaPOSSucursalValor() As String
        Get
            If Len(strmPoliticaPOSSucursalValor) = 0 Then
                strmPoliticaPOSSucursalValor = isocraft.commons.clsWeb.strGetPageParameter("txtPoliticaPOSSucursalValor", "")
            End If
            Return strmPoliticaPOSSucursalValor
        End Get
        Set(ByVal strValue As String)
            strmPoliticaPOSSucursalValor = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intTipoDatoPoliticaPosId
    ' Description: Identificador de la política de POS
    ' Accessor   : Read, Write
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property intTipoDatoPoliticaPosId() As Integer
        Get
            If intmTipoDatoPoliticaPosId = 0 Then
                intmTipoDatoPoliticaPosId = CInt(isocraft.commons.clsWeb.strGetPageParameter("intTipoDatoPoliticaPosId", isocraft.commons.clsWeb.strGetPageParameter("cboTipoDatoPoliticaPos", "0")))
            End If
            Return intmTipoDatoPoliticaPosId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoDatoPoliticaPosId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDireccionOperativaNombre
    ' Description: Nombre de la Dirección
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strDireccionOperativaNombre() As String
        Get
            If intDireccionId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblDireccionOperativa.strBuscar(intDireccionId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(1))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strZonaOperativaNombre
    ' Description: Nombre de la Zona
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strZonaOperativaNombre() As String
        Get
            If intDireccionId > 0 AndAlso intZonaId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblZonaOperativa.strBuscar(intDireccionId, intZonaId, "", "", Now, "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(2))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Dim astrData As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)
                If IsArray(astrData) = True AndAlso astrData.Length > 0 Then
                    Return CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))
                End If
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strLlenarTipoDatoPoliticaPosComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoDatoPoliticaPOS"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoDatoPoliticaPosComboBox() As String
        Dim intSecundarioTipoDatoPoliticaPosId As Integer = intTipoDatoPoliticaPosId
        If blnmErrorAgregarSalvar = True Then
            intSecundarioTipoDatoPoliticaPosId = 0
        End If
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoDatoPoliticaPOS", intTipoDatoPoliticaPosId, Benavides.CC.Data.clstblTipoDatoPoliticaPos.strBuscar(intSecundarioTipoDatoPoliticaPosId, "", "", 0, 0, Now(), "", 0, 0, strConnectionString), 0, 2, 0)
    End Function

    '====================================================================
    ' Name       : strLlenarCajaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboCaja"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarCajaComboBox() As String
        Dim intSecundarioCajaId As Integer = intCajaId
        If blnmErrorAgregarSalvar = True Then
            intSecundarioCajaId = 0
        End If
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboCaja", intCajaId, Benavides.CC.Data.clstblCaja.strBuscar(intCompaniaId, intSucursalId, intSecundarioCajaId, 0, 0, "", "", "", "", Now(), Now(), "", 0, 0, strConnectionString), 2, 6, 0)
    End Function

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
    ' Name       : strCmd
    ' Description: Valor del comando ejecutado
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Enviamos al usuario actual a la página origen, si los identificadores de la dirección, zona, compañía y sucursal son inválidos
        If intDireccionId < 1 OrElse intZonaId < 1 OrElse intCompaniaId < 1 OrElse intSucursalId < 1 Then
            Call Response.Redirect("SucursalAdministrarPoliticasDePOS.aspx")
        End If

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", "")
        blnmErrorAgregarSalvar = False

        ' Declaramos el indicador de retorno a la página origen
        Dim blnReturnToPreviousPage As Boolean = True

        ' Ejecutamos el comando indicado
        Select Case strCmd

            Case "Editar"

                ' Si el identificador de la política de POS es válido
                If intTipoDatoPoliticaPosId > 0 AndAlso intCajaId > 0 Then

                    ' Buscamos la política de POS
                    Dim astrData As Array = Benavides.CC.Data.clstblPoliticaPosSucursal.strBuscar(intTipoDatoPoliticaPosId, intCompaniaId, intSucursalId, intCajaId, "", Now, "", 0, 0, strConnectionString)

                    ' Si la política de POS existe
                    If astrData.Length > 0 Then

                        ' Obtenemos los valores de sus atributos
                        strPoliticaPOSSucursalValor = CStr(DirectCast(astrData.GetValue(0), Array).GetValue(4))

                        ' Establecemos el siguiente estado
                        strCmd = "SalvarEditar"
                        blnReturnToPreviousPage = False

                    End If

                End If

            Case "SalvarEditar"

                ' Si los campos obligatorios fueron llenados
                If intTipoDatoPoliticaPosId > 0 AndAlso intCajaId > 0 AndAlso Len(strPoliticaPOSSucursalValor) > 0 Then

                    ' Actualizamos el registro
                    Call Benavides.CC.Data.clstblPoliticaPosSucursal.intActualizar(intTipoDatoPoliticaPosId, intCompaniaId, intSucursalId, intCajaId, strPoliticaPOSSucursalValor, Now, strUsuarioNombre, strConnectionString)

                End If

            Case "Agregar"

                ' Establecemos el siguiente estado
                strCmd = "SalvarAgregar"
                blnReturnToPreviousPage = False

            Case "SalvarAgregar"

                ' Si los campos obligatorios fueron llenados
                If intTipoDatoPoliticaPosId > 0 AndAlso intCajaId > 0 AndAlso Len(strPoliticaPOSSucursalValor) > 0 Then

                    ' Buscamos el registro
                    Dim astrData As Array = Benavides.CC.Data.clstblPoliticaPosSucursal.strBuscar(intTipoDatoPoliticaPosId, intCompaniaId, intSucursalId, intCajaId, "", Now, strUsuarioNombre, 0, 0, strConnectionString)

                    ' Si el registro no existe
                    If astrData.Length = 0 Then

                        ' Agregamos el nuevo registro
                        Call Benavides.CC.Data.clstblPoliticaPosSucursal.intAgregar(intTipoDatoPoliticaPosId, intCompaniaId, intSucursalId, intCajaId, strPoliticaPOSSucursalValor, Now, strUsuarioNombre, strConnectionString)

                    Else

                        ' Error, el registro ya existe, notificamos al usuario
                        blnmErrorAgregarSalvar = True
                        strJavascriptWindowOnLoadCommands &= "  alert(""El formato de datos especificado ya existe para la caja seleccionada, por favor seleccione un formato de datos diferente u otra caja."");" & vbCrLf
                        strJavascriptWindowOnLoadCommands &= "  document.forms[0].elements[""cboTipoDatoPoliticaPOS""].focus();" & vbCrLf
                        blnReturnToPreviousPage = False

                    End If

                End If

            Case "Borrar"

                ' Si los campos obligatorios fueron llenados
                If intTipoDatoPoliticaPosId > 0 AndAlso intCajaId > 0 Then

                    ' Buscamos la política a eliminar
                    Dim astrData As Array = Benavides.CC.Data.clstblPoliticaPosSucursal.strBuscar(intTipoDatoPoliticaPosId, intCompaniaId, intSucursalId, intCajaId, "", Now, strUsuarioNombre, 0, 0, strConnectionString)

                    ' Si la politica existe
                    If astrData.Length > 0 Then

                        ' Buscamos la sucursal
                        Dim astrBranchOffice As Array = Benavides.CC.Data.clstblSucursal.strBuscar(intCompaniaId, intSucursalId, 0, 0, "", 0, 0, 0, Now, "", "", "", "", 0, 0, strConnectionString)

                        ' Si la sucursal existe
                        If astrBranchOffice.Length > 0 Then

                            ' Obtenemos el identificador de la tienda
                            Dim intTiendaId As Integer = CInt(DirectCast(astrBranchOffice.GetValue(0), Array).GetValue(2))

                            ' Si el identificador de la tienda es válido
                            If intTiendaId > 0 Then

                                ' Buscamos la tienda
                                Dim astrStore As Array = Benavides.CC.Data.clstblTienda.strBuscar(intTiendaId, 0, 0, "", "", 0, "", 0, "", "", Now, "", 0, 0, strConnectionString)

                                ' Si la tienda existe
                                If astrStore.Length > 0 Then

                                    ' Enviamos el mensaje
                                    Call Benavides.CC.Business.clsConcentrador.strEnviarMensajeHaciaServidoresPuntoDeVenta("clstblPoliticaPosSucursal", Benavides.POSAdmin.Commons.clsCommons.clsMSMQ.enmMQCommandId.ELIMINAR, "", astrData, astrStore)

                                    ' Eliminamos el registro especificado
                                    Call Benavides.CC.Data.clstblPoliticaPosSucursal.intEliminar(intTipoDatoPoliticaPosId, intCompaniaId, intSucursalId, intCajaId, "", Now, strUsuarioNombre, strConnectionString)

                                End If

                            End If

                        End If

                    End If

                End If

        End Select

        ' Regresamos a la página origen, si existe algún error
        If blnReturnToPreviousPage = True Then
            Call Response.Redirect("SucursalVerPoliticasDePOSDeUnaSucursal.aspx?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId)
        End If

        ' Salvamos en la acción de la forma los identificadores necesarios
        strJavascriptWindowOnLoadCommands &= "  document.forms[0].action += ""?intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId & "&intCompaniaId=" & intCompaniaId & "&intSucursalId=" & intSucursalId & """;"

    End Sub

End Class
