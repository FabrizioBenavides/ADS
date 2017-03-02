' ============================================================
' Creado      : 24 octubre 2014
' Cosultoria  : Softtek Mty 
' Descripcion : Ws Que regresa los Datos de de Huella Digital
' Creador     : Brenda Isabel Pecina , BPDL
' ===========================================================
Imports System.Web.Services
Imports System.Text
Imports System.Configuration
Imports Benavides.CC.Business
Imports System.Array
Imports System.Collections

<System.Web.Services.WebService(Namespace:="http://localhost/com.isocraft.backbone.ccentral/wsHuellaDigital")> _
Public Class wsHuellaDigital
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function
    ' Estructura que se envia como salida del WebMethod strExisteHuella

    ' Estructura de Salida , es para Regresar el Valor de los Datos en XML
    Public Structure EstructuraSalida

        Dim intEmpleadoId As Integer

        Dim strNombreEmpleado As String

        Dim strHuella As String

        Dim intEstatusId As Integer

        Dim strMensaje As String

    End Structure

    ' Crea una lista de Arreglos con los Nombres de empleado y Huella 
    Public Structure EstructuraHuellaValidador

        Dim intEmpleadoId As ArrayList

        Dim strHuella As ArrayList

    End Structure

    Public Structure strRespuestaRegistro

        Dim strRespuesta As String

    End Structure

    ' Metodo que Valida la Estructura del Empleado, si es que Existe
    <WebMethod()> _
    Public Function strExisteHuella(ByVal intEmpleadoId As Integer) As EstructuraSalida

        ' Declaracion de variables
        Dim salida As EstructuraSalida

        ' Obtenemos los Valores desde la Base de Datos
        Dim arrayResult As ArrayList = Benavides.CC.Business.clsConcentrador.clsSucursal.clsHuellaDactilar.arrayExisteHuella(intEmpleadoId, strCadenaConexion)


        ' Recorremos el array con un contador
        salida.intEmpleadoId = CInt(arrayResult(0))
        salida.strNombreEmpleado = CStr(arrayResult(1))
        salida.strHuella = CStr(arrayResult(2))
        salida.intEstatusId = CInt(arrayResult(3))
        salida.strMensaje = CStr(arrayResult(4))

        ' Regresamos el Valor para el Registro
        strExisteHuella = salida

    End Function

    ' Fruncion que se Encarga de Verificar la Huella 
    ' Recoremos el Arreglo que Envia POS
    <WebMethod()> _
    Public Function strVerificaHuella(ByVal intEmpleadoId As Integer) As EstructuraHuellaValidador

        ' Declaracion de Variables
        Dim salida As EstructuraHuellaValidador
        Dim intEmpleado As ArrayList
        Dim strHuella As ArrayList

        Dim i As Integer
        Dim j As Integer
        Dim lon As Integer

        ' Incializacion de Variables
        i = 0
        j = 1

        ' Obtenemos los Valores Desde la Base de Datos
        Dim arrayResult As ArrayList = Benavides.CC.Business.clsConcentrador.clsSucursal.clsHuellaDactilar.arrayVerificaHuella(intEmpleadoId, _
                                                                                            strCadenaConexion())
        intEmpleado = New ArrayList
        strHuella = New ArrayList

        ' Recorremos el array con un contador
        lon = arrayResult.Count()

        ' Recomeremos el Resultado
        While i < lon

            intEmpleado.Add(arrayResult(i))
            i = i + 2
        End While

        While j < lon
            strHuella.Add(arrayResult(j))
            j = j + 2
        End While

        ' Regresamos el Resultado
        salida.intEmpleadoId = (intEmpleado)
        salida.strHuella = (strHuella)

        ' Return
        strVerificaHuella = salida

    End Function

    ' Metodo que se Encarga de Desabilitar la huella Dactilar
    ' Revisamos en la Base de datos si el usuario aun Esta Activo

    <WebMethod()> _
    Public Function strDeshabilitarHuella(ByVal intEmpleadoId As Integer, _
                                            ByVal strHuellaDigital As String) As String

        ' Declaracion de Varibles
        Dim strResult As String
        Dim intRes As Integer = 0

        ' Obtenemos el Valor desde la base de Datos 
        intRes = Benavides.CC.Business.clsConcentrador.clsSucursal.clsHuellaDactilar.intDeshabilitarHuella(intEmpleadoId, _
                                                        strHuellaDigital, _
                                                        strCadenaConexion)

        ' Resultado de la bse de Datos
        ' para su desactivacion
        strDeshabilitarHuella = CStr(intRes)

    End Function

    '' Registramos los Datos en la Base de Datos
    ' Proceso que se Encarga de Registar en la Base de datos la Huella

    <WebMethod()> _
    Public Function strRegistrarHuella(ByVal intEmpleadoId As Integer, _
                                        ByVal strHuellaDigital As String) As String
        'StkHuellaDactilar  SSCA
        Dim strMensaje As String
        Dim strResult As String

        ' Obtenemos los Valores desde la Base de datos
        strResult = Benavides.CC.Business.clsConcentrador.clsSucursal.clsHuellaDactilar.strRegistrarHuella(intEmpleadoId, _
                                                                                                     strHuellaDigital, _
                                                                                                     strCadenaConexion())
        ' Regresamos el Dato del WS
        strRegistrarHuella = strResult

    End Function

    ' stkVisitaGerentesSucursal CJBG 04/12/2014 - Agregando fecha strFechaRegistro en formato especializado
    ' Funcion que inserta en la Base de datos los dato de los usarios que 
    ' estan realizando las visitas a las Gerencias
    <WebMethod()> _
    Public Function strRegistraVisita(ByVal intEmpleadoId As Long, _
                                        ByVal intCompaniaId As Long, _
                                        ByVal intSucursalId As Long, _
                                        ByVal intCajaId As Long, _
                                        ByVal strFechaRegistro As String) As String

        ' iniciamos la variable
        strRegistraVisita = vbNullString

        ' Formato que nos regresa el INSERT DE SQL
        strRegistraVisita = Benavides.CC.Business.clsConcentrador.clsSucursal.clsHuellaDactilar.strRegistraVisita(intEmpleadoId, _
                                                                                                                    intCompaniaId, _
                                                                                                                    intSucursalId, _
                                                                                                                    intCajaId, _
                                                                                                                    strFechaRegistro, _
                                                                                                                   strCadenaConexion())
        ' regresamos el valor
        Return strRegistraVisita

    End Function

    ' declaracion de la variable para obtener la cadena de conexion a la base de datos 
    Public ReadOnly Property strCadenaConexion() As String

        Get

            ' obtenemos la conexion a la base de datos 
            Return ConfigurationSettings.AppSettings("strCadenaConexionConcentradorCentral")

        End Get

    End Property

End Class
