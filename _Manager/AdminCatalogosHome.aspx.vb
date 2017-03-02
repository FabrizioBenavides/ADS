'====================================================================
' Class         : clsFarmaciaCatalogosHome
' Title         : Grupo Benavides. Menu de Catálogos
' Description   : Home del menu de Catálogos
' Copyright     : 2003-2006 All rights reserved.
' Company       : Neitek Solutions S.A. de C.V.
' Author        : Jorge Ventura Cantú Campos
' Version       : 1.0
' Last Modified : Thu, April 27th, 2005
'====================================================================

#Region "Imports"
Imports System.Text
Imports System.Collections
Imports prjFotolabBusiness.Benavides.Fotolab.Utils
Imports prjFotolabBusiness.Benavides.Fotolab.Data
#End Region

Public Class clsAdminCatalogosHome
    Inherits clsTemplatePage


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
    '====================================================================
    ' Name       : strGenerarListado
    ' Description: Genera un listado y regresa el HTML de este Listado
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Protected Overrides Function strGenerarListado(ByVal strCmd As String) As String

    End Function


#End Region

#Region "Properties"
    'Protected _intArticuloFotolabId As String
    'Protected _intArticuloFotolabExistenciaActual As String
    'Protected _strArticuloDescripcion As String
    'Protected _fltArticuloPrecioOficial As String
    'Protected _intClasificacionId As String
    'Protected _intClasificacionArticuloId As Integer
    'Protected _strArticuloClasificacionNombre As String
    'Protected _strCodigoBarraArticuloValor As String
    'Protected _strArticulos As String


    ''====================================================================
    '' Name       : strCodigoBarraArticuloValor
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property strCodigoBarraArticuloValor() As String
    '    Get
    '        Return _strCodigoBarraArticuloValor
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strCodigoBarraArticuloValor = strValue
    '    End Set
    'End Property

    ''====================================================================
    '' Name       : strArticulosDes 
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property strArticulos() As String
    '    Get
    '        Return _strArticulos
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strArticulos = strValue
    '    End Set
    'End Property

    ''====================================================================
    '' Name       : intClasificacionid
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property intClasificacionid() As String
    '    Get
    '        Return _intClasificacionId
    '    End Get
    '    Set(ByVal strValue As String)
    '        _intClasificacionId = strValue
    '    End Set
    'End Property

    ''====================================================================
    '' Name       : strArticuloClasificacionNombre 
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property strArticuloClasificacionNombre() As String
    '    Get
    '        Return _strArticuloClasificacionNombre
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strArticuloClasificacionNombre = strValue
    '    End Set
    'End Property

    ''====================================================================
    '' Name       : fltArticuloPrecioOficial 
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property fltArticuloPrecioOficial() As String
    '    Get
    '        Return _fltArticuloPrecioOficial
    '    End Get
    '    Set(ByVal strValue As String)
    '        _fltArticuloPrecioOficial = strValue
    '    End Set
    'End Property
    ''====================================================================
    '' Name       : intArticuloFotolabExistenciaActual 
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property intArticuloFotolabExistenciaActual() As String
    '    Get
    '        Return _intArticuloFotolabExistenciaActual
    '    End Get
    '    Set(ByVal strValue As String)
    '        _intArticuloFotolabExistenciaActual = strValue
    '    End Set
    'End Property

    ''====================================================================
    '' Name       : intArticuloFotolabId
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property intArticuloFotolabId() As String
    '    Get
    '        Return _intArticuloFotolabId
    '    End Get
    '    Set(ByVal strValue As String)
    '        _intArticuloFotolabId = strValue
    '    End Set
    'End Property

    ''====================================================================
    '' Name       : _intArticuloId 
    '' Description: Obtiene o establece el comando para una accion
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property intClasificacionArticuloId() As Integer
    '    Get
    '        Return _intClasificacionArticuloId
    '    End Get
    '    Set(ByVal strValue As Integer)
    '        _intClasificacionArticuloId = strValue
    '    End Set
    'End Property



    ''====================================================================
    '' Name       : strArticuloDescripcion 
    '' Description: Obtiene o establece el valor
    '' Accessor   : Read, Write
    '' Throws     : Ninguna
    '' Output     : String
    ''====================================================================
    'Public Property strArticuloDescripcion() As String
    '    Get
    '        Return _strArticuloDescripcion
    '    End Get
    '    Set(ByVal strValue As String)
    '        _strArticuloDescripcion = strValue
    '    End Set
    'End Property


#End Region

#Region "Document Business"

    '====================================================================
    ' Name       : initialize
    ' Description: inicializa el valor de la clase de servicios
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Nothing
    '====================================================================
    Protected Overrides Sub initialize()

    End Sub

#End Region

End Class