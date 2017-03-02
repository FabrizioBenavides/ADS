Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

Public Class SucursalAltaDeFoliosDeFondoFijo
    Inherits System.Web.UI.Page

#Region "Private variables"

    Private strmCommand As String = String.Empty
    Private strmJavascriptWindowOnLoadCommands As String = String.Empty

#End Region

#Region " Web Form Designer Generated Code "

    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página 
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If

        strmCommand = GetPageParameter("strCmd", "")

    End Sub

#End Region

    '====================================================================
    ' Name       : intGrupoUsuarioId
    ' Description: Identificador del Grupo de Usuario
    ' Accessor   : Read
    ' Throws     : Ninguna
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property intGrupoUsuarioId() As Integer

        Get

            Return CInt(Benavides.POSAdmin.Commons.clsCommons.strReadCookie("intGrupoUsuarioId", "0", Request, Server))

        End Get

    End Property

    '====================================================================
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strFormAction() As String

        Get

            Return strThisPageName

        End Get

    End Property

    '====================================================================
    ' Name       : strHTMLFechaHora
    ' Description: Genera la fecha y hora de la página
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : Integer
    '====================================================================
    Protected ReadOnly Property strHTMLFechaHora() As String

        Get

            Return Benavides.POSAdmin.Commons.clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")

        End Get

    End Property

    '====================================================================
    ' Name       : strJavascriptWindowOnLoadCommands 
    ' Description: OnLoad Javascript event
    ' Accessor   : Read, Write
    ' Output     : String
    '====================================================================
    Protected Property strJavascriptWindowOnLoadCommands() As String

        Get

            Return strmJavascriptWindowOnLoadCommands

        End Get

        Set(ByVal strValue As String)

            strmJavascriptWindowOnLoadCommands = strValue

        End Set

    End Property

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strThisPageName() As String

        Get

            Return Server.UrlEncode(GetPageName())

        End Get

    End Property

    '====================================================================
    ' Name       : strUsuarioNombre
    ' Description: Nombre del usuario actual
    ' Accessor   : Read
    ' Throws     : None
    ' Output     : String
    '====================================================================
    Protected ReadOnly Property strUsuarioNombre() As String

        Get

            Return Benavides.POSAdmin.Commons.clsCommons.strReadCookie("strUsuarioNombre", "", Request, Server)

        End Get

    End Property

    ''' <summary>
    '''     Agrega nuevos registros a la base de datos.
    '''     Si los registros ya existen y han sido dados de alta el día de hoy entonces los actualiza.
    ''' </summary>
    Private Sub Agregar()

        ' Verificamos si el archivo ha sido enviado
        If Not IsNothing(txtArchivo.PostedFile) Then

            Dim intCounter As Integer = 0
            Dim dtmInicio As DateTime = Now()

            ' Obtenemos un arreglo con los renglones del archivo
            Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

            ' Por cada renglón existente
            If Not IsNothing(astrRows) AndAlso astrRows.Length > 0 Then

                ' Declaramos las constantes locales
                Const intNumeroColumnasArchivo As Int32 = 6

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' CAMPOS QUE DEBE TENER EL ARCHIVO A CARGAR
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' 1) intCompaniaId
                ' 2) intSucursalId
                ' 3) intMes
                ' 4) intAnio
                ' 5) fltFondoFijoPresupuestadoImporteAsignado
                ' 6) fltFondoFijoPresupuestadoImporteDiarioMaximo
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ' Por cada línea (registro) del archivo
                For Each astrColumns As Array In astrRows

                    ' Si el renglón tiene el número de campos (columnas) adecuados
                    If astrColumns.Length = intNumeroColumnasArchivo Then

                        ' Obtenemos los campos que vienen en el archivo
                        Dim intCompaniaId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))
                        Dim intSucursalId As Integer = CInt(ConvertObject(astrColumns.GetValue(1), TypeCode.Int32))
                        Dim intMes As Integer = CInt(ConvertObject(astrColumns.GetValue(2), TypeCode.Int32))
                        Dim intAnio As Integer = CInt(ConvertObject(astrColumns.GetValue(3), TypeCode.Int32))
                        Dim fltFondoFijoPresupuestadoImporteAsignado As Double = CDbl(ConvertObject(astrColumns.GetValue(4), TypeCode.Double))
                        Dim fltFondoFijoPresupuestadoImporteDiarioMaximo As Double = CDbl(ConvertObject(astrColumns.GetValue(5), TypeCode.Double))

                        ' Si los campos clave contienen valores válidos
                        If intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso intMes >= 1 AndAlso intMes <= 12 AndAlso intAnio >= 2000 AndAlso fltFondoFijoPresupuestadoImporteAsignado > 0 Then

                            ' Creamos la fecha de asignación
                            Dim dtmFondoFijoPresupuestadoAsignacion As DateTime = New DateTime(intAnio, intMes, 1)

                            ' Buscamos el registro
                            Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblFondoFijoPresupuestado.strBuscar(0, intCompaniaId, intSucursalId, 0, 0, 0, 0, dtmFondoFijoPresupuestadoAsignacion, #1/1/2000#, #1/1/2000#, "", 0, 0, strConnectionString)

                            ' Si el registro ya existe  
                            If IsArray(aobjDataToSearch) AndAlso aobjDataToSearch.Length > 0 Then

                                Dim dtmFondoFijoPresupuestadoCreacion As DateTime = CDate(DirectCast(aobjDataToSearch.GetValue(0), System.Collections.SortedList).Item("dtmFondoFijoPresupuestadoCreacion"))
                                Dim intFondoFijoPresupuestadoId As Integer = CInt(DirectCast(aobjDataToSearch.GetValue(0), System.Collections.SortedList).Item("intFondoFijoPresupuestadoId"))
                                Dim dtmToday As Date = Now()

                                ' Actualizamos el registro solamente si ha sido creado el día de hoy
                                If dtmFondoFijoPresupuestadoCreacion.ToShortDateString().Equals(dtmToday.ToShortDateString()) Then

                                    Call Benavides.CC.Data.clstblFondoFijoPresupuestado.intActualizar(intFondoFijoPresupuestadoId, intCompaniaId, intSucursalId, fltFondoFijoPresupuestadoImporteAsignado, 0, fltFondoFijoPresupuestadoImporteDiarioMaximo, 1, dtmFondoFijoPresupuestadoAsignacion, dtmFondoFijoPresupuestadoCreacion, #1/1/2000#, strUsuarioNombre, strConnectionString)
                                    intCounter += 1

                                End If

                            Else

                                ' Si el registro no existe, agregamos el nuevo registro
                                Call Benavides.CC.Data.clstblFondoFijoPresupuestado.intAgregar(0, intCompaniaId, intSucursalId, fltFondoFijoPresupuestadoImporteAsignado, 0, fltFondoFijoPresupuestadoImporteDiarioMaximo, 1, dtmFondoFijoPresupuestadoAsignacion, #1/1/2000#, #1/1/2000#, strUsuarioNombre, strConnectionString)
                                intCounter += 1

                            End If

                        End If

                    End If

                Next

                ' Notificamos los registros actualizados
                Dim dtmFinal As DateTime = Now()
                strmJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf

            End If

        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) _
            Handles MyBase.Load

        Select Case strmCommand

            Case "Agregar"

                Call Agregar()

            Case "Reemplazar"

                Call Reemplazar()

        End Select

    End Sub

    ''' <summary>
    '''     Elimina e inserta registros en la base de datos, siempre y cuando estos hayan sido dados de alta el día de hoy.
    ''' </summary>
    Private Sub Reemplazar()

        ' Verificamos si el archivo ha sido enviado
        If Not IsNothing(txtArchivo.PostedFile) Then

            Dim intCounter As Integer = 0
            Dim intDeletedRecords As Integer = 0
            Dim dtmInicio As DateTime = Now()

            ' Obtenemos un arreglo con los renglones del archivo
            Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

            ' Por cada renglón existente
            If Not IsNothing(astrRows) AndAlso astrRows.Length > 0 Then

                ' Declaramos las constantes locales
                Const intNumeroColumnasArchivo As Int32 = 6

                Dim objColeccionAsignacionesProcesadas As System.Collections.Hashtable = New System.Collections.Hashtable

                '''''''''''''''''''''''''''''''''''''''''''''''
                ' CAMPOS QUE DEBE TENER EL ARCHIVO A CARGAR
                '''''''''''''''''''''''''''''''''''''''''''''''
                ' 1) intCompaniaId
                ' 2) intSucursalId
                ' 3) intMes
                ' 4) intAnio
                ' 5) fltFondoFijoPresupuestadoImporteAsignado
                '''''''''''''''''''''''''''''''''''''''''''''''

                ' Por cada línea (registro) del archivo
                For Each astrColumns As Array In astrRows

                    ' Si el renglón tiene el número de campos (columnas) adecuados
                    If astrColumns.Length = intNumeroColumnasArchivo Then

                        ' Obtenemos los campos que vienen en el archivo
                        Dim intCompaniaId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))
                        Dim intSucursalId As Integer = CInt(ConvertObject(astrColumns.GetValue(1), TypeCode.Int32))
                        Dim intMes As Integer = CInt(ConvertObject(astrColumns.GetValue(2), TypeCode.Int32))
                        Dim intAnio As Integer = CInt(ConvertObject(astrColumns.GetValue(3), TypeCode.Int32))
                        Dim fltFondoFijoPresupuestadoImporteAsignado As Double = CDbl(ConvertObject(astrColumns.GetValue(4), TypeCode.Double))
                        Dim fltFondoFijoPresupuestadoImporteDiarioMaximo As Double = CDbl(ConvertObject(astrColumns.GetValue(5), TypeCode.Double))

                        ' Si los campos clave contienen valores válidos
                        If intCompaniaId > 0 AndAlso intSucursalId > 0 AndAlso intMes >= 1 AndAlso intMes <= 12 AndAlso intAnio >= 2000 AndAlso fltFondoFijoPresupuestadoImporteAsignado > 0 Then

                            Dim dtmFondoFijoPresupuestadoAsignacion As DateTime = New DateTime(intAnio, intMes, 1)

                            ' Si la asignación aún no ha sido procesada
                            If Not objColeccionAsignacionesProcesadas.Contains(dtmFondoFijoPresupuestadoAsignacion.ToShortDateString()) Then

                                ' Eliminamos los registros previos
                                intDeletedRecords += Benavides.CC.Data.clstblFondoFijoPresupuestado.intEliminar(0, intCompaniaId, intSucursalId, 0, 0, 0, 0, dtmFondoFijoPresupuestadoAsignacion, #1/1/2000#, #1/1/2000#, strUsuarioNombre, strConnectionString)

                                ' Registramos la asignación como procesada
                                objColeccionAsignacionesProcesadas.Add(dtmFondoFijoPresupuestadoAsignacion.ToShortDateString(), dtmFondoFijoPresupuestadoAsignacion.ToShortDateString())

                            End If

                            ' Buscamos el registro
                            Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblFondoFijoPresupuestado.strBuscar(0, intCompaniaId, intSucursalId, 0, 0, 0, 0, dtmFondoFijoPresupuestadoAsignacion, #1/1/2000#, #1/1/2000#, "", 0, 0, strConnectionString)

                            ' Si el registro ya existe  
                            If IsArray(aobjDataToSearch) AndAlso aobjDataToSearch.Length > 0 Then

                                Dim dtmFondoFijoPresupuestadoCreacion As DateTime = CDate(DirectCast(aobjDataToSearch.GetValue(0), System.Collections.SortedList).Item("dtmFondoFijoPresupuestadoCreacion"))
                                Dim intFondoFijoPresupuestadoId As Integer = CInt(DirectCast(aobjDataToSearch.GetValue(0), System.Collections.SortedList).Item("intFondoFijoPresupuestadoId"))
                                Dim dtmToday As Date = Now()

                                ' Actualizamos el registro solamente si ha sido creado el día de hoy
                                If dtmFondoFijoPresupuestadoCreacion.ToShortDateString().Equals(dtmToday.ToShortDateString()) Then

                                    Call Benavides.CC.Data.clstblFondoFijoPresupuestado.intActualizar(intFondoFijoPresupuestadoId, intCompaniaId, intSucursalId, fltFondoFijoPresupuestadoImporteAsignado, 0, fltFondoFijoPresupuestadoImporteDiarioMaximo, 1, dtmFondoFijoPresupuestadoAsignacion, dtmFondoFijoPresupuestadoCreacion, #1/1/2000#, strUsuarioNombre, strConnectionString)
                                    intCounter += 1

                                End If

                            Else

                                ' Si el registro no existe, agregamos el nuevo registro
                                Call Benavides.CC.Data.clstblFondoFijoPresupuestado.intAgregar(0, intCompaniaId, intSucursalId, fltFondoFijoPresupuestadoImporteAsignado, 0, fltFondoFijoPresupuestadoImporteDiarioMaximo, 1, dtmFondoFijoPresupuestadoAsignacion, #1/1/2000#, #1/1/2000#, strUsuarioNombre, strConnectionString)
                                intCounter += 1

                            End If

                        End If

                    End If

                Next

                ' Notificamos los registros actualizados
                Dim dtmFinal As DateTime = Now()
                strmJavascriptWindowOnLoadCommands &= "  alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf

            End If

        End If

    End Sub

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

End Class
