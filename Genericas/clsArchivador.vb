Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Imports System.IO
Imports System.Xml

Public Class Archivador
    Private msg As Mensaje
    Private paramCnx As ParametrosConexion
    Private env As EnviadorCorreo

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Sub New()
        msg = New Mensaje
    End Sub

    Public Sub New(ByVal pParametrosCnx As ParametrosConexion, ByVal pCorreo As PropiedadesCorreo)
        msg = New Mensaje

        paramCnx = pParametrosCnx
        env = New EnviadorCorreo(pCorreo)
    End Sub

    Public Sub New(ByVal pParametrosCnx As ParametrosConexion)
        msg = New Mensaje
        paramCnx = pParametrosCnx
    End Sub

    Public Function escribirRepresentacionImpresa(ByVal pRutaFormato As String, ByVal pRutaDestino As String, _
                                   ByVal pParametrosImpresion As List(Of ParametroImpresion), _
                                   ByVal pFormato As String) As Mensaje
        Dim docSendReport As ReportDocument = New ReportDocument

        Dim crReportObjects As CrystalDecisions.CrystalReports.Engine.ReportObjects = Nothing
        Dim crSubreportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject = Nothing
        Dim crSubreportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = Nothing
        Dim crDatabase As CrystalDecisions.CrystalReports.Engine.Database = Nothing
        Dim crTables As CrystalDecisions.CrystalReports.Engine.Tables = Nothing



        Dim exportOpts As ExportOptions = New ExportOptions()
        Dim pdfFormatOpts As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
        Dim xlsFormatOpts As ExcelFormatOptions = New ExcelFormatOptions()
        Dim diskOpts As DiskFileDestinationOptions = New DiskFileDestinationOptions()
        Dim cripto As Criptografo = New Criptografo

        Dim connectionInfo As ConnectionInfo = New ConnectionInfo()

        Dim itmCounter As Integer = 0

        Try
            msg.reset()

            docSendReport.Load(pRutaFormato, OpenReportMethod.OpenReportByTempCopy)

            connectionInfo.ServerName = paramCnx.ServidorBd
            connectionInfo.DatabaseName = paramCnx.BaseDeDatos
            connectionInfo.UserID = cripto.Desencriptar(paramCnx.UsuarioBd, paramCnx.BaseDeDatos)
            connectionInfo.Password = cripto.Desencriptar(paramCnx.ContraseniaBd, paramCnx.BaseDeDatos)

            Dim tables As Tables = docSendReport.Database.Tables

            Dim tableLogonInfo As TableLogOnInfo = New TableLogOnInfo()
            tableLogonInfo.ConnectionInfo = connectionInfo

            For Each table In tables
                table.ApplyLogOnInfo(tableLogonInfo)
            Next

            'set the crSections object to the current report's sections
            Dim crSections As CrystalDecisions.CrystalReports.Engine.Sections = docSendReport.ReportDefinition.Sections

            'loop through all the sections to find all the report objects
            For Each crSection As CrystalDecisions.CrystalReports.Engine.Section In crSections

                crReportObjects = crSection.ReportObjects
                'loop through all the report objects to find all the subreports
                For Each crReportObject As CrystalDecisions.CrystalReports.Engine.ReportObject In crReportObjects
                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                        'you will need to typecast the reportobject to a subreport 
                        'object once you find it
                        crSubreportObject = crReportObject

                        'open the subreport object
                        crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                        'set the database and tables objects to work with the subreport
                        crDatabase = crSubreportDocument.Database
                        crTables = crDatabase.Tables

                        'loop through all the tables in the subreport and 
                        'set up the connection info and apply it to the tables
                        For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In crTables
                            crTable.ApplyLogOnInfo(tableLogonInfo)
                        Next
                    End If
                Next
            Next

            docSendReport.Refresh()

            exportOpts.ExportFormatType = ExportFormatType.Excel
            Select Case pFormato
                Case "xls"
                    exportOpts.ExportFormatType = ExportFormatType.Excel
                    exportOpts.FormatOptions = xlsFormatOpts
                Case "pdf"
                    exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
                    exportOpts.FormatOptions = pdfFormatOpts
            End Select


            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile

            diskOpts.DiskFileName = pRutaDestino

            exportOpts.DestinationOptions = diskOpts

            With pParametrosImpresion
                For prntFrmtParamCounter = 0 To pParametrosImpresion.Count - 1
                    docSendReport.SetParameterValue(.Item(itmCounter).NombreParametro, .Item(itmCounter).Valor)
                Next
            End With

            docSendReport.Export(exportOpts)
            docSendReport.Close()

            msg.setInfo("Se creó correctamente la representación impresa en " + pRutaDestino)
        Catch ex As Exception
            msg.setError("No fue posible crear la representación impresa: " + ex.Message)
        End Try

finalize:
        docSendReport = Nothing
        exportOpts = Nothing
        pdfFormatOpts = Nothing
        diskOpts = Nothing
        connectionInfo = Nothing

        Return msg
    End Function

    Public Function infoConexion(ByVal pParamConexion As ParametrosConexion) As TableLogOnInfo
        Dim oTblLogOnInfo As TableLogOnInfo = New TableLogOnInfo()
        Dim ConnectionInfo As ConnectionInfo = New ConnectionInfo()
        Dim cripto As Criptografo = New Criptografo

        ConnectionInfo.ServerName = pParamConexion.ServidorBd
        ConnectionInfo.DatabaseName = pParamConexion.BaseDeDatos
        ConnectionInfo.UserID = cripto.Desencriptar(pParamConexion.UsuarioBd, pParamConexion.BaseDeDatos)
        ConnectionInfo.Password = cripto.Desencriptar(pParamConexion.ContraseniaBd, pParamConexion.BaseDeDatos)

        oTblLogOnInfo.ConnectionInfo = ConnectionInfo

        Return oTblLogOnInfo
    End Function

    Public Function prepararInforme(ByVal pRutaFormato As String, _
                               ByVal pParametrosImpresion As List(Of ParametroImpresion)) As ReportDocument
        Dim docSendReport As ReportDocument = New ReportDocument

        Dim crReportObjects As CrystalDecisions.CrystalReports.Engine.ReportObjects = Nothing
        Dim crSubreportObject As CrystalDecisions.CrystalReports.Engine.SubreportObject = Nothing
        Dim crSubreportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = Nothing
        Dim crDatabase As CrystalDecisions.CrystalReports.Engine.Database = Nothing
        Dim crTables As CrystalDecisions.CrystalReports.Engine.Tables = Nothing

        Dim cripto As Criptografo = New Criptografo
        Dim itmCounter As Integer = 0

        Try
            msg.reset()

            docSendReport.Load(pRutaFormato, OpenReportMethod.OpenReportByTempCopy)


            Dim tables As Tables = docSendReport.Database.Tables
            Dim tableLogonInfo As TableLogOnInfo = infoConexion(paramCnx)

            For Each table In tables
                table.ApplyLogOnInfo(tableLogonInfo)
            Next

            'set the crSections object to the current report's sections
            Dim crSections As CrystalDecisions.CrystalReports.Engine.Sections = docSendReport.ReportDefinition.Sections

            'loop through all the sections to find all the report objects
            For Each crSection As CrystalDecisions.CrystalReports.Engine.Section In crSections

                crReportObjects = crSection.ReportObjects
                'loop through all the report objects to find all the subreports
                For Each crReportObject As CrystalDecisions.CrystalReports.Engine.ReportObject In crReportObjects
                    If crReportObject.Kind = ReportObjectKind.SubreportObject Then

                        'you will need to typecast the reportobject to a subreport 
                        'object once you find it
                        crSubreportObject = crReportObject

                        'open the subreport object
                        crSubreportDocument = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName)

                        'set the database and tables objects to work with the subreport
                        crDatabase = crSubreportDocument.Database
                        crTables = crDatabase.Tables

                        'loop through all the tables in the subreport and 
                        'set up the connection info and apply it to the tables
                        For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In crTables
                            crTable.ApplyLogOnInfo(tableLogonInfo)
                        Next
                    End If
                Next
            Next

            With pParametrosImpresion
                For prntFrmtParamCounter = 0 To pParametrosImpresion.Count - 1
                    docSendReport.SetParameterValue(.Item(prntFrmtParamCounter).NombreParametro, .Item(prntFrmtParamCounter).Valor)
                Next
            End With

            docSendReport.Refresh()

            msg.setInfo("Informe procesado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible procesar el informe: " + ex.Message)
        End Try

finalize:

        Return docSendReport
    End Function

    Public Function prepararMensaje() As Mensaje
        Try
            msg = env.configurar()
        Catch ex As Exception
            msg.setError("No fue posible preparar el mensaje de correo: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function enviarMensaje(ByVal pRutaArch1 As String, _
                                  Optional ByVal pRutaArch2 As String = "") As Mensaje
        Dim RutaAdjunto As String = ""
        Dim nombreAdjunto As String = ""
        Dim direccionesEnvio As String() = Nothing

        Try
            msg.reset()

            env.limpiarInfoDestino()


            msg = env.adjuntarPdf(pRutaArch1)
            If msg.EsError Then GoTo finalize

            If pRutaArch2.Trim.Length > 0 Then
                msg = env.adjuntarPdf(pRutaArch2)
                If msg.EsError Then GoTo finalize
            End If


            direccionesEnvio = env.PropiedadesCorreo.Para.Split({",", ";"}, StringSplitOptions.RemoveEmptyEntries)

            For Each direccion As String In direccionesEnvio
                msg = env.cuentaDestino(direccion)
                If msg.EsError Then GoTo finalize
            Next

            direccionesEnvio = env.PropiedadesCorreo.ConCopia.Split({",", ";"}, StringSplitOptions.RemoveEmptyEntries)

            For Each direccion As String In direccionesEnvio
                msg = env.conCopia(direccion)
                If msg.EsError Then GoTo finalize
            Next

            direccionesEnvio = env.PropiedadesCorreo.ConCopiaOculta.Split({",", ";"}, StringSplitOptions.RemoveEmptyEntries)

            For Each direccion As String In direccionesEnvio
                msg = env.conCopiaOculta(direccion)
                If msg.EsError Then GoTo finalize
            Next

            msg = env.enviarMensaje()
        Catch ex As Exception
            msg.setError("No fue posible enviar el mensaje de correo: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Public Sub terminar()
        env.terminar()
        env = Nothing
    End Sub

End Class
