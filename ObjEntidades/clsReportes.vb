Imports System.Windows.Forms
Imports System.Windows
Imports Genericas
Imports IfcDatos

Public Class Reportes
    Private msg As Mensaje
    Private iRpt As iReportes

    Private lRep As List(Of Reporte)

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property Reportes() As List(Of Reporte)
        Get
            Return lRep
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iRpt = New iReportes(pCliente)
    End Sub


    Public Function cargarReportes() As DataTable
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim rep As Reporte = Nothing
        Dim itmCounter As Integer = 0

        Try
            resultados = iRpt.leerEncabezados()
            msg = iRpt.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            lRep = New List(Of Reporte)
            For itmCounter = 0 To resultados.Rows.Count - 1
                rep = New Reporte(iRpt)
                msg = rep.alimentar(gen3E.valorCampo(resultados, itmCounter, "RprteId"), _
                              gen3E.valorCampo(resultados, itmCounter, "Título"), _
                              Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Activo", "false")), _
                              gen3E.valorCampo(resultados, itmCounter, "Fecha Integración"), _
                              gen3E.valorCampo(resultados, itmCounter, "Fchmod"), _
                              gen3E.valorCampo(resultados, itmCounter, "Nmbrpt"), _
                              gen3E.valorCampo(resultados, itmCounter, "OpcionId")).clonar()

                If msg.EsError Then GoTo finalize

                lRep.Add(rep)
            Next



            msg.setInfo("Reportes del sistema recuperados con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible cargar los encabezados de los reportes: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return resultados
    End Function

    Public Sub liberarObjetos()
        msg = Nothing
        iRpt = Nothing
    End Sub
End Class


Public Class Reporte
    Private msg As Mensaje
    Private iRpt As iReportes

    Private sRprteId As String
    Private sTitulo As String
    Private bActivo As Boolean
    Private sFchint As String
    Private sFchmod As String
    Private sNmbrpt As String
    Private sOpcionId As String

    Private lParam As List(Of ParametroReporte)

    Private topControl As Integer
    Private leftControl As Integer
    Private anchoGrp As Integer

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property RprteId() As String
        Get
            Return sRprteId
        End Get
    End Property
    Public ReadOnly Property Titulo() As String
        Get
            Return sTitulo
        End Get
    End Property
    Public ReadOnly Property Activo() As Boolean
        Get
            Return bActivo
        End Get
    End Property

    Public ReadOnly Property Fchint() As String
        Get
            Return sFchint
        End Get
    End Property

    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property

    Public ReadOnly Property Nmbrpt() As String
        Get
            Return sNmbrpt
        End Get
    End Property

    Public ReadOnly Property OpcionId As String
        Get
            Return sOpcionId
        End Get
    End Property

    Public ReadOnly Property AnchoGrupo As Integer
        Get
            Return anchoGrp
        End Get
    End Property

    Public ReadOnly Property Parametros() As List(Of ParametroReporte)
        Get
            Return lParam
        End Get
    End Property

    Public Sub New(ByVal piRep As iReportes)
        msg = New Mensaje
        iRpt = piRep

        reiniciar()
    End Sub

    Public Function alimentar(ByVal pRprteId As Integer, ByVal pTitulo As String, ByVal pActivo As Boolean, ByVal pFchint As String, _
                              ByVal pFchmod As String, ByVal pNmbrpt As String, pOpcionId As String) As Mensaje
        Dim gen3E As Genericas3E = Nothing

        Dim params As DataTable = Nothing
        Dim param As ParametroReporte = Nothing

        Dim itmCounter As Integer = 0

        Try
            msg.reset()

            sRprteId = pRprteId
            sTitulo = pTitulo
            bActivo = pActivo
            sFchint = pFchint
            sFchmod = pFchmod
            sNmbrpt = pNmbrpt
            sOpcionId = pOpcionId

            params = iRpt.leerParametros(pRprteId)
            msg = iRpt.Mensaje.clonar()

            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            lParam = New List(Of ParametroReporte)
            For itmCounter = 0 To params.Rows.Count - 1
                param = New ParametroReporte(gen3E.valorCampo(params, itmCounter, "RprteId"), _
                                             gen3E.valorCampo(params, itmCounter, "ParamId"), _
                                             gen3E.valorCampo(params, itmCounter, "Nmbparam"), _
                                             gen3E.valorCampo(params, itmCounter, "Dscrpcion"), _
                                             gen3E.valorCampo(params, itmCounter, "TpodatId"), _
                                             gen3E.valorCampo(params, itmCounter, "TpodocId"), _
                                             gen3E.valorCampo(params, itmCounter, "Leyenda"), _
                                             Boolean.Parse(gen3E.valorCampo(params, itmCounter, "Activo", "false")), _
                                             gen3E.valorCampo(params, itmCounter, "Defecto"), _
                                             Boolean.Parse(gen3E.valorCampo(params, itmCounter, "Rqrido", "false")))

                lParam.Add(param)
            Next

        Catch ex As Exception
            msg.setError("No fue posible alimentar las variables de reporte" + sRprteId + ": " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub inicializarControles(ByRef pGroupBox As GroupBox)
        pGroupBox.Controls.Clear()
        topControl = 20
        leftControl = 20
        anchoGrp = 240
    End Sub


    Public Function agregarControl(ByRef pGroupBox As GroupBox, ByVal pNumParametro As Integer) As Control
        Dim etiq As Label = Nothing
        Dim texto As TextBox = Nothing
        Dim fecha As DateTimePicker = Nothing
        Dim check As CheckBox = Nothing
        Dim radio As RadioButton = Nothing

        Dim control As Control = Nothing

        Try
            msg.reset()

            If topControl >= 235 And pGroupBox.Width <= leftControl + 260 Then
                anchoGrp = pGroupBox.Width + 260
            End If

            If topControl >= 235 Then
                topControl = 20
                leftControl += 260
            End If

            If lParam.Item(pNumParametro).TpodatId = 1 Or lParam.Item(pNumParametro).TpodatId = 2 Then
                etiq = New Label
                etiq.Name = "lblParam" + pNumParametro.ToString
                etiq.Left = leftControl
                etiq.Top = topControl
                etiq.Width = 200
                etiq.Height = 14
                etiq.Text = lParam.Item(pNumParametro).Dscrpcion

                pGroupBox.Controls.Add(etiq)
                topControl += 15
            End If

            Select Case lParam.Item(pNumParametro).TpodatId
                Case 1
                    texto = New TextBox
                    texto.Name = "txtParam" + pNumParametro.ToString
                    texto.Left = leftControl
                    texto.Top = topControl
                    texto.Width = 150
                    texto.Height = 20
                    texto.Multiline = True
                    texto.AcceptsTab = True
                    texto.Text = lParam.Item(pNumParametro).Defecto
                    texto.Tag = pNumParametro

                    pGroupBox.Controls.Add(texto)

                    control = TryCast(texto, Control)
                Case 2, 4
                    Dim valorFecha As DateTime = Nothing

                    fecha = New DateTimePicker
                    fecha.Name = "dtpParam" + pNumParametro.ToString
                    fecha.Left = leftControl
                    fecha.Top = topControl
                    fecha.Width = 150
                    fecha.Height = 20
                    fecha.Format = DateTimePickerFormat.Short


                    If DateTime.TryParse(lParam.Item(pNumParametro).Defecto, valorFecha) Then
                        fecha.Value = valorFecha
                    End If

                    fecha.Tag = pNumParametro

                    pGroupBox.Controls.Add(fecha)
                    control = TryCast(fecha, Control)
                Case 3
                    Dim valorBooleano As Boolean = False


                    check = New CheckBox
                    check.Name = "chkParam" + pNumParametro.ToString
                    check.Left = leftControl
                    check.Top = topControl
                    check.Width = 200
                    check.Height = 20

                    check.Text = lParam.Item(pNumParametro).Dscrpcion

                    If Boolean.TryParse(lParam.Item(pNumParametro).Defecto, valorBooleano) Then
                        check.Checked = valorBooleano
                    End If

                    check.Tag = pNumParametro

                    pGroupBox.Controls.Add(check)
                    control = TryCast(check, Control)
                Case 5
                    Dim valorBooleano As Boolean = False


                    radio = New RadioButton
                    radio.Name = "rdbParam" + pNumParametro.ToString
                    radio.Left = leftControl
                    radio.Top = topControl
                    radio.Width = 200
                    radio.Height = 20

                    radio.Text = lParam.Item(pNumParametro).Dscrpcion

                    If Boolean.TryParse(lParam.Item(pNumParametro).Defecto, valorBooleano) Then
                        radio.Checked = valorBooleano
                    End If

                    radio.Tag = pNumParametro

                    pGroupBox.Controls.Add(radio)
                    control = TryCast(radio, Control)
            End Select

            If pNumParametro.Equals(0) Then _
                control.Focus()

            topControl += 25
        Catch ex As Exception
            msg.setError("No fue posible agregar el control: " + ex.Message)
        End Try

        Return control
    End Function

    Public Sub reiniciar()

        sRprteId = "0"
        sTitulo = ""
        bActivo = "0"
        sFchint = ""
        sFchmod = ""
        sNmbrpt = ""
    End Sub
End Class


Public Class ParametroReporte
    Private msg As Mensaje

    Private sRprteId As String
    Private sParamId As String
    Private sNmbparam As String
    Private sDscrpcion As String
    Private sTpodatId As String
    Private sTpodocId As String
    Private sLeyenda As String
    Private bActivo As Boolean
    Private sDefecto As String
    Private bRqrido As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property RprteId() As String
        Get
            Return sRprteId
        End Get
    End Property
    Public ReadOnly Property ParamId() As String
        Get
            Return sParamId
        End Get
    End Property
    Public ReadOnly Property Nmbparam() As String
        Get
            Return sNmbparam
        End Get
    End Property
    Public ReadOnly Property Dscrpcion() As String
        Get
            Return sDscrpcion
        End Get
    End Property
    Public ReadOnly Property TpodatId() As String
        Get
            Return sTpodatId
        End Get
    End Property
    Public ReadOnly Property TpodocId() As String
        Get
            Return sTpodocId
        End Get
    End Property
    Public ReadOnly Property Leyenda() As String
        Get
            Return sLeyenda
        End Get
    End Property

    Public ReadOnly Property Activo() As Boolean
        Get
            Return bActivo
        End Get
    End Property

    Public ReadOnly Property Defecto() As String
        Get
            Return sDefecto
        End Get
    End Property

    Public ReadOnly Property Rqrido() As Boolean
        Get
            Return bRqrido
        End Get
    End Property

    Public Sub New(ByVal pRprteId As String, ByVal pParamId As String, ByVal pNmbparam As String, ByVal pDscrpcion As String, _
                   ByVal pTpodatId As String, ByVal pTpodocId As String, ByVal pLeyenda As String, ByVal pActivo As Boolean, _
                   ByVal pDefecto As String, ByVal pRqrido As Boolean)
        msg = New Mensaje

        sRprteId = pRprteId
        sParamId = pParamId
        sNmbparam = pNmbparam
        sDscrpcion = pDscrpcion
        sTpodatId = pTpodatId
        sTpodocId = pTpodocId
        sLeyenda = pLeyenda
        bActivo = pActivo
        sDefecto = pDefecto
        bRqrido = pRqrido
    End Sub


    Public Sub reiniciar()

        sRprteId = ""
        sParamId = ""
        sNmbparam = ""
        sDscrpcion = ""
        sTpodatId = ""
        sTpodocId = ""
        sLeyenda = ""
        bActivo = "0"
        sDefecto = ""
        bRqrido = "0"
    End Sub
End Class