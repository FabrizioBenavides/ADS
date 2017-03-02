Imports Isocraft.Web.Http
Imports Isocraft.Web.Convert

'====================================================================
' Class         : clsSistemaBinesAdministrarArticuloRestringido.aspx
' Title         : clsSistemaBinesAdministrarArticuloRestringido
' Description   : creacion de clases
' Copyright     : (c) Softtek 2014. All rights reserved
' Company       : Softtek
' Author        : Anthony Julian Amador Loera(AJAL)
' Last Modified : Friday, November 07, 2014
'====================================================================
Public Class clsSistemaBinesAdministrarArticuloRestringido
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtArchivo As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        ' Enviamos al usuario actual a la página de acceso, si no tiene privilegios de acceder a esta página
        If Benavides.CC.Business.clsConcentrador.clsControlAcceso.blnPermitirAccesoObjeto(intGrupoUsuarioId, strThisPageName, strConnectionString) = False Then

            Call Response.Redirect("../Default.aspx")

        End If
    End Sub

#End Region

#Region " Class Private Attributes"

    Private strmJavascriptWindowOnLoadCommands As String

#End Region
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
    ' Name       : strFormAction
    ' Description: HTML form's action property value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strFormAction() As String
        Get
            Return strThisPageName
        End Get
    End Property

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

    '====================================================================
    ' Name       : strThisPageName
    ' Description: Name of this page
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strThisPageName() As String
        Get
            Return Server.UrlEncode(GetPageName())
        End Get
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
    ' Name       : strCmd
    ' Description: Parameter value
    ' Accessor   : Read
    ' Output     : String
    '====================================================================
    Public ReadOnly Property strCmd() As String
        Get
            Return GetPageParameter("strCmd", "")
        End Get
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        'Declaramos contante local.
        Const intNumeroColumnasArchivo As Int32 = 1

        'Execute the selected command.
        Select Case strCmd

            Case "Agregar"
                'Verificamos si el archivo ha sido enviado.
                If IsNothing(txtArchivo.PostedFile) = False Then

                    Dim intCounter As Integer
                    Dim dtmInicio As DateTime = Now()

                    'Obtenemos un arreglo con los rengloes del archivo
                    Dim astrRows As Array = CreateArrayFromCSVHttpPostedFile(txtArchivo.PostedFile)

                    'Por cada renglon existente
                    If IsNothing(astrRows) = False AndAlso astrRows.Length > 0 Then

                        For Each astrColumns As Array In astrRows

                            'Si el renglon tiene el numero de columnas adecuadas.
                            If astrColumns.Length = intNumeroColumnasArchivo Then

                                'Obtenemos los valores que vienen en el archivo.
                                Dim intArticuloId As Integer = CInt(ConvertObject(astrColumns.GetValue(0), TypeCode.Int32))

                                'Agregamos los nuevos registros, si los valores de las columnas son validos.
                                If intArticuloId > 0 Then

                                    'Buscamos el registro.
                                    Dim aobjDataToSearch As Array = Benavides.CC.Data.clstblArticuloRestringidoPagoVales.strBuscar(intArticuloId, strConnectionString)

                                    'Si el registro existe.
                                    If IsArray(aobjDataToSearch) = True AndAlso aobjDataToSearch.Length > 0 Then

                                        'Actualizamos el registro
                                        intCounter += Benavides.CC.Data.clstblArticuloRestringidoPagoVales.intActualizar(intArticuloId, Now(), strUsuarioNombre, strConnectionString)

                                    Else

                                        'Agregamos el nuevo registro.
                                        intCounter += Benavides.CC.Data.clstblArticuloRestringidoPagoVales.intAgregar(intArticuloId, Now(), strUsuarioNombre, strConnectionString)

                                    End If

                                End If

                            End If
                        Next

                        'Notificamos los registros actualizados
                        Dim dtmFinal As DateTime = Now()
                        strJavascriptWindowOnLoadCommands &= "alert(""Total de líneas en el archivo: " & astrRows.Length & "\n\r\n\rTotal de registros importados: " & intCounter & "\n\r\n\rTotal de líneas sin importar: " & CStr(astrRows.Length - intCounter) & "\n\r\n\rInicio: " & dtmInicio & "\n\r\n\rFinal: " & dtmFinal & "\n\r\n\rTiempo estimado: " & DateDiff(DateInterval.Minute, dtmInicio, dtmFinal) & " minuto(s)"");" & vbCrLf

                    End If
                End If
        End Select
    End Sub

End Class
