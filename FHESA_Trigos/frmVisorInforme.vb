Imports Genericas

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms

Public Class frmVisorInforme
    Private msg As Mensaje

    Private visor As CrystalReportViewer
    Private genW As GenericasWin

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property PermiteMoverRegistros() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarDocumentos() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarEstado() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteImprimir() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteBuscarHistorial() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pGenW As GenericasWin, _
                   ByVal pParamImpr As List(Of ParametroImpresion), _
                   ByVal pRutaInf As String, ByVal pTitulo As String)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        msg = New Mensaje
        genW = pGenW
        confVisor(pTitulo)
        generarInforme(pCliente, pParamImpr, pRutaInf)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub confVisor(ByVal pTitulo As String)
        Try
            visor = New CrystalReportViewer
            visor.EnableRefresh = False

            visor.Location = New System.Drawing.Point(0, 0)
            visor.Width = Me.Width
            visor.Height = Me.Height
            visor.Visible = True

            Me.Controls.Add(visor)
            Me.Text = pTitulo
        Catch ex As Exception
            msg.setError("No fue posible configurar el visor del informe: " + ex.Message)
        End Try
    End Sub


    Private Function generarInforme(ByVal pCliente As ClienteSql, _
                                    ByVal pParamImp As List(Of ParametroImpresion), _
                                    ByVal pRutaInf As String) As Mensaje
        Dim arch As Archivador = Nothing
        Dim rptd As ReportDocument = Nothing

        Try
            arch = New Archivador(pCliente.ParametrosConexion, Nothing)

            rptd = arch.prepararInforme(pRutaInf, pParamImp)
            msg = arch.Mensaje
            If msg.EsError Then GoTo finalize


            visor.ReportSource = rptd

            Dim paramFields As New ParameterFields()
            Dim paramField As New ParameterField()
            Dim discreteVal As New ParameterDiscreteValue()
            Dim rangeVal As New ParameterRangeValue()


            With pParamImp
                For prntFrmtParamCounter = 0 To .Count - 1
                    paramField = New ParameterField()
                    paramField.ParameterFieldName = .Item(prntFrmtParamCounter).NombreParametro

                    discreteVal = New ParameterDiscreteValue
                    discreteVal.Value = .Item(prntFrmtParamCounter).Valor
                    paramField.CurrentValues.Add(discreteVal)

                    paramFields.Add(paramField)
                Next
            End With

            visor.ParameterFieldInfo = paramFields
            Dim oTblLogOnInfos As TableLogOnInfos = New TableLogOnInfos()
            Dim infoCnx As TableLogOnInfo = arch.infoConexion(pCliente.ParametrosConexion)

            oTblLogOnInfos.Add(infoCnx)

            visor.LogOnInfo = oTblLogOnInfos


            visor.Refresh()
            'visor.ReportSource.close()
            'rptd.Close()

            msg.setInfo("Informe procesado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible generar el informe: " + ex.Message)
        End Try

finalize:
        rptd = Nothing
        Return msg
    End Function

    Private Sub frmVisorInforme_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not visor.ReportSource Is Nothing Then _
            visor.ReportSource.close()
    End Sub

    Private Sub frmVisorInforme_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub frmVisorInforme_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Not visor Is Nothing Then
            visor.Width = Me.Width - 30
            visor.Height = Me.Height - 60
        End If
    End Sub
End Class