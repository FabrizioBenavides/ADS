Imports System.Text
Imports System.Collections
Imports Benavides.POSAdmin.Commons

Public Class SucursalAsignacionCuentasSucursal
    Inherits System.Web.UI.Page

    ' Variables locales privadas
    Private strmJavascriptWindowOnLoadCommands As String
    Private strmCommand As String
    Private intmTipoCuentaId As Integer
    Private intmDireccionId As Integer
    Private intmZonaId As Integer
    Private strmSucursales As String

    Private strmAbreDetalleCuentasSucursal As String
    Private strmCierraDetalleCuentasSucursal As String

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
    ' Name       : intTipoCuentaId
    ' Description: Identificador del tipo de Cuenta
    ' Accessor   : Read, write
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public Property intTipoCuentaId() As Integer
        Get
            Return intmTipoCuentaId
        End Get
        Set(ByVal intValue As Integer)
            intmTipoCuentaId = intValue
        End Set
    End Property

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
                intmDireccionId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboDireccion", isocraft.commons.clsWeb.strGetPageParameter("intDireccionId", "0")))
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
                intmZonaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboZona", isocraft.commons.clsWeb.strGetPageParameter("intZonaId", "0")))
            End If
            Return intmZonaId
        End Get
    End Property

    '====================================================================
    ' Name       : intCompaniaId
    ' Description: Identificador de la Compañía
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intCompaniaId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intCompaniaId", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : intSucursalId
    ' Description: Identificador de la Sucursal
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intSucursalId() As Integer
        Get
            Return CInt(isocraft.commons.clsWeb.strGetPageParameter("intSucursalId", "0"))
        End Get
    End Property

    '====================================================================
    ' Name       : strSucursales
    ' Description: Listado de sucursales seleccionadas
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Property strSucursales() As String
        Get
            Return strmSucursales
        End Get
        Set(ByVal stValue As String)
            strmSucursales = stValue
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

    '====================================================================
    ' Name       : strCmd 
    ' Description: Obtiene o establece el comando actual
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
    ' Name       : strLlenarTipoCuentaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboTipoCuenta"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarTipoCuentaComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboTipoCuenta", intTipoCuentaId, Benavides.CC.Data.clstblTipoCuenta.strBuscar(0, "", "", Now(), "", 0, 0, strConnectionString), 0, 2, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarDireccionComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboDireccion"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarDireccionComboBox() As String
        Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboDireccion", intDireccionId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(0, 0, strConnectionString), 0, 1, 1)
    End Function

    '====================================================================
    ' Name       : strLlenarZonaComboBox
    ' Description: Regresa una cadena de texto con el código Javascript
    '              que llena al combo box "cboZona"
    ' Parameters : None
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Public Function strLlenarZonaComboBox() As String
        If intDireccionId > 0 Then
            Return isocraft.commons.clsWeb.strCreateJavascriptComboBoxOptions("cboZona", intZonaId, Benavides.CC.Business.clsConcentrador.clsSucursal.strBuscarAgrupacion(intDireccionId, 0, strConnectionString), 0, 1, 1)
        End If
    End Function

    '====================================================================
    ' Name       : strCierraDetalleCuentasSucursal
    ' Description: Genera el Java Script para poder cerrar y abrir 
    '              llas Cuentas de la Sucursal Indicada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strCierraDetalleCuentasSucursal() As String
        Get
            Return (strmCierraDetalleCuentasSucursal)
        End Get
        Set(ByVal Value As String)
            strmCierraDetalleCuentasSucursal = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strAbreDetalleCuentasSucursal
    ' Description: Genera el Java Script para poder cerrar y abrir 
    '              las Cuentas de la Sucursal Indicada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strAbreDetalleCuentasSucursal() As String
        Get
            Return strmAbreDetalleCuentasSucursal
        End Get
        Set(ByVal Value As String)
            strmAbreDetalleCuentasSucursal = Value
        End Set
    End Property

    '====================================================================
    ' Name       : strValoresCuenta
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strValoresCuenta() As String
        Dim intTipoPseudocuenta As Integer = 1

        Dim objArrayTipoCuentas As Array = Benavides.CC.Data.clsCuenta.strBuscarPorTipo(intTipoCuentaId, 0, 0, 0, strConnectionString)
        Dim strRegistroTipoCuentas As String() = Nothing

        Dim strTablaValoresCuentas As New StringBuilder
        Dim intContadorCuenta As Integer = 0
        Dim strColorRegistro As String = ""
        Dim strDescripcionCuentas1 As String = ""
        Dim strDescripcionCuentas2 As String = ""

        Select Case intTipoCuentaId
            Case 1
                strDescripcionCuentas1 = "Asignar valores para las Pseudocuentas"
                strDescripcionCuentas2 = "Capture el valor de las comisiones y el tipo [pesos o porcentaje] que se aplicaran a las sucursales que aparecen en la lista."
            Case 2
                strDescripcionCuentas1 = "Asignar valores para las Cuentas Contables"
                strDescripcionCuentas2 = "Capture los valores que se aplicaran a las cuentas de las sucursales que aparecen en la lista."
            Case 3
                strDescripcionCuentas1 = "Asignar valores para las Cuentas Bancarias"
                strDescripcionCuentas2 = "Capture los valores que se aplicaran a las cuentas de las sucursales que aparecen en la lista."
        End Select

        If IsArray(objArrayTipoCuentas) AndAlso objArrayTipoCuentas.Length > 0 Then

            strTablaValoresCuentas.Append("<span class='txsubtitulo'>")
            strTablaValoresCuentas.Append("<img src='../static/images/bullet_subtitulos.gif' width='17' height='11' align='absmiddle'>" & strDescripcionCuentas1)
            strTablaValoresCuentas.Append("<p>" & strDescripcionCuentas2 & "</p>")
            strTablaValoresCuentas.Append("<table width='100%'  border='0' cellspacing='0' cellpadding='0'>")

            strTablaValoresCuentas.Append("<tr class='trtitulos'>")

            If intTipoCuentaId = 1 Then
                strTablaValoresCuentas.Append("<th width='20'  class='rayita'>&nbsp;</td>")
                strTablaValoresCuentas.Append("<th width='40'  class='rayita'>Cuenta</td>")
                strTablaValoresCuentas.Append("<th width='240' class='rayita'>Descripción</td>")
                strTablaValoresCuentas.Append("<th width='40'  class='rayita'>Comisión</td>")
                strTablaValoresCuentas.Append("<th width='120' class='rayita'>Comisión en %</td>")
            Else
                strTablaValoresCuentas.Append("<th width='20'  class='rayita'>&nbsp;</td>")
                strTablaValoresCuentas.Append("<th width='40'  class='rayita'>Cuenta</td>")
                strTablaValoresCuentas.Append("<th width='240' class='rayita'>Descripción</td>")
                strTablaValoresCuentas.Append("<th width='120' class='rayita'>N&uacute;mero BAAN</td>")
            End If

            strTablaValoresCuentas.Append("</tr>")

            For Each strRegistroTipoCuentas In objArrayTipoCuentas
                intContadorCuenta += 1

                If (intContadorCuenta Mod 2) <> 0 Then
                    strColorRegistro = "'tdceleste'"
                Else
                    strColorRegistro = "'tdblanco'"
                End If

                strTablaValoresCuentas.Append("<tr>")
                If intTipoCuentaId = 1 Then
                    strTablaValoresCuentas.Append("<td width='20'  class=" & strColorRegistro & ">" & intContadorCuenta.ToString & "</td>")
                    strTablaValoresCuentas.Append("<td width='40'  class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTipoCuentas(0)) & "</td>")
                    strTablaValoresCuentas.Append("<td width='240' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTipoCuentas(3)) & "</td>")
                    strTablaValoresCuentas.Append("<td width='40'  class=" & strColorRegistro & ">")
                    strTablaValoresCuentas.Append("<input type='text' class='field' name='txtComisionCuenta_" & strRegistroTipoCuentas(0) & "'  id='txtComisionCuenta" & strRegistroTipoCuentas(0) & "' value=''>")
                    strTablaValoresCuentas.Append("</td>")
                    strTablaValoresCuentas.Append("<td width='120'  class=" & strColorRegistro & ">")
                    strTablaValoresCuentas.Append("<input type='checkbox' name='chkComisionEsPorcentaje_" & strRegistroTipoCuentas(0) & "'>")
                    strTablaValoresCuentas.Append("</td>")
                Else
                    strTablaValoresCuentas.Append("<td width='20'  class=" & strColorRegistro & ">" & intContadorCuenta.ToString & "</td>")
                    strTablaValoresCuentas.Append("<td width='40'  class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTipoCuentas(0)) & "</td>")
                    strTablaValoresCuentas.Append("<td width='240' class=" & strColorRegistro & ">" & clsCommons.strFormatearDescripcion(strRegistroTipoCuentas(3)) & "</td>")
                    strTablaValoresCuentas.Append("<td width='120'  class=" & strColorRegistro & ">")
                    strTablaValoresCuentas.Append("<input type='text' class='field' name='txtValorCuenta_" & strRegistroTipoCuentas(0) & "'  id='txtValorCuenta" & strRegistroTipoCuentas(0) & "' value=''>")
                    strTablaValoresCuentas.Append("</td>")
                End If

                strTablaValoresCuentas.Append("</tr>")

            Next

            strTablaValoresCuentas.Append("<tr>")
            strTablaValoresCuentas.Append("<td height='43' colspan='8' align='right'><input name='cmdAsignar' type='button' class='button' id='cmdAsignar' value='Asignar Cambios' onclick='return cmdAsignar_onclick()'></td>")
            strTablaValoresCuentas.Append("</tr>")

            strTablaValoresCuentas.Append("</table>")
            strTablaValoresCuentas.Append("</span>")

        End If

        Return strTablaValoresCuentas.ToString

    End Function

    '====================================================================
    ' Name       : strRecordBrowser
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowser(ByVal objArraySucursales As Array) As String

        Dim strRegistroSucursales As String() = Nothing

        Dim intContadorRegistros As Integer = 0
        Dim intTotalRegistros As Integer = 0

        Dim objDetalleCuentasSucursal As Array = Nothing
        Dim strDetalleCuentasSucursal As String() = Nothing

        Dim strTablaSucursales As New StringBuilder
        Dim intTablaSucursalesRegistros As Integer = 0

        Dim intContadorSucursal As Integer = 0
        Dim strColorRegistroSucursal As String

        Dim intContadorCuenta As Integer = 0
        Dim strColorRegistroCuenta As String

        Dim strSucursalId As String = ""
        Dim antSucursalId As String = ""
        Dim strCuentaNombreSucursal As String = ""

        If IsArray(objArraySucursales) AndAlso objArraySucursales.Length > 0 Then


            intTotalRegistros = objArraySucursales.Length 'El Total de Registros de la Consulta

            strTablaSucursales.Append(strValoresCuenta)
            strTablaSucursales.Append("<table width='100%' id='tableRegistro' border='0' cellspacing='0' cellpadding='0'>")
            strTablaSucursales.Append("<tr><td>")
            strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strTablaSucursales.Append("<tr class='trtitulos'>")
            strTablaSucursales.Append("<th width='80'  class='rayita'>&nbsp;</th>")
            strTablaSucursales.Append("<th width='80'  class='rayita'>Compañia</th>")
            strTablaSucursales.Append("<th width='80'  class='rayita'>Sucursal</th>")
            strTablaSucursales.Append("<th width='240' class='rayita'>Nombre</th>")
            strTablaSucursales.Append("<th width='40'  class='rayita'>&nbsp;</th>")
            strTablaSucursales.Append("</tr>")
            strTablaSucursales.Append("</table>")
            strTablaSucursales.Append("</td></tr>")

            intContadorRegistros = 0
            intContadorSucursal = 0
            intContadorCuenta = 0
            intTablaSucursalesRegistros = 2

            For Each strRegistroSucursales In objArraySucursales
                intContadorRegistros += 1

                strSucursalId = strRegistroSucursales(0) & strRegistroSucursales(1)
                strCuentaNombreSucursal = strRegistroSucursales(2)

                If strSucursalId <> antSucursalId Then

                    antSucursalId = [String].Copy(strSucursalId)

                    intContadorSucursal += 1
                    intContadorCuenta = 0

                    If (intContadorSucursal Mod 2) <> 0 Then
                        strColorRegistroSucursal = "'tdceleste'"
                    Else
                        strColorRegistroSucursal = "'tdblanco'"
                    End If

                    If intContadorSucursal <> 1 Then
                        ' Es cambio de Sucursal se cierra el Registro
                        strTablaSucursales.Append("</table>")
                        strTablaSucursales.Append("</td>")
                        strTablaSucursales.Append("</tr>")
                        strTablaSucursales.Append("</table>")
                        strTablaSucursales.Append("<br>")
                        strTablaSucursales.Append("</td>")
                        strTablaSucursales.Append("</tr>")
                    End If

                    strTablaSucursales.Append("<tr>")
                    strTablaSucursales.Append("<td>")
                    strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strTablaSucursales.Append("<tr>")
                    strTablaSucursales.Append("<td width='80'  class=" & strColorRegistroSucursal & ">" & intContadorSucursal.ToString & "</td>")
                    strTablaSucursales.Append("<td width='80'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(0)) & "</td>")
                    strTablaSucursales.Append("<td width='80'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(1)) & "</td>")
                    strTablaSucursales.Append("<td width='240' class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(2)) & "</td>")
                    strTablaSucursales.Append("<td width='40'  class=" & strColorRegistroSucursal & "><a href='javascript:ActivateRow(" & intTablaSucursalesRegistros.ToString & ")'><img src='../static/images/icono_mas.gif' width='9' height='9' border='0' align='absMiddle' alt = 'Haga clic aquí para ver las cuentas de la sucursal'></a></td>")
                    strTablaSucursales.Append("</tr>")
                    strTablaSucursales.Append("</table>")
                    strTablaSucursales.Append("</td>")
                    strTablaSucursales.Append("</tr>")

                    strTablaSucursales.Append("<tr>")
                    strTablaSucursales.Append("<td>")
                    strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
                    strTablaSucursales.Append("<tr>")
                    strTablaSucursales.Append("<td width='80'  class=" & strColorRegistroSucursal & ">" & intContadorSucursal.ToString & "</td>")
                    strTablaSucursales.Append("<td width='80'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(0)) & "</td>")
                    strTablaSucursales.Append("<td width='80'  class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(1)) & "</td>")
                    strTablaSucursales.Append("<td width='240' class=" & strColorRegistroSucursal & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(2)) & "</td>")
                    strTablaSucursales.Append("<td width='40'  class=" & strColorRegistroSucursal & "><a href='javascript:DeactivateRow(" & intTablaSucursalesRegistros.ToString & ")'><img src='../static/images/icono_menos.gif' width='9' height='9' border='0' align='absMiddle'></a></td>")
                    strTablaSucursales.Append("</tr>")
                    strTablaSucursales.Append("</table>")
                    strTablaSucursales.Append("</td>")
                    strTablaSucursales.Append("</tr>")

                    strTablaSucursales.Append("<tr>")
                    strTablaSucursales.Append("<td valign='top'>")
                    strTablaSucursales.Append("<br><span class='txrojobold'><br>&nbsp; " & clsCommons.strFormatearDescripcion(strRegistroSucursales(0)) & " - " & clsCommons.strFormatearDescripcion(strRegistroSucursales(1)) & "  " & clsCommons.strFormatearDescripcion(strRegistroSucursales(2)) & "<br><br></span>")
                    strTablaSucursales.Append("<table width='100%' border='0' cellspacing='0' cellpadding='0'>")
                    strTablaSucursales.Append("<tr>")
                    strTablaSucursales.Append("<td valign='top' class='tdenvolventetabla'>")
                    strTablaSucursales.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

                    strTablaSucursales.Append("<tr class='trtitulos'>")

                    If intTipoCuentaId = 1 Then 'Pseudocuentas
                        strTablaSucursales.Append("<th width='4'   class='rayita'>&nbsp;</th>")
                        strTablaSucursales.Append("<th width='100' class='rayita'>Cuenta</th>")
                        strTablaSucursales.Append("<th width='280' class='rayita'>Nombre</th>")
                        strTablaSucursales.Append("<th width='120' class='rayita'>Comision</th>")
                    Else
                        strTablaSucursales.Append("<th width='4'   class='rayita'>&nbsp;</th>")
                        strTablaSucursales.Append("<th width='100' class='rayita'>Cuenta</th>")
                        strTablaSucursales.Append("<th width='280' class='rayita'>Nombre</th>")
                        strTablaSucursales.Append("<th width='120' class='rayita'>Numero BANN</th>")
                    End If

                    strTablaSucursales.Append("</tr>")

                    intTablaSucursalesRegistros += 3
                End If

                intContadorCuenta += 1

                If (intContadorCuenta Mod 2) <> 0 Then
                    strColorRegistroCuenta = "'tdceleste'"
                Else
                    strColorRegistroCuenta = "'tdblanco'"
                End If

                strTablaSucursales.Append("<tr>")
                If intTipoCuentaId = 1 Then
                    strTablaSucursales.Append("<td width='4'   class=" & strColorRegistroCuenta & ">" & intContadorCuenta.ToString & "</td>")
                    strTablaSucursales.Append("<td width='100' class=" & strColorRegistroCuenta & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(3)) & "</td>")
                    strTablaSucursales.Append("<td width='280' class=" & strColorRegistroCuenta & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(7)) & "</td>")
                    strTablaSucursales.Append("<td width='120' class=" & strColorRegistroCuenta & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(5)) & " " & clsCommons.strFormatearDescripcion(strRegistroSucursales(6)) & "</td>")
                Else
                    strTablaSucursales.Append("<td width='4'   class=" & strColorRegistroCuenta & ">" & intContadorCuenta.ToString & "</td>")
                    strTablaSucursales.Append("<td width='100' class=" & strColorRegistroCuenta & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(3)) & "</td>")
                    strTablaSucursales.Append("<td width='280' class=" & strColorRegistroCuenta & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(7)) & "</td>")
                    strTablaSucursales.Append("<td width='120' class=" & strColorRegistroCuenta & ">" & clsCommons.strFormatearDescripcion(strRegistroSucursales(4)) & "</td>")
                End If
                strTablaSucursales.Append("</tr>")

                If intContadorRegistros = intTotalRegistros Then ' Es el ultimo Registro
                    strTablaSucursales.Append("</table>")
                    strTablaSucursales.Append("</td>")
                    strTablaSucursales.Append("</tr>")
                    strTablaSucursales.Append("</table>")
                    strTablaSucursales.Append("<br>")
                    strTablaSucursales.Append("</td>")
                    strTablaSucursales.Append("</tr>")
                End If

            Next

            strTablaSucursales.Append("</table>")

            Dim intInicio As Integer = 0
            Dim intRenglonInicio As Integer = 2
            Dim strDeativate As String = ""
            Dim strActivate As String = ""

            For intInicio = 1 To intContadorSucursal
                strDeativate += "DeactivateRow(" & intRenglonInicio.ToString & ");"
                strActivate += "ActivateRow(" & intRenglonInicio.ToString & ");"
                intRenglonInicio += 3
            Next

            strCierraDetalleCuentasSucursal = strDeativate
            strAbreDetalleCuentasSucursal = strActivate

        End If


        strRecordBrowser = clsCommons.strGenerateJavascriptString(strTablaSucursales.ToString)

    End Function

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Regresa el HTML del navegador de registros
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaramos e inicializamos las variables locales
        Dim strArraySucursalesSeleccionadas As Array = Nothing
        Dim astrCompaniaSucursal As Array = Nothing
        Dim strCapturaValores As StringBuilder

        ' Si los identificadores de la cuenta, direccion y zona son válidos
        If intTipoCuentaId > 0 AndAlso intDireccionId > 0 AndAlso intZonaId > 0 AndAlso Len(strSucursales) > 0 Then

            ' Buscamos los valores de las cuentas para las sucursales de esta dirección y zona
            Dim objArraySucursales As Array = Benavides.CC.Business.clsConcentrador.clsSucursal.clsCuenta.strBuscarValores(intTipoCuentaId, intDireccionId, intZonaId, strConnectionString)

            ' Almacenamos en un arreglo la lista de compañías y sucursales la lista tiene el siguiente formato:
            ' intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId

            Dim strArrayIdentificadoresCompaniaSucursal As Array = strSucursales.Split(","c)

            ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
            If strArrayIdentificadoresCompaniaSucursal.Length > 0 Then

                ' Creamos la lista que almacenará a los identificadores de la compañía y sucursal
                Dim strArrayListaSucursalesSeleccionadas As System.Collections.ArrayList = New System.Collections.ArrayList

                ' Recorremos los pares identificadores
                Dim strCompaniaIdentificadorSucursal As String

                For Each strCompaniaIdentificadorSucursal In strArrayIdentificadoresCompaniaSucursal

                    ' Separamos los pares identificadores y los almacenamos en un arreglo
                    astrCompaniaSucursal = strCompaniaIdentificadorSucursal.Split("|"c)

                    ' Agregamos al arreglo resultante a la lista de las sucursales seleccionadas
                    Call strArrayListaSucursalesSeleccionadas.Add(astrCompaniaSucursal)

                    astrCompaniaSucursal = Nothing

                Next

                strArraySucursalesSeleccionadas = strArrayListaSucursalesSeleccionadas.ToArray()

            End If


            ' Si fueron seleccionadas sucursales
            If IsNothing(strArraySucursalesSeleccionadas) = False AndAlso strArraySucursalesSeleccionadas.Length > 0 Then

                Dim strArraySucursalesResultantes As System.Collections.ArrayList = New System.Collections.ArrayList
                Dim astrRecord As Array = Nothing

                ' Recorremos las sucursales seleccionadas
                For Each astrCompaniaSucursal In strArraySucursalesSeleccionadas

                    ' Recorremos las sucursales que pertenecen a la dirección y zona especificada
                    For Each astrRecord In objArraySucursales

                        ' Agregamos la sucursal actual, si la compañía y la sucursal seleccionada corresponden a esta sucursal
                        If CInt(astrRecord.GetValue(0)) = CInt(astrCompaniaSucursal.GetValue(0)) AndAlso CInt(astrRecord.GetValue(1)) = CInt(astrCompaniaSucursal.GetValue(1)) Then
                            strArraySucursalesResultantes.Add(astrRecord)
                        End If

                    Next

                Next

                ' Redefinimos el arreglo de sucursales
                Dim strElementCounter As String = CStr(strArraySucursalesResultantes.Count)
                objArraySucursales = strArraySucursalesResultantes.ToArray()

                For Each astrRecord In objArraySucursales
                    Call astrRecord.SetValue(strElementCounter, astrRecord.Length - 1)
                Next

            End If

            strCapturaValores = New StringBuilder

            strCapturaValores.Append("")

            ' Generamos el navegador de registros
            Dim strReturn As String = strRecordBrowser(objArraySucursales)

            Return strReturn


        End If

    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then
            Call Response.Redirect("../Default.aspx")
        End If

        ' Almacenamos el tipo de cuenta
        intTipoCuentaId = CInt(isocraft.commons.clsWeb.strGetPageParameter("cboTipoCuenta", "0"))

        ' Almacenamos la lista de sucursales seleccionadas
        strSucursales = isocraft.commons.clsWeb.strGetPageParameter("txtSucursales", isocraft.commons.clsWeb.strGetPageParameter("strSucursales", ""))

        ' Almacenamos el comando ejecutado
        strCmd = isocraft.commons.clsWeb.strGetPageParameter("strCmd", isocraft.commons.clsWeb.strGetPageParameter("cmdConsultar", ""), Request)

        ' Ejecutamos el comando indicado

        Select Case strCmd
            Case "Afectar"
                Dim intTotalElementosForma As Integer
                Dim intIndexOfGuion As Integer

                Dim intCuentaId As Integer = 0
                Dim fltComision As Double = 0
                Dim intPorcentaje As Integer = 0
                Dim strNumeroCuenta As String = ""

                Dim strNombreParametro As String
                Dim strValorParametro As String

                Dim strNombreCampoComision As String = "txtComisionCuenta"
                Dim intIndexOftxtComision As Integer = strNombreCampoComision.Length

                Dim strNombreCampoValor As String = "txtValorCuenta"
                Dim intIndexOftxtValor As Integer = strNombreCampoValor.Length

                ' Almacenamos en un arreglo la lista de compañías y sucursales
                ' La lista tiene el siguiente formato: intCompaniaId | intSucursalId , intCompaniaId | intSucursalId, ..., intCompaniaId | intSucursalId

                Dim astrIdentificadoresCompaniaSucursal As Array = strSucursales.Split(","c)

                ' Si obtuvimos pares de identificadores "intCompaniaId | intSucursalId"
                If astrIdentificadoresCompaniaSucursal.Length > 0 Then

                    ' Recorremos los pares identificadores
                    Dim strCompaniaIdentificadorSucursal As String
                    For Each strCompaniaIdentificadorSucursal In astrIdentificadoresCompaniaSucursal

                        ' Separamos los pares identificadores y los almacenamos en un arreglo
                        Dim astrCompaniaSucursal As Array = strCompaniaIdentificadorSucursal.Split("|"c)

                        ' Si existen identificadores
                        If astrCompaniaSucursal.Length > 0 Then

                            ' Obtenemos la compañía, la sucursal y el nuevo tipo de cambio
                            Dim intCompaniaAfectarId As Integer = CInt(astrCompaniaSucursal.GetValue(0))
                            Dim intSucursalAfectarId As Integer = CInt(astrCompaniaSucursal.GetValue(1))

                            ' Actualizamos el tipo de cambio, si la compañía y la sucursal son válidos
                            If intCompaniaAfectarId > 0 AndAlso intSucursalAfectarId > 0 Then

                                'GUARDAR LOS VALORES

                                For intTotalElementosForma = 0 To Request.Form.Count - 1
                                    intCuentaId = 0
                                    fltComision = 0
                                    intPorcentaje = 0
                                    strNumeroCuenta = ""

                                    ' Busco el nombre y el valor del parámetro
                                    strNombreParametro = Request.Form.GetKey(intTotalElementosForma)
                                    strValorParametro = Request.Form(strNombreParametro)

                                    intIndexOfGuion = strNombreParametro.IndexOf("_")

                                    If strNombreParametro.StartsWith(strNombreCampoComision) Then

                                        intCuentaId = CInt(strNombreParametro.Substring(intIndexOftxtComision + 1, strNombreParametro.Length - intIndexOfGuion - 1))
                                        fltComision = CDbl(strValorParametro)

                                        If Len(Trim(Request.Form("chkComisionEsPorcentaje_" & Trim(intCuentaId.ToString)))) > 0 Then
                                            intPorcentaje = 1
                                        Else
                                            intPorcentaje = 0
                                        End If

                                    ElseIf strNombreParametro.StartsWith(strNombreCampoValor) Then
                                        intCuentaId = CInt(strNombreParametro.Substring(intIndexOftxtValor + 1, strNombreParametro.Length - intIndexOfGuion - 1))
                                        strNumeroCuenta = strValorParametro

                                    End If

                                    If intCuentaId > 0 Then
                                        If intTipoCuentaId = 1 Then
                                            Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsCuenta.intAfectarValores(intCompaniaAfectarId, intSucursalAfectarId, intCuentaId, strNumeroCuenta, fltComision, intPorcentaje, strUsuarioNombre, strConnectionString)
                                        Else
                                            Call Benavides.CC.Business.clsConcentrador.clsSucursal.clsCuenta.intAfectarValores(intCompaniaAfectarId, intSucursalAfectarId, intCuentaId, strNumeroCuenta, fltComision, intPorcentaje, strUsuarioNombre, strConnectionString)
                                        End If
                                    End If

                                Next

                            End If

                        End If

                    Next

                End If

        End Select

        Call strRecordBrowserHTML()

    End Sub

End Class
