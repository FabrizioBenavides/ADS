
'====================================================================
' Class         : clstblFacturaElectronicaGlobalDatosFacturacion
' Title         : Benavides Enterprise Retail System
' Description   : Data maintenance
' Copyright     : (c) Isocraft 2007 - 2012. All rights reserved
' Company       : Isocraft. (http://www.isocraft.com/)
' Author        : Joaquin Hdz. G. (joaquin@isocraft.com)
' Last Modified : Thursday, September 06, 2007
'====================================================================
Public NotInheritable Class clstblFacturaElectronicaGlobalDatosFacturacion

    ' Class identifier
    Private Const CLASS_NAME As String = "Benavides.CC.Data.clstblFacturaElectronicaGlobalDatosFacturacion"

    ' Class constructor
    Private Sub New()

        ' Empty constructor to avoid the creation of the default constructor

    End Sub

    '====================================================================
    ' Name          : strBuscar
    ' Description   : Returns an array of SortedList objects with the records found
    ' Table name    : tblFacturaElectronicaGlobalDatosFacturacion
    ' Parameters    : 
    '              ByVal intFacturaElectronicaGlobalDatosFacturacionId AS Int32
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionRutaXml As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionCalle As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionNoExterior As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionNoInterior As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionColonia As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionCiudad As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionEstado As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionPais As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionCodigoPostal As Int32
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRFC As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRazonSocial As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCalle As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoExterior As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoInterior As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalColonia As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCiudad As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalEstado As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalPais As String
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCodigoPostal As Int32
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalTelefono As String
    '                  - 
    '              ByVal dtmFacturaElectronicaGlobalDatosFacturacionUltimaModificacion As DateTime
    '                  - 
    '              ByVal strFacturaElectronicaGlobalDatosFacturacionModificadoPor As String
    '                  - 
    '              ByVal intInitialPosition As  Double
    '                 - Initial position
    '              ByVal intElementsToRetrieve As Double
    '                 - Number of elements per page
    '              ByVal strConnectionString As String
    '                  - Database connection string
    ' Throws        : Exception
    ' Output        : Array
    '====================================================================
    Public Shared Function strBuscar(ByVal intFacturaElectronicaGlobalDatosFacturacionId As Int32, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionRutaXml As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionCalle As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionNoExterior As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionNoInterior As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionColonia As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionCiudad As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionEstado As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionPais As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionExpedicionCodigoPostal As Int32, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRFC As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRazonSocial As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCalle As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoExterior As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoInterior As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalColonia As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCiudad As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalEstado As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalPais As String, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCodigoPostal As Int32, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionClienteFiscalTelefono As String, _
                                     ByVal dtmFacturaElectronicaGlobalDatosFacturacionUltimaModificacion As DateTime, _
                                     ByVal strFacturaElectronicaGlobalDatosFacturacionModificadoPor As String, _
                                     ByVal intInitialPosition As Double, _
                                     ByVal intElementsToRetrieve As Double, _
                                     ByVal strConnectionString As String) As Array

        ' Member identifier
        Const MEMBER_NAME As String = "strBuscar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim returnedData As Array

        Try

            ' Create the SQL statement
            sqlStatementToBeExecuted = New System.Text.StringBuilder
            Call sqlStatementToBeExecuted.Append("EXECUTE spBuscartblFacturaElectronicaGlobalDatosFacturacion ")
            Call sqlStatementToBeExecuted.Append(intFacturaElectronicaGlobalDatosFacturacionId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionRutaXml)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionCalle)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionNoExterior)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionNoInterior)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionColonia)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionCiudad)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionEstado)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionPais)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionExpedicionCodigoPostal)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRFC)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalRazonSocial)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCalle)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoExterior)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalNoInterior)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalColonia)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCiudad)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalEstado)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalPais)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalCodigoPostal)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionClienteFiscalTelefono)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmFacturaElectronicaGlobalDatosFacturacionUltimaModificacion.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strFacturaElectronicaGlobalDatosFacturacionModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intInitialPosition)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intElementsToRetrieve)

            ' Execute the SQL statement
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            Return returnedData

        Catch myException As Exception

            ' Declare the error variables
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Create the error message
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Create the event source
            If Not EventLog.SourceExists(productName) Then

                Call EventLog.CreateEventSource(productName, "Application")

            End If

            ' Set the event source
            applicationEventLog.Source = productName

            ' Write the event. It can be read in the Event Viewer.
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Clear the variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

End Class
