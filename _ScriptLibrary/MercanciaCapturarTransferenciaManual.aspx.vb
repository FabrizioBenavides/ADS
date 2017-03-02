Imports Benavides.POSAdmin.Commons
Imports Benavides.CC.Business
Imports Benavides.CC.Data
Imports System.Text
Imports System.Configuration

Public Class clsMercanciaCapturarTransferenciaManual
    Inherits System.Web.UI.Page

    Dim strComitasDobles As String = """"

    Private intmTransferenciaFolio As Integer = 0
    Private intmTransferenciaId As Integer = 0

    Private intmArticulosListaTransferencia As Integer = 0
    Private intmBultosListaTransferencia As Integer = 0
    Private strmJavascriptWindowOnLoadCommands As String = ""


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.diagnostics.debuggerstepthrough()> Private Sub InitializeComponent()

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
    ' Accessor   : Read
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

    Public ReadOnly Property strHoraBloqueo() As String
        Get
            Return ConfigurationSettings.AppSettings("strHoraBloqueo")
        End Get
    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: string de Comandos de control
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            If Not IsNothing(Request.QueryString("strCmd")) Then
                Return Request.QueryString("strCmd")
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGeneraListaMotivosTES
    ' Description: Lista con los motivos de Transferencias Normales
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraListaMotivosTES(ByVal strObjeto As String) As String
        Dim intContador As Integer, intConsecutivo As Integer
        Dim strLista As String

        Dim objMotivosTransferencia As Array = Nothing
        Dim strRegistro As String()
        strRegistro = Nothing

        objMotivosTransferencia = clstblMotivoTransferencia.strBuscar(0, "", "", 1, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        '------------------------
        strLista = "document.forms[0]." & strObjeto & ".options[0] = new Option(""Seleccione un motivo"",-1 );" & vbCrLf
        intConsecutivo = 0
        If IsArray(objMotivosTransferencia) AndAlso (objMotivosTransferencia.Length > 0) Then
            For Each strRegistro In objMotivosTransferencia
                intConsecutivo += 1
                strLista += "document.forms[0]." & strObjeto & "" & _
                                 ".options[" & intConsecutivo.ToString & "] " & _
                                 "= new Option(""" & clsCommons.strFormatearDescripcion(strRegistro(1)).ToString & """,""" & _
                                 clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & """);" & vbCrLf

            Next
        End If
        '------------------------
        Return strLista
    End Function

    '====================================================================
    ' Name       : strGeneraListaMotivosDevoluciones
    ' Description: Lista con los motivos de Devoluciones
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraListaMotivosDevoluciones(ByVal strObjeto As String) As String
        Dim intContador As Integer, intConsecutivo As Integer
        Dim strLista As String

        Dim objMotivosTransferencia As Array = Nothing
        Dim strRegistro As String()
        strRegistro = Nothing

        objMotivosTransferencia = clstblMotivoTransferencia.strBuscar(0, "", "", 2, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        '------------------------
        strLista = "document.forms[0]." & strObjeto & ".options[0] = new Option(""Seleccione un motivo"",-1 );" & vbCrLf
        intConsecutivo = 0
        If IsArray(objMotivosTransferencia) AndAlso (objMotivosTransferencia.Length > 0) Then
            For Each strRegistro In objMotivosTransferencia
                intConsecutivo += 1
                strLista += "document.forms[0]." & strObjeto & "" & _
                                 ".options[" & intConsecutivo.ToString & "] " & _
                                 "= new Option(""" & clsCommons.strFormatearDescripcion(strRegistro(1)).ToString & """,""" & _
                                 clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & """);" & vbCrLf

            Next
        End If
        '------------------------
        Return strLista
    End Function

    '====================================================================
    ' Name       : strGeneraListaMotivosReclamaciones
    ' Description: Lista con los motivos de Devoluciones
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strGeneraListaMotivosReclamaciones(ByVal strObjeto As String) As String
        Dim intContador As Integer, intConsecutivo As Integer
        Dim strLista As String

        Dim objMotivosTransferencia As Array = Nothing
        Dim strRegistro As String()
        strRegistro = Nothing

        objMotivosTransferencia = clstblMotivoTransferencia.strBuscar(0, "", "", 3, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

        '------------------------
        strLista = "document.forms[0]." & strObjeto & ".options[0] = new Option(""Seleccione un motivo"",-1 );" & vbCrLf
        intConsecutivo = 0
        If IsArray(objMotivosTransferencia) AndAlso (objMotivosTransferencia.Length > 0) Then
            For Each strRegistro In objMotivosTransferencia
                intConsecutivo += 1
                strLista += "document.forms[0]." & strObjeto & "" & _
                                 ".options[" & intConsecutivo.ToString & "] " & _
                                 "= new Option(""" & clsCommons.strFormatearDescripcion(strRegistro(1)).ToString & """,""" & _
                                 clsCommons.strFormatearDescripcion(strRegistro(0)).ToString & """);" & vbCrLf

            Next
        End If
        '------------------------
        Return strLista
    End Function

    '====================================================================
    ' Name       : strcboEmpleadoAutorizado
    ' Description: Genera el código requerido para crear los valores
    '              del combo de EmpleadoAutorizados
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strcboEmpleadoAutorizado() As String
        Get
            ' Declaración e inicialización de las variables locales
            Dim strbldcboEmpleadoAutorizado As StringBuilder
            Dim objEmpleadoAutorizado As Array = Nothing
            Dim strEmpleadoAutorizado As String()
            Dim intOption As Integer = 1

            strbldcboEmpleadoAutorizado = New StringBuilder

            ' Busqueda de los EmpleadoAutorizados registrados
            objEmpleadoAutorizado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.strBuscarEmpleadoAutorizaNegados(intCompaniaId, intSucursalId, 0, 0, strCadenaConexion)

            If IsArray(objEmpleadoAutorizado) Then
                If (objEmpleadoAutorizado.Length > 0) Then

                    ' Generación del combo de EmpleadoAutorizados
                    intOption = 1
                    For Each strEmpleadoAutorizado In objEmpleadoAutorizado
                        strbldcboEmpleadoAutorizado.Append("document.forms[0].cboEmpleadoAutorizado.options[" & intOption & "] = new Option(""" & clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(7)).ToString & """, """ & clsCommons.strFormatearDescripcion(strEmpleadoAutorizado(0)).ToString & """); ")

                        ' Verifico si es el valor pasado como parámetro
                        If CType(strEmpleadoAutorizado(0), Integer) = intEmpleadoAutorizadoId Then
                            strbldcboEmpleadoAutorizado.Append("document.forms[0].cboEmpleadoAutorizado.options[" & intOption & "].selected = true;")
                        End If

                        intOption += 1
                    Next
                End If
            End If

            Return strbldcboEmpleadoAutorizado.ToString

        End Get
    End Property

    '====================================================================
    ' Name       : intTransferenciaId
    ' Description: valor del querystring
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property intTransferenciaId() As Integer
        Get
            Return intmTransferenciaId
        End Get
        Set(ByVal intValue As Integer)
            intmTransferenciaId = intValue
        End Set
    End Property

    '====================================================================
    ' Name       : strTxtintTransferenciaId
    ' Description: strTxtintTransferenciaId
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strTxtintTransferenciaId() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request.Form("txtintTransferenciaId"))
            If strTemporal.Equals("") Then
                Return "0"
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intRemisionElectronicaId
    ' Description: Remision electronica
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intRemisionElectronicaId() As Integer
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request.Form("hdnRemisionElectronicaId"))
            If strTemporal.Equals("") Then
                Return 0
            Else
                Return CInt(strTemporal)
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : cboTipoTES
    ' Description: Tipo de Transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property cboTipoTES() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("cboTipoTES"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strcboMotivo
    ' Description: valor del control 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strcboMotivo() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("cboMotivo"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strtxtCompaniaQueRecibe
    ' Description: valor del control strtxtCompaniaQueRecibe
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtCompaniaQueRecibe() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtCompaniaQueRecibe"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strtxtSucursalQueRecibe
    ' Description: valor del control txtSucursalQueRecibe
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtSucursalQueRecibe() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtSucursalQueRecibe"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strtxtDescripcionSucursal
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtDescripcionSucursal() As String
        Get
            If Not IsNothing(Request.Form("txtDescripcionSucursal")) Then
                Return Trim(Request.Form("txtDescripcionSucursal"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intEmpleadoAutorizadoId
    ' Description: Identificador del empleado autorizado
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intEmpleadoAutorizadoId() As Integer
        Get
            If Request.Form("cboEmpleadoAutorizado") <> "" Then
                Return CType(Request.Form("cboEmpleadoAutorizado").ToString, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : intProveedorRemisionCapturada
    ' Description: valor del Proveedor de la Remision Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property intProveedorRemisionCapturada() As Integer
        Get
            If Not IsNothing(Request.Form("txtProveedorRemision")) Then
                If IsNumeric(Trim(Request.Form("txtProveedorRemision"))) Then
                    Return CInt(Trim(Request.Form("txtProveedorRemision")))
                Else
                    Return 0
                End If
            Else
                Return 0
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : intRemisionCapturada
    ' Description: valor de la Remision Capturada
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strNumeroRemisionCapturada() As String
        Get
            If Not IsNothing(Request.Form("txtNumeroRemision")) Then
                Return Trim(Request.Form("txtNumeroRemision"))
            Else
                Return ""
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strObservacionesCapturadas
    ' Description: OBSERVACIONES CAPTURADAS
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strObservacionesCapturadas() As String
        Get
            If Not IsNothing(Request.Form("txtObservaciones")) Then
                Return Trim(Request.Form("txtObservaciones"))
            Else
                Return ""
            End If

        End Get
    End Property

    '====================================================================
    ' Name       : strtxtIntArticuloId
    ' Description: valor del control txtIntArticuloId
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strtxtIntArticuloId() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request("txtIntArticuloId"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtCantidad
    ' Description: strTxtCantidad
    ' Accessor   : Read, Write
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property strTxtCantidad() As String
        Get
            If Not IsNothing(Request.Form("txtCantidad")) Then
                Return (Request.Form("txtCantidad"))
            Else
                Return ""
            End If
        End Get
    End Property

    Public ReadOnly Property strNumeroBulto() As String
        Get
            If Not IsNothing(Request.Form("txtNumeroBulto")) Then
                Return (Request.Form("txtNumeroBulto"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strTxtCifraDeControl
    ' Description: 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strTxtCifraDeControl() As String
        Get
            If Not IsNothing(Request.Form("txtCifraDeControl")) Then
                Return Trim(Request.Form("txtCifraDeControl"))
            Else
                Return ""
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : cmdConfirmar
    ' Description: valor del campo cmdConfirmar
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property cmdConfirmar() As String
        Get
            Dim strTemporal As String
            strTemporal = Trim(Request.Form("cmdConfirmar"))
            If strTemporal.Equals("") Then
                Return ""
            Else
                Return strTemporal
            End If
        End Get
    End Property

    '====================================================================
    ' Name       : strGeneraListaBultos
    ' Description: Genera el Record Browser con los Bultos capturados 
    '              en la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraListaBultos(ByVal objArrayBultos As Array) As String

        Dim strRegistroBultos As String() = Nothing

        Dim strHTML As StringBuilder
        Dim strClass As String
        Dim strComilla As String = """"

        Dim intRenglon As Integer = 0

        strHTML = New StringBuilder


        If IsArray(objArrayBultos) AndAlso (objArrayBultos.Length > 0) Then
            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")
            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='25'  class='rayita'>No.</th>")
            strHTML.Append("<th align='right' width='100'  class='rayita'>Número Bulto</th>")
            strHTML.Append("<th align='right' width='72'  class='rayita'>Acción</th>")
            strHTML.Append("</tr>")

            For Each strRegistroBultos In objArrayBultos

                intRenglon += 1

                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If

                strHTML.Append("<tr>")

                'No. de Renglon
                strHTML.Append("<td class='" & strClass & "'>" & intRenglon.ToString & "&nbsp;</td>")
                'Numero de Bulto
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistroBultos(2)).ToString & "&nbsp;</td>")
                'Accion Borrar
                strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:intEliminarBulto(" & CStr(intTransferenciaId) & "," & strRegistroBultos(2) & ")" & strComilla & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle></a></td>")

                strHTML.Append("</tr>")
            Next
            strHTML.Append("</table>")
            strHTML.Append("<br>")

        End If

        intBultosListaTransferencia = intRenglon
        strGeneraListaBultos = clsCommons.strGenerateJavascriptString(strHTML.ToString)

    End Function

    '====================================================================
    ' Name       : intBultosListaTransferencia
    ' Description: Indica el numero de Bultos en la transferencia
    ' Accessor   : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intBultosListaTransferencia() As Integer
        Get
            Return intmBultosListaTransferencia
        End Get
        Set(ByVal Value As Integer)
            intmBultosListaTransferencia = Value

        End Set
    End Property

    '====================================================================
    ' Name       : strGeneraListaTransferencia
    ' Description: Genera el Record Browser con el detalle de la transferencia
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Private Function strGeneraListaTransferencia(ByVal objArray As Array, _
                                  ByRef intConsecutivo As Integer, _
                                  ByVal strTitulo As String, _
                                  ByVal strEncaCol0 As String, _
                                  ByVal strEncaCol1 As String, _
                                  ByVal strEncaCol2 As String, _
                                  ByVal strEncaCol3 As String, _
                                  ByVal strEncaCol4 As String, _
                                  ByVal strEncaCol5 As String, _
                                  ByVal strEncaCol6 As String, _
                                  ByVal strEncaCol7 As String _
                                  ) As String

        Dim strHTML As StringBuilder
        Dim strRegistro As String() = Nothing
        Dim intRenglon As Integer
        Dim dblTotal As Double
        Dim strClass As String
        Dim strComilla As String
        Dim strReadonly As String

        Dim fltPrecioVenta As Double, fltImporte As Double
        Dim intCantidad As Integer

        strComilla = """"

        strHTML = New StringBuilder
        strHTML.Append("")


        intRenglon = 0
        If IsArray(objArray) AndAlso (objArray.Length > 0) Then
            strHTML.Append("<table width='100%' border='0' cellpadding='0' cellspacing='0'>")

            strHTML.Append("<tr class='trtitulos'>")
            strHTML.Append("<th width='25'  class='rayita'>" & strEncaCol0 & "</th>") '"No."
            strHTML.Append("<th width='61'  class='rayita'>" & strEncaCol1 & "</th>") '""
            strHTML.Append("<th width='175' class='rayita'>" & strEncaCol2 & "</th>") '"Código"
            strHTML.Append("<th align='right' width='54'  class='rayita'>" & strEncaCol3 & "</th>") '"Descripción"
            strHTML.Append("<th align='right' width='72'  class='rayita'>" & strEncaCol4 & "</th>") '"P. venta"
            strHTML.Append("<th align='right' width='54'  class='rayita'>" & strEncaCol5 & "</th>") '"Importe"
            strHTML.Append("<th align='right' width='72'  class='rayita'>" & strEncaCol6 & "</th>") '"Cantidad"
            strHTML.Append("<th align='right' width='72'  class='rayita'>" & strEncaCol7 & "</th>") '"Acción"
            strHTML.Append("</tr>")

            For Each strRegistro In objArray

                intConsecutivo += 1
                intRenglon += 1
                If ((intRenglon Mod 2) = 0) Or (intRenglon = 0) Then
                    strClass = "tdceleste"
                Else
                    strClass = "tdblanco"
                End If

                strHTML.Append("<tr>")
                '0 strArticuloEstadoTransferenciaEnvoltura 
                '1 intArticuloId 
                '2 strArticuloDescripcion
                '3 fltArticuloPrecioActual 
                '4 fltArticuloEstadoTransferenciaPrecioVenta
                '5 intCantidadSugerida 
                '6 intArticuloEstadoTransferenciaCantidad 
                '7 blnTransferenciaEsManual                  
                '8 intTotalRegistros          

                strHTML.Append("<td class='" & strClass & "'>" & intConsecutivo.ToString & "&nbsp;</td>")

                '0 strArticuloEstadoTransferenciaEnvoltura 
                strHTML.Append("<td align='right' class='" & strClass & "'>" & strRegistro(0) & "&nbsp;</td>")
                '1 intArticuloId 
                strHTML.Append("<td class='" & strClass & "'>" & strRegistro(1) & "&nbsp;</td>")
                '2 strArticuloDescripcion
                strHTML.Append("<td class='" & strClass & "'>" & clsCommons.strFormatearDescripcion(strRegistro(2)).ToString & "&nbsp;</td>")
                '4 fltArticuloEstadoTransferenciaPrecioVenta
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearNumeroPresentacion(strRegistro(4), True) & "&nbsp;</td>")
                'Importe = P.venta * Cantidad
                fltPrecioVenta = CDbl(strRegistro(4)) '4 fltArticuloEstadoTransferenciaPrecioVenta
                intCantidad = CInt(strRegistro(6))    '6 intArticuloEstadoTransferenciaCantidad 
                fltImporte = fltPrecioVenta * intCantidad
                strHTML.Append("<td align='right' class='" & strClass & "'>" & clsCommons.strFormatearNumeroPresentacion(fltImporte.ToString, True) & "&nbsp;</td>")
                '6 intArticuloEstadoTransferenciaCantidad 
                strHTML.Append("<td align='right' class='" & strClass & "'>" & strRegistro(6) & "&nbsp;</td>")
                strHTML.Append("<input type=hidden name=txtCantidad_" & Trim(CStr(intRenglon)) & " value=" & strComilla & strRegistro(6) & strComilla & ">")

                'Accion Borrar
                strHTML.Append("<td align='right' class='" & strClass & "'><a style=" & strComilla & "text-decoration: none" & strComilla & " href=" & strComilla & "javascript:intEliminarArticulo(" & CStr(intTransferenciaId) & "," & strRegistro(0) & ")" & strComilla & ">" & "<img src=../static/images/icono_borrar.gif width=11 height=13 border=0 align=absmiddle></a></td>")

                strHTML.Append("</tr>")
            Next

            '------------------------

            strHTML.Append("</table>")
            strHTML.Append("<br>")

        End If

        intArticulosListaTransferencia = intRenglon
        strGeneraListaTransferencia = clsCommons.strGenerateJavascriptString(strHTML.ToString)

    End Function

    '====================================================================
    ' Name       : intArticulosListaTransferencia
    ' Description: Indica el numero de Articulos en la transferencia
    ' Accessor   : 
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public Property intArticulosListaTransferencia() As Integer
        Get
            Return intmArticulosListaTransferencia
        End Get
        Set(ByVal Value As Integer)
            intmArticulosListaTransferencia = Value

        End Set
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
    ' Name       : Page_Load
    ' Description: Evento "Load" de la página
    ' Parameters :
    '              ByVal objSender As System.Object
    '                 - Objeto que genera el Evento
    '              ByVal objEvent As System.EventArgs
    '                 - Argumentos del Evento
    ' Throws     : Ninguna
    ' Output     : Ninguna
    '====================================================================
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Control de Acceso de la página
        If clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strURLPOSAdmin + strRedirectPage)
        End If

        If clsConcentrador.clsSucursal.bolBuscarSucursalCTFLiberada(intCompaniaId, intSucursalId, strCadenaConexion) Then
            Call Response.Redirect(strURLPOSAdmin & "/_ScriptLibrary/MercanciaCapturarTransferenciaManual.aspx")
        End If

        Dim strHora As String = Now.Hour.ToString

        If CInt(strHora) >= CInt(strHoraBloqueo) Then
            strJavascriptWindowOnLoadCommands = "fnBloqueaPagina();"
        End If

        Dim objArray As Array = Nothing
        Dim strRegistro As String() = Nothing
        Dim intResultado As Integer
        Dim strHTML As StringBuilder
        Dim strListaTransferenciaHTML As String = ""

        Select Case strCmd

            Case "BuscaSucursal"

                strHTML = New StringBuilder

                Dim objArraySucursalRecibo As Array = Nothing
                Dim strRegistroSucursalRecibo As String()

                Dim intCompaniaReciboId As Integer = 0
                Dim intSucursalReciboId As Integer = 0
                Dim strDecripcionSucursalRecibo As String = ""
                Dim intUenSucursalReciboId As Integer = 0
                Dim strErrorSucursal As String = ""

                If IsNumeric(strtxtCompaniaQueRecibe) And IsNumeric(strtxtSucursalQueRecibe) Then

                    ' Buscamos la descripcion de la sucursal

                    objArraySucursalRecibo = clsConcentrador.clsSucursal.strBuscar(strtxtCompaniaQueRecibe, strtxtSucursalQueRecibe, 1, 1, strCadenaConexion)

                    If IsArray(objArraySucursalRecibo) AndAlso (objArraySucursalRecibo.Length > 0) Then
                        strRegistroSucursalRecibo = DirectCast(objArraySucursalRecibo.GetValue(0), String())

                        strErrorSucursal = "0"
                        intCompaniaReciboId = CInt(strRegistroSucursalRecibo(0))
                        intSucursalReciboId = CInt(strRegistroSucursalRecibo(1))
                        strDecripcionSucursalRecibo = clsCommons.strFormatearDescripcion(CStr(strRegistroSucursalRecibo.GetValue(2)))
                        intUenSucursalReciboId = CInt(strRegistroSucursalRecibo(3))

                        If intCompaniaReciboId = intCompaniaId And intSucursalReciboId = intSucursalId Then
                            strErrorSucursal = "-80" ' Sucursal de Recibo no puede ser la misma origen
                            intCompaniaReciboId = 0
                            intSucursalReciboId = 0
                            strDecripcionSucursalRecibo = ""
                            intUenSucursalReciboId = 0
                        End If

                        If cboTipoTES = "1" And (intUenSucursalReciboId = 10 Or intUenSucursalReciboId = 12) And (strcboMotivo <> "2" And strcboMotivo <> "3") Then
                            strErrorSucursal = "-110" ' Para transferencias normales no se pueden enviar a almacenes UEN 10 ó fotolabs uen 12
                            intCompaniaReciboId = 0
                            intSucursalReciboId = 0
                            strDecripcionSucursalRecibo = ""
                            intUenSucursalReciboId = 0
                        End If

                        If cboTipoTES <> "1" And intUenSucursalReciboId <> 10 Then
                            strErrorSucursal = "-120"  ' Para transferencias de devolucion/reclamacion deben ser solo almacenes
                            intCompaniaReciboId = 0
                            intSucursalReciboId = 0
                            strDecripcionSucursalRecibo = ""
                            intUenSucursalReciboId = 0
                        End If


                    Else
                        strErrorSucursal = "-90" ' Compañia - Sucursal no existe
                        intCompaniaReciboId = 0
                        intSucursalReciboId = 0
                        strDecripcionSucursalRecibo = ""
                        intUenSucursalReciboId = 0
                    End If

                Else
                    strErrorSucursal = "-100" ' Compañia - Sucursal mal capturadas
                    intCompaniaReciboId = 0
                    intSucursalReciboId = 0
                    strDecripcionSucursalRecibo = ""
                    intUenSucursalReciboId = 0
                End If

                strHTML.Append("<script language='javascript'> parent.fnUpdCiaSucursalPorIframe( " & _
                               "'" & intCompaniaReciboId.ToString & "', " & _
                               "'" & intSucursalReciboId.ToString & "', " & _
                               "'" & strDecripcionSucursalRecibo & "', " & _
                               "'" & intUenSucursalReciboId.ToString & "', " & _
                               "'" & strErrorSucursal & "'  " & _
                                ") </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscaRemision"

                strHTML = New StringBuilder

                Dim objArrayRemision As Array = Nothing
                Dim strRegistroRemision As String()

                Dim intRemisionId As Integer = 0
                Dim strErrorRemision As String = ""

                objArrayRemision = clsConcentrador.clsSucursal.clsMercancia.clsRemisionElectronica.strBuscarRemisionConfirmada(intCompaniaId, intSucursalId, intProveedorRemisionCapturada, strNumeroRemisionCapturada, "CONFIRMADA", strCadenaConexion)

                If IsArray(objArrayRemision) AndAlso (objArrayRemision.Length > 0) Then
                    strRegistroRemision = DirectCast(objArrayRemision.GetValue(0), String())
                    intRemisionId = CInt(strRegistroRemision(0))
                    strErrorRemision = "0"
                Else
                    strErrorRemision = "-100"
                End If

                strHTML.Append("<script language='javascript'> parent.fnUpdRemisionPorIframe( " & _
                              "'" & intRemisionId.ToString & "', " & _
                              "'" & strErrorRemision & "'  " & _
                               ") </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "BuscarArticulo"

                strHTML = New StringBuilder

                Dim strAccion As String = "0" ' BUSCAR ARTICULO
                Dim strErrorBuscaArticulo As String = ""
                Dim strListaArticulos As String = ""

                Dim objArrayArticulo As Array = Nothing
                Dim strRegistroArticulo As String()

                Dim intArticuloBuscadoId As Integer = 0
                Dim strArticuloBuscadoDescripcion As String = ""
                Dim dblArticuloBuscadoPrecio As Double = 0

                intTransferenciaId = CInt(strTxtintTransferenciaId)

                ' Obtenemos la información del Articulo

                objArrayArticulo = clsConcentrador.clsSucursal.strBuscarArticulo(intCompaniaId, intSucursalId, strtxtIntArticuloId, 1, 1, strCadenaConexion)

                If IsArray(objArrayArticulo) AndAlso (objArrayArticulo.Length > 0) Then
                    strRegistroArticulo = DirectCast(objArrayArticulo.GetValue(0), String())

                    intArticuloBuscadoId = CInt(strRegistroArticulo(0))
                    strArticuloBuscadoDescripcion = clsCommons.strFormatearDescripcion(strRegistroArticulo(5))
                    dblArticuloBuscadoPrecio = CDbl(strRegistroArticulo(3))
                    strErrorBuscaArticulo = "0"
                Else
                    intArticuloBuscadoId = 0
                    strArticuloBuscadoDescripcion = ""
                    dblArticuloBuscadoPrecio = 0
                    strErrorBuscaArticulo = "-100"
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                               strComitasDobles & strAccion & strComitasDobles & "," & _
                               strComitasDobles & intTransferenciaId.ToString & strComitasDobles & "," & _
                               strComitasDobles & intArticuloBuscadoId.ToString & strComitasDobles & "," & _
                               strComitasDobles & strArticuloBuscadoDescripcion & strComitasDobles & "," & _
                               strComitasDobles & dblArticuloBuscadoPrecio.ToString & strComitasDobles & "," & _
                               strComitasDobles & strListaArticulos & strComitasDobles & "," & _
                               strComitasDobles & intArticulosListaTransferencia.ToString & strComitasDobles & "," & _
                               strComitasDobles & strErrorBuscaArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarArticulo"

                strHTML = New StringBuilder
                strListaTransferenciaHTML = ""

                Dim strAccion As String = "1"   ' AGREGAR ARTICULO
                Dim strComitasDobles As String = """"
                Dim strErrorAgregarArticulo As String = ""

                Dim objArrayTransferencia As Array = Nothing
                Dim strRegistroTransferencia As String()

                Dim intArticuloId As Integer
                Dim intCompaniaDestinoId As Integer = 0
                Dim intSucursalDestinoId As Integer = 0
                Dim intNumeroRemisionCapturada As Integer = 0
                Dim fltArticuloEstadoTransferenciaPrecioVenta As Double = 0

                intTransferenciaId = CInt(strTxtintTransferenciaId)

                'Registrar la Transferencia Manual si aun no esta registrada
                If intTransferenciaId.Equals(0) Then

                    'Registrar Transferencia
                    intCompaniaDestinoId = CInt(strtxtCompaniaQueRecibe)
                    intSucursalDestinoId = CInt(strtxtSucursalQueRecibe)

                    If IsNumeric(strNumeroRemisionCapturada) Then
                        intNumeroRemisionCapturada = CInt(strNumeroRemisionCapturada)
                    Else
                        intNumeroRemisionCapturada = 0
                    End If

                    intTransferenciaId = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intAgregarTransferenciaManual(intCompaniaId, intSucursalId, intCompaniaDestinoId, intSucursalDestinoId, CInt(strcboMotivo), CDate("01/01/1900"), 0, True, "ENVIADA", strObservacionesCapturadas, intEmpleadoAutorizadoId, intNumeroRemisionCapturada, strUsuarioNombre, strCadenaConexion)

                End If

                If intTransferenciaId > 0 Then
                    'Agregar Articulo al  Detalle

                    intArticuloId = CInt(strtxtIntArticuloId)
                    fltArticuloEstadoTransferenciaPrecioVenta = CDbl(Request.Form("hdnPrecioNormalConImpuesto"))

                    intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intAgregarArticulo(intTransferenciaId, "ENVIADA", 0, "", intArticuloId, CInt(strTxtCantidad), fltArticuloEstadoTransferenciaPrecioVenta, Date.Now, strUsuarioNombre, strCadenaConexion)
                    If intResultado < 1 Then
                        strErrorAgregarArticulo = "-110" ' Articulo no puedo agregarse a la transferencia
                    Else
                        strErrorAgregarArticulo = "0"
                    End If

                Else
                    strErrorAgregarArticulo = "-100" 'Transferenica no pudo Registrarse
                End If

                'Buscar Detalle De la transferencia
                If intTransferenciaId > 0 Then

                    objArrayTransferencia = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, intTransferenciaId, "ENVIADA", 0, 0, strCadenaConexion)

                    strListaTransferenciaHTML = strGeneraListaTransferencia(objArrayTransferencia, 0, "Detalles transferencia", "No.", "", "Código", "Descripción", "P. venta", "Importe", "Cantidad", "Acción")

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                               strComitasDobles & strAccion & strComitasDobles & "," & _
                               strComitasDobles & intTransferenciaId.ToString & strComitasDobles & "," & _
                               strComitasDobles & "0" & strComitasDobles & "," & _
                               strComitasDobles & "0" & strComitasDobles & "," & _
                               strComitasDobles & "0" & strComitasDobles & "," & _
                               strComitasDobles & strListaTransferenciaHTML & strComitasDobles & "," & _
                               strComitasDobles & intArticulosListaTransferencia.ToString & strComitasDobles & "," & _
                               strComitasDobles & strErrorAgregarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()


            Case "EliminarArticulo"

                strHTML = New StringBuilder
                strListaTransferenciaHTML = ""

                Dim strAccion As String = "2"   ' ELIMINAR ARTICULO
                Dim strComitasDobles As String = """"
                Dim strErrorEliminarArticulo As String = ""

                Dim objArrayTransferencia As Array = Nothing
                Dim strRegistroTransferencia As String()

                Dim intTransferenciaIdEliminar, intArticuloIdEliminar As Integer
                Dim intTipoEstadoTransferenciaId As Integer

                intTransferenciaId = CInt(strTxtintTransferenciaId)

                intTransferenciaIdEliminar = CInt(Request.QueryString("intTransferenciaIdEliminar"))
                intArticuloIdEliminar = CInt(Request.QueryString("intArticuloIdEliminar"))

                'Buscar intTipoEstadoTransferenciaId
                objArray = Nothing
                objArray = clstblTipoEstadoTransferencia.strBuscar(0, "", "ENVIADA", CDate("01/01/1900"), "", 1, 1, strCadenaConexion)
                intTipoEstadoTransferenciaId = 0
                If IsArray(objArray) AndAlso (objArray.Length > 0) Then
                    strRegistro = DirectCast(objArray.GetValue(0), String())
                    intTipoEstadoTransferenciaId = CInt(strRegistro(0))
                End If

                ' Eliminar Articulo
                If intTipoEstadoTransferenciaId > 0 Then
                    intResultado = clstblArticuloEstadoTransferencia.intEliminar(intTransferenciaIdEliminar, intTipoEstadoTransferenciaId, intArticuloIdEliminar, 0, "", 0, 0, CDate("01/01/1900"), CDate("01/01/1900"), "", strCadenaConexion)

                    If intResultado > 0 Then
                        strErrorEliminarArticulo = "0"
                    Else
                        strErrorEliminarArticulo = "-100"
                    End If

                End If


                'Buscar Detalle De la transferencia
                If intTransferenciaId > 0 Then

                    objArrayTransferencia = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, intTransferenciaId, "ENVIADA", 0, 0, strCadenaConexion)
                    strListaTransferenciaHTML = strGeneraListaTransferencia(objArrayTransferencia, 0, "Detalle Transferencia", "No.", "", "Código", "Descripción", "P. venta", "Importe", "Cantidad", "Acción")

                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdArticuloPorIframe( " & _
                               strComitasDobles & strAccion & strComitasDobles & "," & _
                               strComitasDobles & intTransferenciaId.ToString & strComitasDobles & "," & _
                               strComitasDobles & "0" & strComitasDobles & "," & _
                               strComitasDobles & "0" & strComitasDobles & "," & _
                               strComitasDobles & "0" & strComitasDobles & "," & _
                               strComitasDobles & strListaTransferenciaHTML & strComitasDobles & "," & _
                               strComitasDobles & intArticulosListaTransferencia.ToString & strComitasDobles & "," & _
                               strComitasDobles & strErrorEliminarArticulo & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "AgregarBulto"

                strHTML = New StringBuilder

                Dim objArrayBulto As Array = Nothing
                Dim strRegistroBulto As String()
                Dim strListaBultos As String = ""

                Dim strErrorBulto As String = ""

                intTransferenciaId = CInt(strTxtintTransferenciaId)

                If intTransferenciaId > 0 Then
                    'Agregar el bulto al  Detalle de la transferencia

                    If Len(strNumeroBulto) > 0 Then
                        intResultado = clstblBultoEstadoTransferencia.intAgregar(intTransferenciaId, 2, strNumeroBulto, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

                        If intResultado < 1 Then
                            strErrorBulto = "-120"  ' No se puede agregar el bulto
                        End If

                    Else
                        strErrorBulto = "-110" ' No se capturo el numero de bulto
                    End If
                Else
                    strErrorBulto = "-100" 'No existe Detalle de transferencia
                End If

                Dim strComitasDobles As String = """"
                Dim strAccion As String = "1" 'Agregar de Bulto

                'Consultamos los bultos de la transferencia
                objArrayBulto = clstblBultoEstadoTransferencia.strBuscar(intTransferenciaId, 2, "", CDate("01/01/1900"), strUsuarioNombre, 0, 0, strCadenaConexion)

                If IsArray(objArrayBulto) AndAlso (objArrayBulto.Length > 0) Then
                    strListaBultos = strGeneraListaBultos(objArrayBulto)
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdBultoPorIframe( " & _
                               strComitasDobles & strAccion & strComitasDobles & "," & _
                               strComitasDobles & strListaBultos & strComitasDobles & "," & _
                               strComitasDobles & intBultosListaTransferencia.ToString & strComitasDobles & "," & _
                               strComitasDobles & strErrorBulto & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "EliminarBulto"

                strHTML = New StringBuilder

                Dim objArrayBulto As Array = Nothing
                Dim strRegistroBulto As String()
                Dim strListaBultos As String = ""

                Dim strComitasDobles As String = """"
                Dim strAccion As String = "2" 'Eliminar Bulto

                Dim intTransferenciaBultoEliminarId As Integer = 0
                Dim strNumeroBultoEliminarId As String = ""

                Dim strErrorBulto As String = ""

                intTransferenciaId = CInt(strTxtintTransferenciaId)

                intTransferenciaBultoEliminarId = CInt(Request.QueryString("intTransferenciaBultoEliminarId"))
                strNumeroBultoEliminarId = Request.QueryString("strNumeroBultoEliminarId")

                intResultado = clstblBultoEstadoTransferencia.intEliminar(intTransferenciaBultoEliminarId, 2, strNumeroBultoEliminarId, CDate("01/01/1900"), strUsuarioNombre, strCadenaConexion)

                If intResultado > 0 Then
                    strErrorBulto = "0"  ' Se Elimino el bulto
                Else
                    strErrorBulto = "-100"  ' No se puede Eliminar el bulto
                End If

                'Consultamos los bultos de la transferencia
                objArrayBulto = clstblBultoEstadoTransferencia.strBuscar(intTransferenciaId, 2, "", CDate("01/01/1900"), strUsuarioNombre, 0, 0, strCadenaConexion)

                If IsArray(objArrayBulto) AndAlso (objArrayBulto.Length > 0) Then
                    strListaBultos = strGeneraListaBultos(objArrayBulto)
                End If

                strHTML.Append("<script language='Javascript'> parent.fnUpdBultoPorIframe( " & _
                              strComitasDobles & strAccion & strComitasDobles & "," & _
                              strComitasDobles & strListaBultos & strComitasDobles & "," & _
                              strComitasDobles & intBultosListaTransferencia.ToString & strComitasDobles & "," & _
                              strComitasDobles & strErrorBulto & strComitasDobles & _
                              "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

            Case "RegistrarTransferencia"

                strHTML = New StringBuilder

                Dim objArrayTransferencia As Array = Nothing
                Dim strRegistroTransferencia As String()
                Dim strListaTransferencia As String = ""
                Dim strErrorRegistrarTransferencia As String = ""

                Dim strComitasDobles As String = """"


                intTransferenciaId = CInt(strTxtintTransferenciaId)

                If Trim(Request.Form("txtIntFolioTransferencia")).Equals("") Then
                    intResultado = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intRegistrarTransferenciaManual(intCompaniaId, intSucursalId, intTransferenciaId, "ENVIADA", strUsuarioNombre, strCadenaConexion)
                    If (intResultado > 0) Then

                        intmTransferenciaFolio = intResultado
                        strErrorRegistrarTransferencia = "0"
                    Else
                        strErrorRegistrarTransferencia = "-100"
                        '"No fue posible registrar la transferencia manual."

                    End If
                End If

                If intTransferenciaId > 0 Then

                    '-------------------------------------------------------------
                    'La Transferencia se registro exitosamente hay que mandarla al
                    'servidor de la sucursal que la capturo para registrarla en CTF
                    '-------------------------------------------------------------

                    Dim objArrayMotivos As Array = Nothing
                    Dim strRegistroMotivos As String() = Nothing
                    Dim strEnvioCTF As String = ""

                    objArrayMotivos = clstblMotivoTransferencia.strBuscar(CInt(strcboMotivo), "", "", 0, CDate("01/01/1900"), "", 0, 0, strCadenaConexion)

                    If IsArray(objArrayMotivos) AndAlso (objArrayMotivos.Length > 0) Then

                        strRegistroMotivos = DirectCast(objArrayMotivos.GetValue(0), String())
                        strEnvioCTF = CStr(strRegistroMotivos(6))

                    End If

                    If strEnvioCTF = "True" Then

                        clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.intTransmitir(intCompaniaId, intSucursalId, intTransferenciaId, "ENVIADA", strCadenaConexion)

                    End If

                    objArrayTransferencia = clsConcentrador.clsSucursal.clsMercancia.clsInventario.clsTransferencia.strBuscarDetalle(intCompaniaId, intSucursalId, intTransferenciaId, "ENVIADA", 0, 0, strCadenaConexion)
                    strListaTransferencia = strGeneraListaTransferencia(objArrayTransferencia, 0, "Detalles Transferencia", "No.", "", "Código", "Descripción", "P. venta", "Importe", "Cantidad", "Acción")
                    

                End If

                strHTML.Append("<script language='Javascript'> parent.fnRegistrarTransferenciaPorIframe( " & _
                               strComitasDobles & intTransferenciaId.ToString & strComitasDobles & "," & _
                               strComitasDobles & intmTransferenciaFolio.ToString & strComitasDobles & "," & _
                               strComitasDobles & strListaTransferencia & strComitasDobles & "," & _
                               strComitasDobles & intArticulosListaTransferencia.ToString & strComitasDobles & "," & _
                               strComitasDobles & strErrorRegistrarTransferencia & strComitasDobles & _
                               "); </script>")

                Response.Write(strHTML.ToString)
                Response.End()

        End Select


    End Sub
End Class
