'====================================================================
' Class         : clstblArticuloPromocionMonederoElectronico
' Title         : Grupo Benavides. Administrador POS y Backoffice. 
' Description   : Mantenimiento de Tablas.
' Copyright     : 
' Company       : Servicios Operacionales Benavides S.A. 
' Author        : Desarrollo de Sistemas POS ; GGP
' Version       : 1.0
' Last Modified : Martes, 16 de Octubre de 2007
'====================================================================
Public NotInheritable Class clstblArticuloPromocionMonederoElectronico

    ' Identificador de la clase
    Private Const CLASS_NAME As String = "Benavides.CC.Data.clstblArticuloPromocionMonederoElectronico"

    ' Constructor en blanco para prevenir la generación de un constructor por defecto
    Private Sub New()
    End Sub

    '====================================================================
    ' Name       : intActualizar
    ' Description: Actualización de registros.
    '                 - Tabla tblArticuloPromocionMonederoElectronico
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intPromocionMonederoElectronicoId As Integer
    '                 - 
    '              ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer
    '                 - 
    '              ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime
    '                 - 
    '              ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================
    Shared Function intActualizar( _
                ByVal intArticuloId As Integer, _
                ByVal intPromocionMonederoElectronicoId As Integer, _
                ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer, _
                ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime, _
                ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const MEMBER_NAME As String = "intActualizar"

        ' Declare the local variables
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim numberOfRowsUpdated As Integer
        Dim returnedData As Array

        Try
            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call sqlStatementToBeExecuted.Append("EXECUTE spActualizartblArticuloPromocionMonederoElectronico ")
            Call sqlStatementToBeExecuted.Append(intArticuloId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intPromocionMonederoElectronicoId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intArticuloPorcentajePromocionMonederoElectronico)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmArticuloPromocionMonederoElectronicoUltimaModificacion.ToString("MM/dd/yyyy"))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strArticuloPromocionMonederoElectronicoModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")

            ' Ejecutamos el comando
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Regresamos la información
            If Not IsNothing(returnedData) AndAlso returnedData.Length > 0 Then

                numberOfRowsUpdated = CInt(DirectCast(returnedData.GetValue(0), SortedList).GetByIndex(0))

            End If

            returnedData = Nothing
            Return numberOfRowsUpdated


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


            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(productName) Then

                Call EventLog.CreateEventSource(productName, "Application")

            End If


            ' Establecemos la fuente del evento
            applicationEventLog.Source = productName

            ' Escribimos el evento en el Visor de Eventos
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Regresamos la información
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intAgregar
    ' Description: Adición de registros.
    '                  - Tabla tblArticuloPromocionMonederoElectronico
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                  - 
    '              ByVal intPromocionMonederoElectronicoId As Integer
    '                  - 
    '              ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer
    '                  - 
    '              ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime
    '                  - 
    '              ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String
    '                  -       
    '              ByVal strConnectionString As String
    '                  - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                  - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intAgregar( _
                ByVal intArticuloId As Integer, _
                ByVal intPromocionMonederoElectronicoId As Integer, _
                ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer, _
                ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime, _
                ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String, _
                ByVal strConnectionString As String) As Integer

        ' Constantes locales
        Const MEMBER_NAME As String = "intAgregar"

        ' Variables locales
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim newRecordId As Integer
        Dim returnedData As Array

        Try
            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call sqlStatementToBeExecuted.Append("EXECUTE spAgregartblArticuloPromocionMonederoElectronico ")
            Call sqlStatementToBeExecuted.Append(intArticuloId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intPromocionMonederoElectronicoId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intArticuloPorcentajePromocionMonederoElectronico)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmArticuloPromocionMonederoElectronicoUltimaModificacion.ToString("MM/dd/yyyy"))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strArticuloPromocionMonederoElectronicoModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")



            ' Ejecutamos el comando                
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Regresamos la información
            If Not IsNothing(returnedData) AndAlso returnedData.Length > 0 Then

                newRecordId = CInt(DirectCast(returnedData.GetValue(0), SortedList).GetByIndex(0))

            End If

            returnedData = Nothing
            Return newRecordId

        Catch myException As Exception

            ' Variables locales
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Creamos el mensaje de error
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(productName) Then

                Call EventLog.CreateEventSource(productName, "Application")

            End If

            ' Establecemos la fuente del evento
            applicationEventLog.Source = productName

            ' Escribimos el evento en el Visor de Eventos
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Inicializamos variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : strBuscar
    ' Description: Búsqueda de registros.
    '                 - Tabla tblArticuloPromocionMonederoElectronico
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intPromocionMonederoElectronicoId As Integer
    '                 - 
    '              ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer
    '                 - 
    '              ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime
    '                 - 
    '              ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String
    '                 -       
    '              ByVal intPosicionInicial As  Integer
    '                 - Inicio de registros
    '              ByVal intElementos As Integer
    '                 - Numero de elementos por bloque  
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscar( _
            ByVal intArticuloId As Integer, _
            ByVal intPromocionMonederoElectronicoId As Integer, _
            ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer, _
            ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime, _
            ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String, _
            ByVal intPosicionInicial As Integer, _
            ByVal intElementos As Integer, _
            ByVal strConnectionString As String) As Array


        ' Constantes locales
        Const MEMBER_NAME As String = "strBuscar"

        ' Variables locales
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim returnedData As Array


        Try
            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call sqlStatementToBeExecuted.Append("EXECUTE spBuscartblArticuloPromocionMonederoElectronico ")
            Call sqlStatementToBeExecuted.Append(intArticuloId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intPromocionMonederoElectronicoId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intArticuloPorcentajePromocionMonederoElectronico)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmArticuloPromocionMonederoElectronicoUltimaModificacion.ToString("MM/dd/yyyy"))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strArticuloPromocionMonederoElectronicoModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intPosicionInicial)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intElementos)

            ' Ejecutamos el comando
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            Return returnedData

        Catch myException As Exception
            ' Variables locales
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Creamos el mensaje de error
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(productName) Then

                Call EventLog.CreateEventSource(productName, "Application")

            End If

            ' Establecemos la fuente del evento
            applicationEventLog.Source = productName

            ' Escribimos el evento en el Visor de Eventos
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Inicializamos variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function

    '====================================================================
    ' Name       : intEliminar
    ' Description: Eliminación de registros.
    '                 - Tabla tblArticuloPromocionMonederoElectronico
    ' Parameters : 
    '              ByVal intArticuloId As Integer
    '                 - 
    '              ByVal intPromocionMonederoElectronicoId As Integer
    '                 - 
    '              ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer
    '                 - 
    '              ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime
    '                 - 
    '              ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String
    '                 -       
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Integer
    '                 - Número de registros afectados por el comando
    '====================================================================        
    Shared Function intEliminar( _
            ByVal intArticuloId As Integer, _
            ByVal intPromocionMonederoElectronicoId As Integer, _
            ByVal intArticuloPorcentajePromocionMonederoElectronico As Integer, _
            ByVal dtmArticuloPromocionMonederoElectronicoUltimaModificacion As DateTime, _
            ByVal strArticuloPromocionMonederoElectronicoModificadoPor As String, _
            ByVal strConnectionString As String) As Integer



        ' Constantes locales
        Const MEMBER_NAME As String = "intEliminar"

        ' Variables locales
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim numberOfRowsDeleted As Integer
        Dim returnedData As Array

        Try
            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call sqlStatementToBeExecuted.Append("EXECUTE spEliminartblArticuloPromocionMonederoElectronico ")
            Call sqlStatementToBeExecuted.Append(intArticuloId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intPromocionMonederoElectronicoId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append(intArticuloPorcentajePromocionMonederoElectronico)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmArticuloPromocionMonederoElectronicoUltimaModificacion.ToString("MM/dd/yyyy"))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(strArticuloPromocionMonederoElectronicoModificadoPor)
            Call sqlStatementToBeExecuted.Append("'")


            ' Ejecutamos el comando
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Regresamos la información
            If Not IsNothing(returnedData) AndAlso returnedData.Length > 0 Then

                numberOfRowsDeleted = CInt(DirectCast(returnedData.GetValue(0), SortedList).GetByIndex(0))

            End If

            returnedData = Nothing
            Return numberOfRowsDeleted

        Catch myException As Exception

            ' Variables locales
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Creamos el mensaje de error
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(productName) Then

                Call EventLog.CreateEventSource(productName, "Application")

            End If

            ' Establecemos la fuente del evento
            applicationEventLog.Source = productName

            ' Escribimos el evento en el Visor de Eventos
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Inicializamos variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function
    '====================================================================
    ' Name       : strBuscarCambios
    ' Description: Búsqueda de registros a ser enviados a sucursal
    ' Tabla      : tblArticuloPromocionMonederoElectronico
    ' Parameters : 
    '              ByVal dtmUltimaModificacionInicial As DateTime
    '                 - Fecha incio de la modificacion
    '              ByVal dtmUltimaModificacionFinal As DateTime
    '                 -  Fecha Fin de modificacion     
    '              ByVal strConnectionString As String
    '                 - Cadena de conexión hacia el RDBMS
    ' Throws     : Exception
    ' Output     : Array
    '                 - Arreglo bidimensional con los registros leídos
    '                   Array = { (c1,c2..cn), (c1,c2..cn) ... (c1,c2..cn) }
    '                   c = Campo
    '====================================================================
    Shared Function strBuscarCambios( _
            ByVal intTiendaId As Integer, _
            ByVal dtmUltimaModificacionInicial As DateTime, _
            ByVal dtmUltimaModificacionFinal As DateTime, _
            ByVal strConnectionString As String) As Array


        ' Constantes locales
        Const MEMBER_NAME As String = "strBuscarCambios"

        ' Variables locales
        Dim sqlStatementToBeExecuted As System.Text.StringBuilder
        Dim returnedData As Array


        Try
            ' Inicializamos las varialbes locales
            sqlStatementToBeExecuted = New System.Text.StringBuilder

            ' Creamos es estatuto de SQL
            Call sqlStatementToBeExecuted.Append("EXECUTE spBuscarCambiostblArticuloPromocionMonederoElectronico ")
            Call sqlStatementToBeExecuted.Append(intTiendaId)
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmUltimaModificacionInicial.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(",")
            Call sqlStatementToBeExecuted.Append("'")
            Call sqlStatementToBeExecuted.Append(dtmUltimaModificacionFinal.ToString("MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture))
            Call sqlStatementToBeExecuted.Append("'")

            ' Ejecutamos el comando
            returnedData = Benavides.Data.SQL.MSSQL.clsSQLOperation3.aobjExecuteQuery(sqlStatementToBeExecuted.ToString(), strConnectionString)
            sqlStatementToBeExecuted = Nothing

            ' Return the results
            Return returnedData

        Catch myException As Exception
            ' Variables locales
            Dim errorMessage As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim applicationEventLog As System.Diagnostics.EventLog = New System.Diagnostics.EventLog
            Dim productName As String = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).ProductName

            ' Creamos el mensaje de error
            Call errorMessage.Append("Product name:" & vbCrLf & vbTab & productName & "." & CLASS_NAME & "." & MEMBER_NAME & vbCrLf & vbCrLf)
            Call errorMessage.Append("Application name:" & vbCrLf & vbTab & System.Reflection.Assembly.GetExecutingAssembly.Location & vbCrLf & vbCrLf)
            Call errorMessage.Append("Version:" & vbCrLf & vbTab & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart & vbCrLf & vbCrLf)
            Call errorMessage.Append("Source:" & vbCrLf & vbTab & myException.Source & vbCrLf & vbCrLf)
            Call errorMessage.Append("Error number:" & vbCrLf & vbTab & "0x" & Hex(Err.Number) & vbCrLf & vbCrLf)
            Call errorMessage.Append("Line number:" & vbCrLf & vbTab & Erl() & vbCrLf & vbCrLf)
            Call errorMessage.Append("Message:" & vbCrLf & vbTab & myException.Message & vbCrLf & vbCrLf)
            Call errorMessage.Append("SQLStatement:" & vbCrLf & vbTab & sqlStatementToBeExecuted.ToString() & vbCrLf & vbCrLf)
            Call errorMessage.Append("StackTrace:" & vbCrLf & myException.StackTrace & vbCrLf & vbCrLf)

            ' Creamos un evento para registrar el mensaje de error
            If Not EventLog.SourceExists(productName) Then

                Call EventLog.CreateEventSource(productName, "Application")

            End If

            ' Establecemos la fuente del evento
            applicationEventLog.Source = productName

            ' Escribimos el evento en el Visor de Eventos
            Call applicationEventLog.WriteEntry(errorMessage.ToString(), EventLogEntryType.Error, Err.Number, 0)

            ' Inicializamos variables
            sqlStatementToBeExecuted = Nothing
            returnedData = Nothing

            ' Raise the error
            Throw

        End Try

    End Function


End Class