'====================================================================
' Class         : clsTemplatePage
' Title         : Grupo Benavides. Plantilla de Documento
' Description  : Plantilla de Documento  de Fotolab 
' Copyright    : 2003-2006 All rights reserved.
' Company    : Neitek Solutions S.A. de C.V.
' Author        : Enrique Longoria
' Version       : 1.0
' Last Modified : Thu, Jan 27th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public MustInherit Class clsTemplatePage
    Inherits System.Web.UI.Page
    Implements PrintInterface

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

#Region "Properties and Accesors"
    'constantes de Acciones
    Protected Const _TRAER_LISTADO As String = "TraerListado"
    Protected Const _TRAER_LISTADO_FILTRADO As String = "TraerListadoF"
    Protected Const _BORRAR As String = "Borrar"
    Protected Const _NUEVO As String = "Agregar"
    Protected Const _IMPRIMIR As String = "Imprimir"
    Protected Const _EXPORTAR As String = "Exportar"
    Protected Const _VENTANA_EXCEL As String = "Excel"
    Protected Const _EDITAR As String = "Editar"
    Protected Const _GUARDAR As String = "Guardar"
    Protected Const _CAMBIAR_PAG As String = "skipPage"

    'constantes de Imagenes
    Protected Const _IMG_EDITAR As String = "imgNReditar.gif"
    Protected Const _IMG_BORRAR As String = "imgNRBorrar.gif"
    Protected Const _IMG_DETALLE As String = "imgNRVer.gif"
    Protected Const _IMG_BUSCAR As String = "icono_lupa.gif"
    Protected Const _IMG_ASIGNAR As String = "icono_asignar.gif"

    'Paginación
    Protected Const _MAX_PER_PAGE As Integer = 10

    'Constantes de Comandos
    Protected strmJavascriptWindowOnLoadCommands As String
    Protected strmCommand As String

    'Servicios
    Protected _clsServicesObj As prjFotolabBusiness.Benavides.Fotolab.Data.clsServices

    'Dimensiones del Frame Oculto
    Protected Const frameW As String = "0"
    Protected Const frameH As String = "0 " + Chr(34) + "FRAMEBORDER=0 MARGINWIDTH=0  MARGINHEIGHT=" + Chr(34) + "0"
    'Protected Const frameW As String = "100%"
    'Protected Const frameH As String = "300 " + Chr(34) + "FRAMEBORDER=0 MARGINWIDTH=0  MARGINHEIGHT=" + Chr(34) + "0"


    '====================================================================
    ' Name       : clsServicesObj
    ' Description: Obtiene el objeto de la clase
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : clsServices
    '==================================================================== 
    Public Property clsServicesObj() As prjFotolabBusiness.Benavides.Fotolab.Data.clsServices
        Get
            Return Me._clsServicesObj
        End Get
        Set(ByVal Value As prjFotolabBusiness.Benavides.Fotolab.Data.clsServices)
            Me._clsServicesObj = Value
        End Set
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
    Protected Overridable ReadOnly Property strConnectionString() As String
        Get
            Return System.Configuration.ConfigurationSettings.AppSettings("strCadenaConexionConcentradorFotolab")
        End Get
    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: Establece los comandos Javascript del evento OnLoad
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Property strJavascriptWindowOnLoadCommands() As String
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
    Protected Property strCmd() As String
        Get
            Return strmCommand
        End Get
        Set(ByVal strValue As String)
            strmCommand = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Id de la sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intSucursalId() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intSucursalId", "", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Id de la sucursal y compania como string 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNombreSucursal() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strSucursalNombre", "0", Context.Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalId
    ' Description: Id de la sucursal y compania como string 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalId() As String
        Get
            Return CStr(Me.intCompaniaId) + "-" + CStr(Me.intSucursalId)
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Id de la sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intCompaniaId() As String
        Get
            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intCompaniaId", "", Request, Server)
        End Get
    End Property
#End Region

#Region "Document Overridable"

    '====================================================================
    ' Name       : initialize
    ' Description: inicializa los valores de la clase clsServices para obtener los store procedures de cada  una de las clases
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected MustOverride Sub initialize()


    '====================================================================
    ' Name       : strGenerarListado
    ' Description: Genera un listado y regresa el HTML de este Listado
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected MustOverride Function strGenerarListado(ByVal strCmd As String) As String


    '====================================================================
    ' Name       : checkPermission
    ' Description: Verifica si se cuenta con los permisos necesarios para ver esta pantalla
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overridable Sub checkPermission(Optional ByVal redirectUrl As String = "../Default.aspx")
        'Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect(redirectUrl)
        End If
    End Sub

    '====================================================================
    ' Name       : Page_Load
    ' Description: Evento de la carga de la página, este evento se verifica si existen los permisos para acceder a la página
    '                   por medio de la funcion checkPermission()                    
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overridable Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call checkPermission()
        Call initialize()
    End Sub


    '====================================================================
    ' Name       : strActions
    ' Description: funcion  que realiza la accion para cada comando 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String 
    '====================================================================
    Protected Overridable Function strActions(ByVal strCmd As String, Optional ByVal strParams As String = "") As String
        Dim strHtmlResult As String

        'Ejecutamos el comando indicado
        Select Case strCmd
            Case Me._NUEVO
                strHtmlResult = strNuevoRegistro(strCmd)
            Case Me._EDITAR
                strHtmlResult = strEditarRegistro(strCmd)
            Case Me._GUARDAR
                strHtmlResult = strGuardarRegistro(strCmd)
            Case Me._BORRAR
                strHtmlResult = strBorrarRegistro(strCmd)
            Case Else
                strHtmlResult = strOtraAccion(strCmd)
        End Select

        Return strHtmlResult
    End Function



    '====================================================================
    ' Name       : strExportarListado
    ' Description: Exporta a Excel Listado Desplegado
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strExportarListado() As String
        Dim params As StringBuilder = New StringBuilder
        Dim i As Integer
        Dim paramName As String
        Dim paramValue As String
        Dim aux() As String = Request.Params.AllKeys()

        For i = 0 To aux.Length - 1
            If Not aux(i).IndexOf("_") > 0 And Not aux(i).Equals("strCmd") Then
                params.Append("&")
                params.Append(aux(i))
                params.Append("=")
                params.Append(Request.Params.Item(aux(i)))
            End If
        Next
        Return params.ToString
    End Function

    '====================================================================
    ' Name       : strNuevoRegistro
    ' Description: Acción efectuda cuando se agrega un registro (INSERT)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strNuevoRegistro(ByVal strCmd As String) As String
        clsServicesObj.strAfectarListado(strCmd, Request, Me.strConnectionString, strUsuarioNombre)
        Return ""
    End Function


    '====================================================================
    ' Name       : strGuardarRegistro
    ' Description: Acción efectuda cuando se guarda un registro (UPDATE)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strGuardarRegistro(ByVal strCmd As String) As String
        clsServicesObj.strAfectarListado(strCmd, Request, Me.strConnectionString, strUsuarioNombre)
        Return ""
    End Function


    '====================================================================
    ' Name       : strEditarRegistro
    ' Description: Acción efectuda cuando se consula un solo registro para ser desplegado y posteriormente editado (SELECT)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strEditarRegistro(ByVal strCmd As String) As String
        Dim htmlResult As String
        Dim values As Array
        values = clsServicesObj.strConsultarListado(strCmd, Request, Me.strConnectionString, strUsuarioNombre, -1, -1)
        htmlResult = Me.strDesplegarValores(values)
        Return htmlResult
    End Function


    '====================================================================
    ' Name       : strDesplegarValores
    ' Description: despliega los valores encontrados y los manipula a que fueron leidos, se ejecuta siempre despues del editarRegistro
    ' Parameters : 
    '              ByVal values As  String
    '                 - Arreglo  de valores encontrados en  editarRegistro 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strDesplegarValores(ByVal values As Array) As String
        'para implementar en clase 
    End Function


    '====================================================================
    ' Name       : strBorrarRegistro
    ' Description: Acción efectuda cuando se borra un  registro (DELETE)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strBorrarRegistro(ByVal strCmd As String) As String
        clsServicesObj.strAfectarListado(strCmd, Request, Me.strConnectionString, strUsuarioNombre)
        Return ""
    End Function

    '====================================================================
    ' Name       : strLimpiarValores
    ' Description: Limpia los valores encontrados, se ejecuta siempre despues del borrarRegistro
    ' Parameters : 
    '              ByVal strCmd As  String
    '                   - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strLimpiarValores() As String
        'para implementar en clase 
    End Function


    '====================================================================
    ' Name       : strOtraAccion
    ' Description: Metodo llamado cuando  el strCmd es una accion nueva (esta libre a implementar en cada clase para metodos especiales)
    ' Parameters : 
    '              ByVal strCmd As  String
    '                 - Nombre del  comando a efectuar  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function strOtraAccion(ByVal strCmd As String) As String
        ' aqui se ponen la o las acciones personalizables
    End Function

#End Region

#Region "metodos de la interface PrintInterface"
    '====================================================================
    ' Name       : getData
    ' Description: Obtiene el arreglo de datos que se requiren para el listado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Array
    '====================================================================
    Protected Overridable Function getData() As Array Implements PrintInterface.getData
        Dim dataArray As Array = Nothing
        ' Obtenemos los listados que ya se han capturado previamente.
        dataArray = clsServicesObj.strConsultarListado(strCmd, Nothing, Me.strConnectionString, "", -1, -1)
        Return dataArray
    End Function

    '====================================================================
    ' Name       : addPagination
    ' Description: Especifica si ve requiere agregar paginacion o no al 
    '              listado.
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Boolean
    '====================================================================
    Protected Function addPagination() As Boolean Implements PrintInterface.addPagination
        If Request("strCmd") = Me._VENTANA_EXCEL Then
            Return False
        Else
            Return True
        End If
    End Function

    '====================================================================
    ' Name       : getHeaders
    ' Description: Forma HTML con el header para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Stringbb
    '====================================================================
    Protected Overridable Function getHeaders() As String Implements PrintInterface.getHeaders
        'para implementar en clase 
    End Function

    '====================================================================
    ' Name       : getTitle
    ' Description: Forma HTML con el titulo para el listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function getTitle(ByVal currentPage As Integer, ByVal totalPages As Integer) As String Implements PrintInterface.getTitle
        'para implementar en clase 
    End Function

    '====================================================================
    ' Name       : getRow
    ' Description: Forma HTML para desplegar un renglon del listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function getRow(ByVal aRow As Array, ByVal globalRowCounter As Integer) As String Implements PrintInterface.getRow
        'para implementar en clase 
    End Function

    '====================================================================
    ' Name       : getFooter
    ' Description: Forma HTML con el pie de listado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overridable Function getFooter() As String Implements PrintInterface.getFooter
        'para implementar en clase 
    End Function

    '====================================================================
    ' Name       : getColumnNumber
    ' Description: Regresa el numero de columnas
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected Overridable Function getColumnNumber() As Integer Implements PrintInterface.getColumnNumber
        'para implementar en clase 
    End Function

    '====================================================================
    ' Name       : cambiaExcel
    ' Description: Cambia el Content Type del Documento para exportar a excel
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Sub cambiaExcel()
        Response.Clear()
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
    End Sub
#End Region

End Class


