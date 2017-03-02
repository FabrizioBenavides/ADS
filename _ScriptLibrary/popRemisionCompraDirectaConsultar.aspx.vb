Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Business.clsConcentrador.clsSucursal.clsMercancia
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsPopRemisionCompraDirectaConsultar
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

    Private strmCierraDetalleTablaRemision As String

#End Region

    '====================================================================
    ' Name       : strCierraDetalleTablaRemision
    ' Description: Genera el Java Script para poder cerrar  
    '              los detalles de las remisiones
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCierraDetalleTablaRemision() As String
        Get
            Return (strmCierraDetalleTablaRemision)
        End Get
        Set(ByVal Value As String)
            strmCierraDetalleTablaRemision = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: Página hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String
        Get
            If intCompaniaId > 0 AndAlso intSucursalId > 0 Then
                Return "/Default.aspx?strURL=/_ScriptLibrary/POSAdminRedirectorCC.aspx?strPageName=" & strThisPageName
            Else
                Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
            End If
        End Get
    End Property


    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acción de la forma HTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return Request.ServerVariables("SCRIPT_NAME")
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
            Return clsCommons.strGetPageName(Request)
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
            Return CInt(clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Valor de la Compañia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intCompaniaId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Valor de la Sucursal
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(clsCommons.strReadCookie("intSucursalId", "0", Request, Server))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursalNombre
    ' Description: Nombre de la Sucursal
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strSucursalNombre() As String
        Get
            Return clsCommons.strReadCookie("strSucursalNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strUsuarioNombre() As String
        Get
            Return clsCommons.strReadCookie("strUsuarioNombre", "0", Request, Server)
        End Get
    End Property

    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String
        Get
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")
        End Get
    End Property

    '====================================================================
    ' Name       : strURLPOSAdmin
    ' Description: URL del POS Admin
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strURLPOSAdmin() As String
        Get
            Return clsConcentrador.strObtenerURLSucursal(intCompaniaId, intSucursalId, strCadenaConexion)
        End Get
    End Property

    '====================================================================
    ' Name       : intProveedorId
    ' Description:  
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : INTEGER
    '====================================================================
    Public ReadOnly Property intProveedorId() As Integer
        Get
            If Not IsNothing(Request.QueryString("intProveedorId")) Then
                Return CInt(Request.QueryString("intProveedorId"))
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Genera el Record Browser para mostrar las remisiones
    '               
    ' Parameters : 
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaracion de Variables
        Dim objArrayRemisiones As Array = Nothing
        Dim objRegistroRemisiones As System.Collections.SortedList = Nothing

        Dim objArrayArticuloRemision As Array = Nothing
        Dim objRegistroArticuloRemision As System.Collections.SortedList = Nothing

        Dim intContadorRegistros As Integer = 0

        Dim strTablaRemisiones As New StringBuilder
        Dim intTablaRemisionesRegistros As Integer = 0
        Dim strColorRegistroRemision As String

        Dim intContadorArticulos As Integer = 0
        Dim strColorRegistroArticulos As String

        Dim intRemisionCompraDirectaId As Integer = 0

        strTablaRemisiones.Append("<table width='99%' id='tableRegistro' border='0' cellspacing='0' cellpadding='0'>")
        strTablaRemisiones.Append("<tr>")
        strTablaRemisiones.Append("<td>")
        strTablaRemisiones.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
        strTablaRemisiones.Append("<tr class='trtitulos'>")
        strTablaRemisiones.Append("<th align='left' width='10%' class='rayita'>Folio</th>")
        strTablaRemisiones.Append("<th align='left' width='15%' class='rayita'>F.Recepción</th>")
        strTablaRemisiones.Append("<th align='left' width='20%' class='rayita'>Remisión</th>")
        strTablaRemisiones.Append("<th align='left' width='15%' class='rayita'>F.Remisión</th>")
        strTablaRemisiones.Append("<th align='left' width='05%' class='rayita'>Articulos</th>")
        strTablaRemisiones.Append("<th align='left' width='05%' class='rayita'>Piezas</th>")
        strTablaRemisiones.Append("<th align='center' width='20%' class='rayita'>Estado</th>")
        strTablaRemisiones.Append("<th align='center' width='10%' class='rayita'>Ver</th>")
        strTablaRemisiones.Append("</tr>")
        strTablaRemisiones.Append("</table>")
        strTablaRemisiones.Append("</td>")
        strTablaRemisiones.Append("</tr>")

        objArrayRemisiones = clsCompras.clsRemision.strBuscar(intCompaniaId, intSucursalId, 0, CDate("01/01/1900"), CDate("01/01/1900"), intProveedorId, 0, 0, 0, strCadenaConexion)

        If IsArray(objArrayRemisiones) AndAlso objArrayRemisiones.Length > 0 Then

            intContadorRegistros = 0
            intTablaRemisionesRegistros = 2

            For Each objRegistroRemisiones In objArrayRemisiones

                intContadorRegistros += 1

                If (intContadorRegistros Mod 2) <> 0 Then
                    strColorRegistroRemision = "'tdceleste'"
                Else
                    strColorRegistroRemision = "'tdblanco'"
                End If

                intRemisionCompraDirectaId = CInt(objRegistroRemisiones.Item("intRemisionCompraDirectaId"))

                strTablaRemisiones.Append("<tr>")
                strTablaRemisiones.Append("<td>")
                strTablaRemisiones.Append("<table width='99%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaRemisiones.Append("<tr>")
                strTablaRemisiones.Append("<td align='right' width='10%' class=" & strColorRegistroRemision & ">")
                If CInt(objRegistroRemisiones.Item("intRemisionCompraDirectaEstado")) = 1 Then
                    strTablaRemisiones.Append("<a class='txaccion' href=\""javascript:ClosePopup('")
                    strTablaRemisiones.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaId"))).ToString & "','")
                    strTablaRemisiones.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaFolio"))).ToString & "')\"">")
                    strTablaRemisiones.Append(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaFolio")).ToString)
                    strTablaRemisiones.Append("</a>")
                Else
                    strTablaRemisiones.Append(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaFolio")).ToString)
                End If
                strTablaRemisiones.Append("</td>")
                strTablaRemisiones.Append("<td align='left'   width='15%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearFechaPresentacion(CStr(objRegistroRemisiones.Item("dtmRemisionCompraDirectaFechaRecepcion"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='left'   width='20%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("strRemisionCompraDirectaNumeroDocumento"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='left'   width='15%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearFechaPresentacion(CStr(objRegistroRemisiones.Item("dtmRemisionCompraDirectaFechaDocumento"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='right'  width='05%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intTotalArticulos"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='right'  width='05%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intTotalPiezas"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='center'   width='20%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("strRemisionCompraDirectaEstado"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='center' width='10%' class=" & strColorRegistroRemision & "><a href='javascript:ActivateRow(" & intTablaRemisionesRegistros.ToString & ")'><img src='../static/images/icono_mas.gif' width='9' height='9' border='0' align='absMiddle' alt = 'Haga clic aquí para ver detalle de la remision'></a></td>")
                strTablaRemisiones.Append("</tr>")
                strTablaRemisiones.Append("</table>")
                strTablaRemisiones.Append("</td>")
                strTablaRemisiones.Append("</tr>")

                strTablaRemisiones.Append("<tr>")
                strTablaRemisiones.Append("<td>")
                strTablaRemisiones.Append("<table width='99%' border='0' cellpadding='0' cellspacing='0'>")
                strTablaRemisiones.Append("<tr>")
                strTablaRemisiones.Append("<td align='right' width='10%' class=" & strColorRegistroRemision & ">")
                If CInt(objRegistroRemisiones.Item("intRemisionCompraDirectaEstado")) = 1 Then
                    strTablaRemisiones.Append("<a class='txaccion' href=\""javascript:ClosePopup('")
                    strTablaRemisiones.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaId"))).ToString & "','")
                    strTablaRemisiones.Append(clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaFolio"))).ToString & "')\"">")
                    strTablaRemisiones.Append(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaFolio")))
                    strTablaRemisiones.Append("</a>")
                Else
                    strTablaRemisiones.Append(CStr(objRegistroRemisiones.Item("intRemisionCompraDirectaFolio")))
                End If
                strTablaRemisiones.Append("</td>")
                strTablaRemisiones.Append("<td align='left'   width='15%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearFechaPresentacion(CStr(objRegistroRemisiones.Item("dtmRemisionCompraDirectaFechaRecepcion"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='left'   width='20%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("strRemisionCompraDirectaNumeroDocumento"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='left'   width='15%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearFechaPresentacion(CStr(objRegistroRemisiones.Item("dtmRemisionCompraDirectaFechaDocumento"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='right'  width='05%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intTotalArticulos"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='right'  width='05%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("intTotalPiezas"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='center' width='20%' class=" & strColorRegistroRemision & ">" & clsCommons.strFormatearDescripcion(CStr(objRegistroRemisiones.Item("strRemisionCompraDirectaEstado"))).ToString & "</td>")
                strTablaRemisiones.Append("<td align='center' width='10%' class=" & strColorRegistroRemision & "><a href='javascript:DeactivateRow(" & intTablaRemisionesRegistros.ToString & ")'><img src='../static/images/icono_menos.gif' width='9' height='9' border='0' align='absMiddle'></a></td>")
                strTablaRemisiones.Append("</tr>")
                strTablaRemisiones.Append("</table>")
                strTablaRemisiones.Append("</td>")
                strTablaRemisiones.Append("</tr>")

                strTablaRemisiones.Append("<tr>")
                strTablaRemisiones.Append("<td valign='top'>")
                strTablaRemisiones.Append("<table width='99%' border='0' cellspacing='0' cellpadding='0'>")
                strTablaRemisiones.Append("<tr>")

                strTablaRemisiones.Append("<td valign='top' class='tdenvolventetabla'>")
                strTablaRemisiones.Append("<table width='99%' border='0' cellpadding='0' cellspacing='0'>")

                strTablaRemisiones.Append("<tr class='trtitulos'>")
                strTablaRemisiones.Append("<th width='10%' class='rayita'>&nbsp;</th>")
                strTablaRemisiones.Append("<th width='10%' class='rayita'>Codigo</th>")
                strTablaRemisiones.Append("<th width='70%' class='rayita'>Descripción</th>")
                strTablaRemisiones.Append("<th width='10%' class='rayita'>Cantidad</th>")
                strTablaRemisiones.Append("</tr>")

                intTablaRemisionesRegistros += 3

                intContadorArticulos = 0

                objArrayArticuloRemision = clsCompras.clsRemision.strBuscarDetalle(intCompaniaId, intSucursalId, intRemisionCompraDirectaId, strCadenaConexion)

                If IsArray(objArrayArticuloRemision) AndAlso objArrayArticuloRemision.Length > 0 Then

                    For Each objRegistroArticuloRemision In objArrayArticuloRemision

                        intContadorArticulos += 1
                        strColorRegistroArticulos = "'tdblanco'"

                        strTablaRemisiones.Append("<tr>")
                        strTablaRemisiones.Append("<td class=" & strColorRegistroArticulos & " align='right'>" & intContadorArticulos.ToString & "</td>") ' No
                        strTablaRemisiones.Append("<td class=" & strColorRegistroArticulos & " align='right'>" & CStr(objRegistroArticuloRemision.Item("intArticuloId")) & "</td>") ' Articulo
                        strTablaRemisiones.Append("<td class=" & strColorRegistroArticulos & " align='left'> " & clsCommons.strFormatearDescripcion(CStr(objRegistroArticuloRemision.Item("strArticuloDescripcion"))) & "</td>") ' Descripción
                        strTablaRemisiones.Append("<td class=" & strColorRegistroArticulos & " align='right'>" & CStr(objRegistroArticuloRemision.Item("intArticuloRemisionCompraDirectaCantidad")) & "</td>") ' Cantidad
                        strTablaRemisiones.Append("</tr>")

                    Next

                End If

                'Cerrar las tablas.

                strTablaRemisiones.Append("</table>")
                strTablaRemisiones.Append("</td>")
                strTablaRemisiones.Append("</tr>")
                strTablaRemisiones.Append("</table>")
                strTablaRemisiones.Append("<br>")

                strTablaRemisiones.Append("</td>")
                strTablaRemisiones.Append("</tr>")

            Next

            Dim intInicio As Integer = 0
            Dim intRenglonInicio As Integer = 2
            Dim strDeativate As String = ""

            For intInicio = 1 To intContadorRegistros
                strDeativate += "DeactivateRow(" & intRenglonInicio.ToString & ");"
                intRenglonInicio += 3
            Next

            strCierraDetalleTablaRemision = strDeativate
        Else

            strTablaRemisiones.Append("<tr><td class='trtitulos' colspan='8'>NO HAY REMISIONES</td></tr>")

        End If

        strTablaRemisiones.Append("</table><br>")

        Return strTablaRemisiones.ToString

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

    End Sub

End Class


