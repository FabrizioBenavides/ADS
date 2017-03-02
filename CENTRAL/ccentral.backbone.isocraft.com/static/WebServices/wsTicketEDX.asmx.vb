Imports System.Web.Services
Imports System.Xml
Imports System.Xml.XPath
Imports System.IO

<System.Web.Services.WebService(Namespace:="http://tempuri.org/com.isocraft.backbone.ccentral/wsTicketEDX")> _
Public Class wsTicketEDX
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


    <WebMethod()> _
    Public Function strBuscarEstado(ByVal strRFC As String, ByVal strReferencia As String) As String

        Dim strRespuesta As String
        Dim strFacturado As String = ""

        Dim objXPathDocument As XPathDocument = Nothing
        Dim objXPathNavigator As XPathNavigator = Nothing
        Dim objIterator As XPathNodeIterator = Nothing
        Dim objXPathNodeIterator As XPathNodeIterator = Nothing

        strRespuesta = Benavides.CC.Business.clsConcentrador.clsTicketEDX.strBuscarEstado(strRFC, strReferencia)

        If strRespuesta = "conexionError" Then
            strFacturado = "N"
        Else
            strFacturado = "N"

            objXPathDocument = New XPathDocument(New XmlTextReader(New StringReader(strRespuesta)))
            objXPathNavigator = objXPathDocument.CreateNavigator()

            ' Obtenemos si esta facturado
            ' El servicio puede regresar
            ' F Facturado
            ' B Bloqueado
            ' N No facturado

            objIterator = objXPathNavigator.Select("/Ticket/Header/Facturado")

            While objIterator.MoveNext()
                strFacturado = objIterator.Current.Value
                Exit While
            End While

            objIterator = Nothing

            ' Si marca error por no encontrarlo regresamos que no esta factrado 
            objIterator = objXPathNavigator.Select("/Ticket/Error")

            While objIterator.MoveNext()
                strFacturado = "N"
                Exit While
            End While

            objIterator = Nothing

            ' Solo en el caso que la respuesta sea F se regresa tal cual
            ' Los demas estados son N para la validacion de ADS

            If strFacturado <> "F" Then
                strFacturado = "N"
            End If

        End If

        Return strFacturado

    End Function

End Class
