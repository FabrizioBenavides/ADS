'====================================================================
' Page          : SucursalEmpleadosControlAsistenciaAdministracionEmpleadosModificaciones.aspx
' Title         : Administracion de Asistencias de Empleados
' Description   : P�gina donde se administran las Asistencias de los Empleados de la Sucursal
' Company       : Softtek
' Author        : Jes�s Miguel Gil G.
' Version       : 1.0
' Last Modified : 20/05/2008
'====================================================================
Imports Benavides.POSAdmin
Imports Benavides.POSAdmin.Commons
Imports Benavides.POSAdmin.Data
Imports Benavides.POSAdmin.Business
Imports Isocraft.Web.Http
Imports System.Text
Imports System.Diagnostics
Imports Microsoft.VisualBasic.Collection

Public Class SucursalEmpleadoControlAsistenciaAdministracionEmpleadosModificaciones
    Inherits System.Web.UI.Page

    Dim strmGrupoDescripcion As String

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

    Dim objResultArray As Array
    Dim objEmpleadoArray As Array
    Dim objVacacionesArray, objIncapacidadMedicaArray, objPermisoEspecialArray As Array
    Dim resultArray As Array
    Dim strResultArray As String
    Dim strHtmlCode As StringBuilder
    Public strmMensaje As String

    '====================================================================
    ' Name       : strRedirectPage
    ' Description: P�gina hacia la cual se debe redireccionar al usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strRedirectPage() As String

        Get

            Return "/Default.aspx?strURL=" & Server.UrlEncode(Request.ServerVariables("SCRIPT_NAME"))
        End Get

    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: Valor de la acci�n de la forma HTML
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
    ' Description: URL de esta p�gina
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
    ' Description: Valor de la Compa�ia
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
    ' Name       : strMensaje
    ' Description: Valor para mostrar como mensaje
    ' Accessor   : Read and Write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strMensaje() As String
        Get
            If IsNothing(strmMensaje) Then
                Return ""
            Else
                Return strmMensaje
            End If
        End Get
        Set(ByVal Value As String)
            strmMensaje = Value
        End Set
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
    ' Name       : strGrupoDescripcion
    ' Description: Coomando seleccionado
    ' Accessor   : Read / Write
    ' Output     : String
    '====================================================================
    Public Property strGrupoDescripcion() As String
        Get
            Return strmGrupoDescripcion
        End Get
        Set(ByVal strValue As String)
            strmGrupoDescripcion = strValue
        End Set
    End Property

    '====================================================================
    ' Name       : strDiadeDescanso
    ' Description: Regresa un entero que indica cual es el dia de descanso
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDiadeDescanso() As String

        Get
            Dim strSucursalEmpleadoRol As String()
            Dim blnEsGodinez As Boolean = False

            Dim intDia As String = Convert.ToString(DirectCast(resultArray.GetValue(1), String))

            'Obtenemos el grupo al que pertenece para saber si es de Empleado Oficina
            objArrayEmpleadoRol = Business.clsSucursal.clsEmpleado.strBuscar(intCompaniaId, intSucursalId, intEmpleadoId, False, strCadenaConexion)

            If IsArray(objArrayEmpleadoRol) AndAlso objArrayEmpleadoRol.Length > 0 Then

                strSucursalEmpleadoRol = DirectCast(objArrayEmpleadoRol.GetValue(0), String())

                If Len(strSucursalEmpleadoRol(11)) > 0 Then

                    strmGrupoDescripcion = strSucursalEmpleadoRol(11).ToString().Trim()

                    If strmGrupoDescripcion = "ADMINISTRATIVO" Then
                        blnEsGodinez = True
                    End If

                End If
            End If

            strHtmlCode = New StringBuilder
            strHtmlCode.Append("<SELECT class='campotabla' id='cmdDiaDescanso' onChange='cambioDiaDescanso()' style='width:150'>")

            'If ((intDia <> "1") And (intDia <> "2") And (intDia <> "3") And (intDia <> "4") And (intDia <> "5") And (intDia <> "6") And (intDia <> "7")) And (blnEsGodinez = False) Then
            If ((intDia <> "1") And (intDia <> "2") And (intDia <> "3") And (intDia <> "4") And (intDia <> "5") And (intDia <> "6") And (intDia <> "7")) Then
                strHtmlCode.Append("<OPTION value='0' selected></OPTION>")
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If


            'If (intDia = "1") Or (blnEsGodinez = True) Then
            If (intDia = "1") Then
                strHtmlCode.Append("<OPTION value='1' selected>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")
            End If
            'If (intDia = "2") And (blnEsGodinez = False) Then
            If (intDia = "2") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2' selected>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If
            'If (intDia = "3") And (blnEsGodinez = False) Then
            If (intDia = "3") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3' selected>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If
            'If (intDia = "4") And (blnEsGodinez = False) Then
            If (intDia = "4") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4' selected>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If
            'If (intDia = "5") And (blnEsGodinez = False) Then
            If (intDia = "5") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5' selected>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If
            'If (intDia = "6") And (blnEsGodinez = False) Then
            If (intDia = "6") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6' selected>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7'>Sabado</OPTION>")

            End If

            'If (intDia = "7") And (blnEsGodinez = False) Then
            If (intDia = "7") Then
                strHtmlCode.Append("<OPTION value='1'>Domingo</OPTION>")
                strHtmlCode.Append("<OPTION value='2'>Lunes</OPTION>")
                strHtmlCode.Append("<OPTION value='3'>Martes</OPTION>")
                strHtmlCode.Append("<OPTION value='4'>Miercoles</OPTION>")
                strHtmlCode.Append("<OPTION value='5'>Jueves</OPTION>")
                strHtmlCode.Append("<OPTION value='6'>Viernes</OPTION>")
                strHtmlCode.Append("<OPTION value='7' selected>Sabado</OPTION>")

            End If

            Return strHtmlCode.ToString()

        End Get

    End Property


    '====================================================================
    ' Name       : strBajaTemporal
    ' Description: Indica si el empleado esta o no de baja temporal
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strBajaTemporal() As String

        Get
            strHtmlCode = New StringBuilder

            Dim blnBajaTemporal As Boolean = Convert.ToBoolean(DirectCast(resultArray.GetValue(2), String))
            If blnBajaTemporal Then
                strHtmlCode.Append("<INPUT type='checkbox' name='chkBajaTemporal' checked>")
            Else
                strHtmlCode.Append("<INPUT type='checkbox' name='chkBajaTemporal'>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property


    Public ReadOnly Property strCamposHidden() As String

        Get
            Dim intVacacionesId As Integer = Convert.ToInt16(DirectCast(resultArray.GetValue(3), String))
            Dim intPermisoId As Integer = Convert.ToInt16(DirectCast(resultArray.GetValue(6), String))
            Dim intIncapacidadId As Integer = Convert.ToInt16(DirectCast(resultArray.GetValue(11), String))
            Dim intCapacitacionId As Integer = Convert.ToInt16(DirectCast(resultArray.GetValue(21), String))

            Dim htmlCode As StringBuilder
            htmlCode = New StringBuilder
            htmlCode.Append("<INPUT type='hidden' name='hdnVacacionesId' value='")
            htmlCode.Append(intVacacionesId)
            htmlCode.Append("'>")
            htmlCode.Append("<INPUT type='hidden' name='hdnPermisoId' value='")
            htmlCode.Append(intPermisoId)
            htmlCode.Append("'>")
            htmlCode.Append("<INPUT type='hidden' name='hdnIncapacidadId' value='")
            htmlCode.Append(intIncapacidadId)
            htmlCode.Append("'>")
            htmlCode.Append("<INPUT type='hidden' name='hdnCapacitacionId' value='")
            htmlCode.Append(intCapacitacionId)
            htmlCode.Append("'>")


            Return htmlCode.ToString
        End Get

    End Property

    '====================================================================
    ' Name       : strDiasDisponiblesVacaciones
    ' Description: Retorna el # de dias disponibles de vacaciones
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strDiasDisponiblesVacaciones() As String

        Get

            Dim intDiasVacaciones As Integer = Convert.ToInt16(DirectCast(resultArray.GetValue(0), String))



            Return intDiasVacaciones.ToString
        End Get

    End Property

    '====================================================================
    ' Name       : strVacacionesFechaInicio
    ' Description: Indica la fecha de inicio de vacaciones en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strVacacionesFechaInicio() As String

        Get
            strHtmlCode = New StringBuilder
            Dim dia As String = ""
            Dim strOrigen As String = "2"
            Dim strVacacionesInicio As String = DirectCast(resultArray.GetValue(4), String)
            If strVacacionesInicio <> "1/1/1900" Then
                If Convert.ToDateTime(strVacacionesInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtVacacionesInicio' name='txtVacacionesInicio' onChange='cambioVacacionesFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strVacacionesInicio)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtVacacionesInicio' name='txtVacacionesInicio' onChange='cambioVacacionesFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strVacacionesInicio)) + "'>")
                End If


            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtVacacionesInicio' name='txtVacacionesInicio' onChange='cambioVacacionesFechaInicio()' value=''>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property


    '====================================================================
    ' Name       : strIncapacidadMedicaFechaInicio
    ' Description: Indica la fecha de inicio de la incapacidad medica en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strIncapacidadMedicaFechaInicio() As String

        Get
            strHtmlCode = New StringBuilder
            Dim strFechaInicio As String = DirectCast(resultArray.GetValue(12), String)
            If strFechaInicio <> "1/1/1900" Then
                If Convert.ToDateTime(strFechaInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtIncapacidadMedicaInicio' name='txtIncapacidadMedicaInicio' onChange='cambioIncapacidadFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strFechaInicio)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtIncapacidadMedicaInicio' name='txtIncapacidadMedicaInicio' onChange='cambioIncapacidadFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strFechaInicio)) + "'>")
                End If
            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtIncapacidadMedicaInicio' name='txtIncapacidadMedicaInicio' onChange='cambioIncapacidadFechaInicio()' value=''>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property
    '====================================================================
    ' Name       : strIncapacidadMedicaMotivos
    ' Description: Retorna todos los motivos de incapacidad de la base de datos y si el usuario ya tiene un permiso asignado el combo seleccionara por default este valor
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strIncapacidadMedicaMotivos() As String

        Get
            Dim strMotivosIncapacidad As Array
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder
            Dim resString As String

            strMotivosIncapacidad = Business.clsSucursal.strBuscarMotivosIncapacidad(strCadenaConexion)
            Dim i As Integer = 0
            'llenando combo con los motivos de incapacidad
            Dim strMotivo As String = DirectCast(resultArray.GetValue(14), String)
            Dim j As Integer = 0
            strHtmlCode.Append("<SELECT id='cboMotivos' class='campotabla' onChange='cambioMotivos()' style='width:200'>")

            While j <= strMotivosIncapacidad.Length - 1
                Dim res As String() = DirectCast(strMotivosIncapacidad.GetValue(j), String())
                If strMotivo = res(0) Then
                    strHtmlCode.Append("<OPTION  value='" + res(0) + "' selected>" + res(1) + "</OPTION>")
                Else
                    strHtmlCode.Append("<OPTION value='" + res(0) + "'>" + res(1) + "</OPTION>")
                End If
                j = j + 1
            End While
            strHtmlCode.Append("</SELECT>")

            Return strHtmlCode.ToString()
        End Get

    End Property

    '====================================================================
    ' Name       : strIncapacidadMedicaFechaFin()
    ' Description: Indica la fecha de Fin de la incapacidad medica en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strIncapacidadMedicaFechaFin() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder
            Dim strFechaFinal As String = DirectCast(resultArray.GetValue(13), String)
            Dim strFechaInicio As String = DirectCast(resultArray.GetValue(12), String)
            If strFechaFinal <> "1/1/1900" Then
                If Convert.ToDateTime(strFechaInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtIncapacidadMedicaFinal' name='txtIncapacidadMedicaFinal' onChange='cambioIncapacidadFechaFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strFechaFinal)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtIncapacidadMedicaFinal' name='txtIncapacidadMedicaFinal' onChange='cambioIncapacidadFechaFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strFechaFinal)) + "'>")
                End If
            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtIncapacidadMedicaFinal' name='txtIncapacidadMedicaFinal' onChange='cambioIncapacidadFechaFin()' value=''>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property


    '====================================================================
    ' Name       : strIncapacidadMedicaFolio
    ' Description: Indica la fecha de Fin de la incapacidad medica en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strIncapacidadMedicaFolio() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder
            Dim strFolio As String = DirectCast(resultArray.GetValue(15), String)
            If strFolio <> "0" Then

                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='49' size='6' name='txtFolio' onChange='cambioFolio()' value='" + strFolio + "'>")

            Else

                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='49' size='6' name='txtFolio' onChange='cambioFolio()' value=''>")

            End If
            Return strHtmlCode.ToString()
        End Get

    End Property
    '====================================================================
    ' Name       : strPermisoEspecialFechaInicio()
    ' Description: Indica la fecha de Inicio de un permiso Especial en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPermisoEspecialFechaInicio() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder

            Dim strPermisoInicio As String = DirectCast(resultArray.GetValue(7), String)
            If strPermisoInicio <> "1/1/1900" Then
                If Convert.ToDateTime(strPermisoInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtPermisoEspecialInicio' name='txtPermisoEspecialInicio' onChange='cambioPermisoEspecialFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strPermisoInicio)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtPermisoEspecialInicio' name='txtPermisoEspecialInicio' onChange='cambioPermisoEspecialFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strPermisoInicio)) + "'>")
                End If
            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtPermisoEspecialInicio' name='txtPermisoEspecialInicio' onChange='cambioPermisoEspecialFechaInicio()' value=''>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property

    '====================================================================
    ' Name       : strPermisoEspecialFechaFin()
    ' Description: Indica la fecha de Fin de un permiso Especial en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strPermisoEspecialFechaFin() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder

            Dim strPermisoFin As String = DirectCast(resultArray.GetValue(8), String)
            Dim strPermisoInicio As String = DirectCast(resultArray.GetValue(7), String)
            If strPermisoFin <> "1/1/1900" Then
                If Convert.ToDateTime(strPermisoInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtPermisoEspecialFin' name='txtPermisoEspecialFin' onChange='cambioPermisoEspecialFechaFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strPermisoFin)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtPermisoEspecialFin' name='txtPermisoEspecialFin' onChange='cambioPermisoEspecialFechaFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strPermisoFin)) + "'>")
                End If
            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtPermisoEspecialFin' name='txtPermisoEspecialFin' onChange='cambioPermisoEspecialFechaFin()' value=''>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property

    '====================================================================
    ' Name       : strPermisoEspecialConSueldo()
    ' Description: Indica si el permiso especial se realizo con sueldo o sin sueldo, regresa un checkbox dependiendo del caso
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public ReadOnly Property strPermisoEspecialConSueldo() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder

            Dim blnPermisoEspecialConSueldo As Boolean = Convert.ToBoolean(DirectCast(resultArray.GetValue(9), String))
            If blnPermisoEspecialConSueldo Then
                strHtmlCode.Append("<INPUT type='checkbox' name='chkPermisoEspecialConSueldo' checked>")
            Else
                strHtmlCode.Append("<INPUT type='checkbox' name='chkPermisoEspecialConSueldo'>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property


    '====================================================================
    ' Name       : strVacacionesFechaFin
    ' Description: Indica la fecha de Fin de vacaciones en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strVacacionesFechaFin() As String

        Get
            Dim dia As String = ""
            Dim strOrigen As String = "3"
            strHtmlCode = New StringBuilder

            Dim strVacacionesFin As String = DirectCast(resultArray.GetValue(5), String)
            If strVacacionesFin <> "1/1/1900" Then
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtVacacionesFin' name='txtVacacionesFin' onChange='cambioVacacionesFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strVacacionesFin)) + "'>")
            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtVacacionesFin' name='txtVacacionesFin' onChange='cambioVacacionesFin()' value=''>")
            End If
            Return strHtmlCode.ToString()
        End Get

    End Property
    'Permite consultar el array Principal de consulta cargado desde el evento Load
    Public Function ConsultaArray(ByVal parametro As Int16) As String
        Return Convert.ToString(DirectCast(resultArray.GetValue(parametro), String))
    End Function
    Public Function ConsultarDiasFestivos() As String
        Dim strDiasFestivos As Array
        Dim resString As String
        strDiasFestivos = Business.clsSucursal.strBuscarDiasFestivos(strCadenaConexion)
        Dim i As Integer = 0
        While i <= strDiasFestivos.Length - 1
            Dim res As String() = DirectCast(strDiasFestivos.GetValue(i), String())
            'resString = resString + clsCommons.strFormatearFechaPresentacion(CStr(res(0))) + ","
            resString = resString + res(0) + ","
            i = i + 1
        End While
        ConsultarDiasFestivos = resString

    End Function
    '====================================================================
    ' Name       : strNombreDeEmpleado()
    ' Description: Indica si el permiso especial se realizo con sueldo o sin sueldo, regresa un checkbox dependiendo del caso
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================

    Public ReadOnly Property strNombreDeEmpleado() As String

        Get
            'Function strNombreDeEmpleado()
            'Dim strHtmlCode As StringBuilder
            'strHtmlCode = New StringBuilder
            'Dim strApPaterno As String = DirectCast(resultArray.GetValue(16), String)
            'Dim strApMaterno As String = DirectCast(resultArray.GetValue(17), String)
            'Dim strNombre As String = DirectCast(resultArray.GetValue(18), String)
            'strHtmlCode.Append("<INPUT class='campotabla' disabled type='text' size='50' name='txtEmpleadoNombre' value='" + Trim(strApPaterno) + " " + Trim(strApMaterno) + " " + Trim(strNombre) + "'>")
            'strHtmlCode.Append("<INPUT class='campotabla' type='hidden' name='hdnEmpleadoNombre' value='" + Trim(strApPaterno) + " " + Trim(strApMaterno) + " " + Trim(strNombre) + "'>")
            'Return strHtmlCode.ToString()








            ' Declaraci�n e inicializaci�n de las variables locales
            'Dim objArrayConsulta As Array = Nothing
            'Dim strGeneraTabla As StringBuilder
            'Dim strTabla As String() = Nothing
            'Dim strTablaEmpleado As String
            'Dim strTablaNombre As String
            'Dim i As Integer

            'strGeneraTabla = New StringBuilder

            '' Obtenemos todos los empleados y sus movimientos
            'objArrayConsulta = Business.clsSucursal.clsEmpleado.strBuscarEmpleadoAsistencia(intCompaniaId(), intSucursalId(), 0, 1, strCadenaConexion)

            'If IsArray(objArrayConsulta) AndAlso objArrayConsulta.Length > 0 Then

            '    strGeneraTabla.Append("<SELECT class='campotabla' name='cboEmpleados' onChange='javascript:cboEmpleados_onchange()'><OPTION selected>TODOS</OPTION>")

            '    For i = 0 To objArrayConsulta.Length - 1

            '        ' Sacamos del arreglo la cadena con el nombre del empleado
            '        strTabla = DirectCast(objArrayConsulta.GetValue(i), String())
            '        strTablaNombre = DirectCast(strTabla(1), String).Trim & " " & DirectCast(strTabla(2), String).Trim & " " & DirectCast(strTabla(3), String).Trim
            '        strTablaEmpleado = DirectCast(strTabla(0), String)
            '        ' Agregamos nuevo option al combo 
            '        strGeneraTabla.Append("<OPTION value='" & strTablaEmpleado & "'>" & strTablaNombre & "</OPTION>")
            '    Next
            '    strGeneraTabla.Append("</SELECT>")
            '    For i = 0 To objArrayConsulta.Length - 1

            '        ' Sacamos del arreglo la cadena con el nombre del empleado
            '        strTabla = DirectCast(objArrayConsulta.GetValue(i), String())
            '        strTablaEmpleado = DirectCast(strTabla(0), String)

            '        ' Agregamos nuevo option al combo 
            '        strGeneraTabla.Append("<TD><input type='hidden' name='hdnElegido" & i.ToString & "' value='" & strTablaEmpleado & "'></TD>")
            '    Next
            '    strGeneraTabla.Append("<TD><input type='hidden' name='hdnElegido'></TD>")
            'End If
            ''strGeneraHTML = strGeneraTabla.ToString
            'Return strHtmlCode.ToString()




        End Get



    End Property

    '====================================================================
    ' Name       : strllenarComboEmpleados()
    ' Description: Crea un combo con todos los empleados de la sucursal
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strllenarComboEmpleados() As String

        ' Declaraci�n e inicializaci�n de las variables locales
        Dim objArrayConsulta As Array = Nothing
        Dim strGeneraTabla As StringBuilder
        Dim strTabla As String() = Nothing
        Dim strTablaEmpleado As String
        Dim strTablaNombre As String
        Dim i As Integer

        strGeneraTabla = New StringBuilder

        ' Obtenemos todos los empleados y sus movimientos
        objArrayConsulta = Business.clsSucursal.clsEmpleado.strBuscarEmpleadoAsistencia(intCompaniaId(), intSucursalId(), 0, 1, strCadenaConexion)

        If IsArray(objArrayConsulta) AndAlso objArrayConsulta.Length > 0 Then

            strGeneraTabla.Append("<SELECT class='campotabla' name='cboEmpleados' onChange='javascript:cboEmpleados_onchange()'>")

            For i = 0 To objArrayConsulta.Length - 1

                ' Sacamos del arreglo la cadena con el nombre del empleado
                strTabla = DirectCast(objArrayConsulta.GetValue(i), String())
                strTablaNombre = DirectCast(strTabla(1), String).Trim & " " & DirectCast(strTabla(2), String).Trim & " " & DirectCast(strTabla(3), String).Trim
                strTablaEmpleado = DirectCast(strTabla(0), String)
                ' Agregamos nuevo option al combo 
                strGeneraTabla.Append("<OPTION value='" & strTablaEmpleado & "'>" & strTablaNombre & "</OPTION>")
            Next
            strGeneraTabla.Append("</SELECT>")
            For i = 0 To objArrayConsulta.Length - 1

                ' Sacamos del arreglo la cadena con el nombre del empleado
                strTabla = DirectCast(objArrayConsulta.GetValue(i), String())
                strTablaEmpleado = DirectCast(strTabla(0), String)
            Next
        End If
        strllenarComboEmpleados = strGeneraTabla.ToString
    End Function

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
    ' Name       : strObservacionesIncapacidad()
    ' Description: Despliega las observaciones de incapacidad
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strObservacionesIncapacidad() As String

        Get
            Dim html As String = ""
            Dim strmObservacionesIncapacidad As String = DirectCast(resultArray.GetValue(20), String)
            strmObservacionesIncapacidad = strmObservacionesIncapacidad.Replace(Environment.NewLine, " ")
            html = "<TEXTAREA id='txaIncapacidadMedica' rows='3' cols='35' name='txaIncapacidadMedica'>" + strmObservacionesIncapacidad + "</TEXTAREA>"
            Return html
        End Get

    End Property

    '====================================================================
    ' Name       : strObservacionesPermiso()
    ' Description: Despliega las observaciones de incapacidad
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strObservacionesPermiso() As String

        Get
            Dim htmlCode As StringBuilder
            htmlCode = New StringBuilder
            Dim strObservaciones As String = DirectCast(resultArray.GetValue(19), String)
            strObservaciones = strObservaciones.Replace(Environment.NewLine, " ")
            'htmlCode.Append("<INPUT name='btnObservacionesPermiso' class='boton' type='button' value='Observaciones' onClick='if(document.getElementById('changeDefault2').style.visibility =='visible')document.getElementById('changeDefault2').style.visibility ='hidden';else document.getElementById('changeDefault2').style.visibility ='visible';">
            'htmlCode.Append("<div id='changeDefault2' style='VISIBILITY: hidden'>
            htmlCode.Append("<TEXTAREA id='txaPermisoEspecial' rows='3' cols='35' name='txaPermisoEspecial'>" + strObservaciones + "</TEXTAREA>")
            'htmlCode.Append("</div>")

            Return htmlCode.ToString
        End Get

    End Property


#Region "Capacitacion y/o Junta Operacional"

    '====================================================================
    ' Name       : strCapacitacionFechaInicio()
    ' Description: Indica la fecha de Inicio de una "Capacitacion" en caso de que estas ya existan
    ' Creador    : Carlos Vazquez
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCapacitacionFechaInicio() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder

            Dim strCapacitacionInicio As String = DirectCast(resultArray.GetValue(22), String)

            If strCapacitacionInicio <> "1/1/1900" Then

                If Convert.ToDateTime(strCapacitacionInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtCapacitacionInicio' name='txtCapacitacionInicio' onChange='cambioCapacitacionFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strCapacitacionInicio)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtCapacitacionInicio' name='txtCapacitacionInicio' onChange='cambioCapacitacionFechaInicio()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strCapacitacionInicio)) + "'>")
                End If

            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtCapacitacionInicio' name='txtCapacitacionInicio' onChange='cambioCapacitacionFechaInicio()' value=''>")
            End If

            Return strHtmlCode.ToString()
        End Get

    End Property

    '====================================================================
    ' Name       : strCapacitacionFechaFin()
    ' Description: Indica la fecha de Fin de un permiso Especial en caso de que estas ya existan
    ' Creador    : Jesus M. Gil 
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCapacitacionFechaFin() As String

        Get
            Dim strHtmlCode As StringBuilder
            strHtmlCode = New StringBuilder

            Dim strCapacitacionInicio As String = DirectCast(resultArray.GetValue(22), String)
            Dim strCapacitacionFin As String = DirectCast(resultArray.GetValue(23), String)

            If strCapacitacionFin <> "1/1/1900" Then

                If Convert.ToDateTime(strCapacitacionInicio) <= Date.Today Then
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtCapacitacionFin' name='txtCapacitacionFin' onChange='cambioCapacitacionFechaFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strCapacitacionFin)) + "' disabled>")
                Else
                    strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtCapacitacionFin' name='txtCapacitacionFin' onChange='cambioCapacitacionFechaFin()' value='" + clsCommons.strFormatearFechaPresentacion(CStr(strCapacitacionFin)) + "'>")
                End If

            Else
                strHtmlCode.Append("<INPUT class='campotabla' type='text' maxLength='10' size='9' id='txtCapacitacionFin' name='txtCapacitacionFin' onChange='cambioCapacitacionFechaFin()' value=''>")
            End If

            Return strHtmlCode.ToString()
        End Get

    End Property

    '====================================================================
    ' Name       : strObtenerObservacionesCapacitacion()
    ' Description: Despliega las observaciones de capacitacion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strObtenerObservacionesCapacitacion() As String

        Get
            Dim htmlCode As StringBuilder
            htmlCode = New StringBuilder
            Dim strObservaciones As String = DirectCast(resultArray.GetValue(24), String)
            strObservaciones = strObservaciones.Replace(Environment.NewLine, " ")

            htmlCode.Append("<TEXTAREA id='txtCapacitacion' rows='3' cols='35' name='txtCapacitacion'>" + strObservaciones + "</TEXTAREA>")


            Return htmlCode.ToString
        End Get

    End Property

    '====================================================================
    ' Name       : strFechaActual
    ' Description: Regresa la fecha actual
    ' Accessor   : Read, write
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFechaActual() As String
        Get
            'If IsNothing(Request.Form("dtmFechaFin")) Then
            Dim dtmFechaActual As Date

            dtmFechaActual = New Date(Date.Today.Year, Date.Today.Month, Date.Today.Day)

            Return dtmFechaActual.ToString("dd/MM/yyyy")
            'Else
            'Return Request.Form("dtmFechaFin")
            'End If
        End Get
    End Property

#End Region


    '====================================================================
    ' Name       : strCadenaConexion
    ' Description: Valor que tomara la variable strmCadenaConexion
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCadenaConexion() As String

        Get

            Return ConfigurationSettings.AppSettings("strCadenaConexionAdministradorPuntoVenta")
        End Get

    End Property

    '====================================================================
    ' Name       : intEmpleadoId
    ' Description: Valor del Numero de Empleado
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Public ReadOnly Property intEmpleadoId() As Integer

        Get

            Return CInt(Request.QueryString("intEmpleadoId"))
        End Get

    End Property

    '====================================================================
    ' Name       : strCmd
    ' Description: Valor del par�metro strCmd
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String

        Get

            Return Request.QueryString("strCmd")
        End Get

    End Property

    '====================================================================
    ' Name       : strEstadoOperativo
    ' Description: Muestra el estado operativo del empleado actualmente
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Property strEstadoOperativo() As String

        Get

            Return Request.QueryString("strEstadoOperativo")
        End Get
        Set(ByVal strValue As String)
            strEstadoOperativo = strValue
        End Set

    End Property

    '====================================================================
    ' Name       : strRecordBrowserHTML
    ' Description: Valor que tomara la variable strmRecordBrowserHTML
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : String
    '====================================================================
    Public Function strRecordBrowserHTML() As String

        ' Declaraci�n e inicializaci�n de las variables locales
        Dim strTargetURL As String = Request.ServerVariables("SCRIPT_NAME") & "?"
        Dim blnConsultaAdministrativa As Boolean = False
        Dim objGrupoUsuario As Array = Nothing
        Dim strGrupoUsuarioRegistro As String() = Nothing
        Dim objDataArray As Array = Nothing

        ' Traemos informacion del rol que tiene el empleado firmado actualmente
        objGrupoUsuario = clstblGrupoUsuario.strBuscar(intGrupoUsuarioId, "", "", "", Date.Now, "", 0, 0, strCadenaConexion)

        If IsArray(objGrupoUsuario) Then

            If objGrupoUsuario.Length > 0 Then

                strGrupoUsuarioRegistro = DirectCast(objGrupoUsuario.GetValue(0), String())

                ' Validamos si el usuario firmado es un Administrador
                blnConsultaAdministrativa = LTrim(RTrim(strGrupoUsuarioRegistro(1))).ToUpper.Equals("ADMINISTRADOR")

            End If

        End If

        objDataArray = Business.clsSucursal.clsEmpleado.strBuscar(intCompaniaId, intSucursalId, intEmpleadoId, blnConsultaAdministrativa, strCadenaConexion)

        If IsArray(objDataArray) Then

            If objDataArray.Length > 0 Then

                ' Generamos el Navegador de Registros
                Return clsCommons.strGenerateJavascriptString(clsRecordBrowser.strGetHTML("SucursalEmpleadosAdministrar", objDataArray, 1, objDataArray.Length, strTargetURL))

            End If

        End If

    End Function
    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        ' Control de Acceso de la p�gina
        If Business.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strCadenaConexion) = False Then
            Call Response.Redirect(strRedirectPage)
        End If

        Try
            resultArray = Business.clsSucursal.clsEmpleado.strObtenerConfiguracionControlAsistencia(Convert.ToDouble(Request.QueryString("intEmpleadoId")), strCadenaConexion)

            Select Case Trim(UCase(strCmd))

                Case "APLICAR"
                    Dim strVacacionId As String = DirectCast(resultArray.GetValue(3), String)
                    Dim strPermisoEspecialId As String = DirectCast(resultArray.GetValue(6), String)
                    Dim strIncapacidadId As String = DirectCast(resultArray.GetValue(11), String)
                    Dim strCapacitacionId As String = DirectCast(resultArray.GetValue(21), String)
                    Dim strBajaTemporal As String = Convert.ToString(Request.Form("chkBajaTemporal"))
                    Dim strFechaDefaultInicial As String = "01/01/1900"
                    Dim strEmpleadoNombre As String = Convert.ToString(Request.Form("hdnEmpleadoNombre"))
                    Dim strObservacionesIncapacidadMedica As String = Convert.ToString(Request.Form("txaIncapacidadMedica"))
                    Dim strObservacionesPermisoEspecial As String = Convert.ToString(Request.Form("txaPermisoEspecial"))
                    Dim strObservacionesCapacitacion As String = Convert.ToString(Request.Form("txtCapacitacion"))

                    Dim diaDescansoOriginalCambio As Boolean = False
                    Dim diaDescansoOriginal As Int16 = Convert.ToInt16(Request.Form("hdnDiaDescansoOriginal"))
                    Dim blnBajaTemporal As Boolean = False
                    If strBajaTemporal = "on" Then
                        blnBajaTemporal = True
                    End If

                    'Vacaciones
                    Dim dtmFechaVacacionesFin As Date
                    'Si la fecha de inicio es mayor o igual que l actual entonces seria se toma de lo que haya en el text
                    ' sino significa que la vacacion ya comenzo y este dato no pudo haberse cambiado dado que esta deshabilitado
                    If Request.Form("txtVacacionesFin") = String.Empty Then
                        dtmFechaVacacionesFin = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial))
                    Else
                        dtmFechaVacacionesFin = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtVacacionesFin")))
                    End If

                    Dim dtmVacacionesInicio As Date = Convert.ToDateTime(DirectCast(resultArray.GetValue(4), String))
                    If Request.Form("txtVacacionesInicio") = String.Empty Then
                        dtmVacacionesInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial))
                    Else
                        If dtmVacacionesInicio > Date.Today Or dtmVacacionesInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial)) Then
                            dtmVacacionesInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtVacacionesInicio")))
                        End If
                    End If

                    'Incapacidad
                    'validando si la fecha de inicio de Incapacidad es inferior a la actual, 
                    'para tomar del resultArray los datos, ya que los text html estan deshabilitados                    
                    Dim dtmFechaIncapacidadInicio As Date
                    Dim dtmFechaIncapacidadFin As Date
                    'Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial)
                    If Convert.ToDateTime(resultArray.GetValue(12)) <= Date.Today And Convert.ToDateTime(resultArray.GetValue(12)) <> Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial)) Then
                        dtmFechaIncapacidadInicio = Convert.ToDateTime(DirectCast(resultArray.GetValue(12), String))
                        dtmFechaIncapacidadFin = Convert.ToDateTime(DirectCast(resultArray.GetValue(13), String))
                    Else
                        If Request.Form("txtIncapacidadMedicaInicio") <> "" And Request.Form("txtIncapacidadMedicaFinal") <> "" Then
                            dtmFechaIncapacidadInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtIncapacidadMedicaInicio")))
                            dtmFechaIncapacidadFin = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtIncapacidadMedicaFinal")))
                        Else
                            dtmFechaIncapacidadInicio = Convert.ToDateTime(DirectCast(resultArray.GetValue(12), String))
                            dtmFechaIncapacidadFin = Convert.ToDateTime(DirectCast(resultArray.GetValue(13), String))
                        End If

                    End If
                    Dim intMotivoIncapacidad As Int32
                    If Convert.ToInt32(Request.Form("hdnMotivo")) = 0 Then
                        intMotivoIncapacidad = 1
                    Else
                        intMotivoIncapacidad = Convert.ToInt32(Request.Form("hdnMotivo"))
                    End If

                    Dim strFolioIncapacidad As String = Convert.ToString(Request.Form("txtFolio"))

                    'Permiso Especial
                    'validando si la fecha de inicio del Permiso es inferior a la actual, 
                    'para tomar del resultArray los datos, ya que los text html estan deshabilitados                    

                    Dim strPermisoConSuledo As String = Convert.ToString(Request.Form("chkPermisoEspecialConSueldo"))
                    Dim blnPermisoConsueldo As Boolean = False
                    If strPermisoConSuledo = "on" Then
                        blnPermisoConsueldo = True
                    End If
                    Dim dtmFechaPermisoInicio As Date = Convert.ToDateTime(DirectCast(resultArray.GetValue(7), String))
                    Dim dtmFechaPermisoFin As Date = Convert.ToDateTime(DirectCast(resultArray.GetValue(8), String))
                    If Request.Form("txtPermisoEspecialInicio") <> "" And Request.Form("txtPermisoEspecialFin") <> "" Then
                        If dtmFechaPermisoInicio > Date.Today Or dtmFechaPermisoInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial)) Then
                            dtmFechaPermisoInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtPermisoEspecialInicio").ToString))
                            dtmFechaPermisoFin = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtPermisoEspecialFin").ToString))
                        End If
                    End If

                    'Capacitacion
                    Dim dtmFechaCapacitacionFin As Date

                    'Si la fecha de inicio es mayor o igual que la actual entonces se toma de lo que haya en el text
                    ' sino significa que la capacitacion ya comenzo y este dato no pudo haberse cambiado dado que esta deshabilitado
                    If Request.Form("txtCapacitacionFin") = String.Empty Then
                        dtmFechaCapacitacionFin = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial))
                    Else
                        dtmFechaCapacitacionFin = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtCapacitacionFin")))
                    End If

                    Dim dtmCapacitacionInicio As Date = Convert.ToDateTime(DirectCast(resultArray.GetValue(22), String))
                    If Request.Form("txtCapacitacionInicio") = String.Empty Then
                        dtmCapacitacionInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial))
                    Else
                        If dtmCapacitacionInicio > Date.Today Or dtmCapacitacionInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(strFechaDefaultInicial)) Then
                            dtmCapacitacionInicio = Convert.ToDateTime(clsCommons.strDMYtoMDY(Request.Form("txtCapacitacionInicio")))
                        End If
                    End If

                    'dia de Descanso
                    Dim intDiaDescanso As Int16 = Convert.ToInt16(Request.Form("hdnDiaDescanso"))

                    Dim resultGuardar As String

                    resultGuardar = _
                    Business.clsSucursal.clsEmpleado.strGuardarConfiguracionControlAsistencia((Convert.ToDouble(Request.QueryString("intEmpleadoId"))), _
                        Me.strUsuarioNombre, _
                        strVacacionId, _
                        strPermisoEspecialId, _
                        strIncapacidadId, _
                        strCapacitacionId, _
                        blnBajaTemporal, _
                        dtmFechaVacacionesFin, _
                        dtmVacacionesInicio, _
                        dtmFechaIncapacidadInicio, _
                        dtmFechaIncapacidadFin, _
                        intMotivoIncapacidad, _
                        strFolioIncapacidad, _
                        strObservacionesIncapacidadMedica, _
                        strObservacionesPermisoEspecial, _
                        blnPermisoConsueldo, _
                        dtmFechaPermisoInicio, _
                        dtmFechaPermisoFin, _
                        intDiaDescanso, _
                        dtmCapacitacionInicio, _
                        dtmFechaCapacitacionFin, _
                        strObservacionesCapacitacion, _
                        strCadenaConexion)

                    'Response.Write(resultValidacion)
                    If diaDescansoOriginal <> intDiaDescanso Then
                        diaDescansoOriginalCambio = True
                    End If


                    If (resultGuardar = "") Then
                        If (diaDescansoOriginalCambio) Then
                            Response.Redirect("SucursalEmpleadosControlAsistenciasAdministracionEmpleadosTurnos.aspx?&intEmpleadoId=" + Request.QueryString("intEmpleadoId") + "&strEmpleadoNombre=" + strEmpleadoNombre)
                        End If
                        Response.Redirect("SucursalEmpleadosControlAsistenciasAdministraciondeEmpleados.aspx")
                    Else
                        strMensaje = resultGuardar.ToString

                    End If

            End Select

        Catch objException As Exception

            ' Variables locales
            Dim strErrorString As StringBuilder : strErrorString = New StringBuilder
            Dim objApplicationEventLog As System.Diagnostics.EventLog : objApplicationEventLog = New System.Diagnostics.EventLog
            Dim strProductName As String : strProductName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName
            Dim strApplicationName As String : strApplicationName = System.Reflection.Assembly.GetExecutingAssembly.Location
            Dim strVersion As String : strVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
            Dim strSource As String : strSource = objException.Source
            Dim strMessage As String : strMessage = objException.Message
            Dim strStackTrace As String : strStackTrace = objException.StackTrace
            Dim intLineNumber As Integer : intLineNumber = Erl()
            Dim intErrorNumber As Integer : intErrorNumber = Err.Number
            Dim intCategoryNumber As Short : intCategoryNumber = 0

            ' Identificador de la clase
            Dim strmThisClassName As String = "com.isocraft.backbone.SucursalEmpleadosControlAsistenciaAdministracionEmpleadosModificaciones.aspx"
            Dim strmThisMemberName As String = "Load"

            ' Creamos el mensaje de error
            Call strErrorString.Append("Product name:" & vbCrLf & vbTab & strProductName & "." & strmThisClassName & "." & strmThisMemberName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Application name:" & vbCrLf & vbTab & strApplicationName & vbCrLf & vbCrLf)
            Call strErrorString.Append("Version:" & vbCrLf & vbTab & strVersion & vbCrLf & vbCrLf)
            Call strErrorString.Append("Source:" & vbCrLf & vbTab & strSource & vbCrLf & vbCrLf)
            Call strErrorString.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(intErrorNumber) & vbCrLf & vbCrLf)
            Call strErrorString.Append("Line number:" & vbCrLf & vbTab & intLineNumber & vbCrLf & vbCrLf)
            Call strErrorString.Append("Message:" & vbCrLf & vbTab & strMessage & vbCrLf & vbCrLf)
            Call strErrorString.Append("StackTrace:" & vbCrLf & strStackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(strProductName) Then

                Call EventLog.CreateEventSource(strProductName, "Application")

            End If

            ' Establecemos la fuente del evento
            objApplicationEventLog.Source = strProductName

            ' Escribimos el evento en el Visor de Eventos
            Call objApplicationEventLog.WriteEntry(strErrorString.ToString(), EventLogEntryType.Error, Err.Number, intCategoryNumber)

            ' Notificamos el error
            Throw

        End Try

    End Sub


End Class
