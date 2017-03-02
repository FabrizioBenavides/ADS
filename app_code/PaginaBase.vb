Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class PaginaBase
    Inherits System.Web.UI.Page

    Protected _strmJavascriptWindowOnLoadCommands As String

    Public Property strJavascriptWindowOnLoadCommands() As String
        Get
            Return _strmJavascriptWindowOnLoadCommands
        End Get
        Set(ByVal strValue As String)
            _strmJavascriptWindowOnLoadCommands = strValue
        End Set
    End Property

    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
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
    ' Name       : strTipoUsuarioId
    ' Description: Tipo de usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intTipoUsuarioId() As Integer
        Get
            Return Benavides.CC.Data.clsControlDeAsistencia.intObtenerTipoUsuarioId(strUsuarioNombre, strConnectionString)
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
            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime(clsDateUtil.DATE_HOUR_FORMAT)
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

    ''' <summary>
    ''' Obtiene el tipo de acción en la página.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property strCmd() As Accion
        Get
            Dim valorAccion As String
            Dim tipoAccion As Accion

            valorAccion = GetPageParameter("strCmd", "0")
            tipoAccion = CType([Enum].Parse(GetType(Accion), valorAccion), Accion)
            Return tipoAccion
        End Get
    End Property

    ''' <summary>
    ''' Tipo de acción para la página.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Accion
        Ninguna = 0
        Actualizar
        Confirmar
        Consultar
        Eliminar
        Exportar
        Guardar
        Imprimir
    End Enum

End Class
