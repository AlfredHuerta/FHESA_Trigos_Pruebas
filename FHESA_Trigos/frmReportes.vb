Imports Genericas
Imports ObjEntidades

Public Class frmReportes
    Private msg As Mensaje
    Private cliente As ClienteSql
    Private Usua As Usuario
    Private Cnfg As Configuracion

    Private GenW As GenericasWin

    Private reps As Reportes
    Private InfDoc As InformacionDocumento

    Private textoSel As TextBox

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

#Region "Métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pGenW As GenericasWin, _
                   ByVal pConfiguracion As Configuracion, ByVal pUsuario As Usuario)
        InitializeComponent()

        msg = New Mensaje
        cliente = pCliente
        GenW = pGenW

        InfDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dNinguno, cliente.ParametrosConexion.BaseDeDatos, _
                                  "", "", "", "")

        Cnfg = pConfiguracion
        Usua = pUsuario

        cargarReportes()
    End Sub

    Private Sub cargarReportes()
        Dim tReportes As DataTable = Nothing

        Try
            reps = New Reportes(cliente)
            tReportes = reps.cargarReportes()
            msg = reps.Mensaje

            If msg.EsError Then GoTo finalize

            dgvReportes.DataSource = Nothing
            dgvReportes.Rows.Clear()
            dgvReportes.Columns.Clear()

            dgvReportes.DataSource = New DataView(tReportes)
            dgvReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvReportes.AllowUserToDeleteRows = False
            dgvReportes.AllowUserToOrderColumns = False
            dgvReportes.AllowUserToAddRows = False
            dgvReportes.AllowUserToResizeColumns = True
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            dgvReportes.EditMode = DataGridViewEditMode.EditProgrammatically

            dgvReportes.Columns(0).Visible = False
            dgvReportes.Columns(2).Visible = False
            dgvReportes.Columns(3).Visible = False
            dgvReportes.Columns(5).Visible = False
            dgvReportes.Columns(6).Visible = False
        Catch ex As Exception
            msg.setError("No fue posible configurar la ventana de reportes: " + ex.Message)
        End Try

finalize:
        GenW.publicar(InfDoc, msg, True)
    End Sub

    Private Function cargarControles(ByVal pIdxReporte As Integer) As Mensaje
        Dim itmCounter As Integer = 0
        Dim control As Control = Nothing

        Try
            msg.reset()

            reps.Reportes.Item(pIdxReporte).inicializarControles(gpbParametros)

            For itmCounter = 0 To reps.Reportes.Item(pIdxReporte).Parametros.Count - 1
                control = reps.Reportes.Item(pIdxReporte).agregarControl(gpbParametros, itmCounter)
                msg = reps.Reportes.Item(pIdxReporte).Mensaje
                If msg.EsError Then GoTo finalize

                If Me.Width < 367 + reps.Reportes.Item(pIdxReporte).AnchoGrupo + 45 Then
                    Me.Width = 367 + reps.Reportes.Item(pIdxReporte).AnchoGrupo + 46
                End If

                If reps.Reportes.Item(pIdxReporte).Parametros.Item(itmCounter).TpodatId = 1 Then
                    Select Case reps.Reportes.Item(pIdxReporte).Parametros.Item(itmCounter).TpodocId
                        Case 2
                            AddHandler control.KeyDown, AddressOf buscarLote
                        Case 3
                            AddHandler control.KeyDown, AddressOf buscarOrden
                        Case 8
                            AddHandler control.KeyDown, AddressOf buscarTrigo
                        Case 9
                            AddHandler control.KeyDown, AddressOf buscarOrigen
                        Case 10
                            AddHandler control.KeyDown, AddressOf buscarDestino
                        Case 11
                            AddHandler control.KeyDown, AddressOf buscarOperador
                        Case 12
                            control.Tag = "T001"
                            AddHandler control.KeyDown, AddressOf buscarProveedor
                        Case 13
                            control.Tag = "T002"
                            AddHandler control.KeyDown, AddressOf buscarProveedor
                        Case 14
                            control.Tag = "T003"
                            AddHandler control.KeyDown, AddressOf buscarProveedor
                        Case 15
                            control.Tag = "T004"
                            AddHandler control.KeyDown, AddressOf buscarProveedor
                        Case 16
                            AddHandler control.KeyDown, AddressOf buscarSilo
                    End Select
                End If

                AddHandler control.GotFocus, AddressOf enfocar
            Next

        Catch ex As Exception
            msg.setError("No fue posible cargar los controles del reporte: " + ex.Message)
        End Try

finalize:
        GenW.publicar(InfDoc, msg, True)
        Return msg
    End Function

    Private Sub enfocar(sender As Object, e As EventArgs)
        If dgvReportes.CurrentRow Is Nothing Then Exit Sub
        If dgvReportes.CurrentRow.Index < 0 Then Exit Sub

        Dim ControlNum As String = ""

        For Each c As Char In Me.ActiveControl.Name
            If IsNumeric(c) Then
                ControlNum += c
            End If
        Next

        msg.setInfo(reps.Reportes.Item(dgvReportes.CurrentRow.Index).Parametros.Item(Integer.Parse(ControlNum)).Leyenda)
        GenW.publicar(InfDoc, msg)

    End Sub

    Private Sub buscarLote(sender As Object, e As KeyEventArgs)
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 3, 1, Me.ActiveControl.Text, "A", "", "", "1899-12-31", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Lote: " + ex.Message)
        End Try

finalize:
    End Sub

    Private Function buscarOrden(sender As Object, e As KeyEventArgs) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 5, 1, Me.ActiveControl.Text, "", "1899-12-31", _
                                          "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar la Orden: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarTrigo(sender As Object, e As KeyEventArgs) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 2, 1, Me.ActiveControl.Text, "", "1", "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Trigo: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarOrigen(sender As Object, e As KeyEventArgs) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 4, 1, Me.ActiveControl.Text, "", "1", "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Origen: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarDestino(sender As Object, e As KeyEventArgs) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 6, 1, Me.ActiveControl.Text, "", "1", "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Destino: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarOperador(sender As Object, e As KeyEventArgs) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 7, 1, Me.ActiveControl.Text, "", "1", "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Proveedor de Trigo: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function buscarProveedor(sender As Object, e As KeyEventArgs) As Mensaje
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 1, 1, Me.ActiveControl.Text, Me.ActiveControl.Tag, "1", "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Proveedor de Trigo: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Sub buscarSilo(sender As Object, e As KeyEventArgs)
        Dim frmBusq As frmBusqueda = Nothing
        Dim resultados As String() = Nothing

        Try
            If e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                frmBusq = New frmBusqueda(cliente, GenW, 11, 1, Me.ActiveControl.Text, "1", "", "", "", "")

                If Not frmBusq.Seleccionado Then frmBusq.ShowDialog()
                resultados = frmBusq.Resultados

                If resultados.GetUpperBound(0) >= 0 Then
                    If Not resultados(0).Trim.Length.Equals(0) Then
                        Me.ActiveControl.Text = resultados(0)

                        Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                    Else
                        Me.ActiveControl.Text = ""
                    End If
                Else
                    Me.ActiveControl.Text = ""
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible buscar el Lote: " + ex.Message)
        End Try

finalize:
    End Sub
#End Region




    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim frmVisorInf As frmVisorInforme = Nothing
        Dim param As List(Of ParametroImpresion) = New List(Of ParametroImpresion)
        Dim rutaInf As String = ""
        Dim itmCounter As Integer = 0
        Dim valor As String = ""

        Dim control As Control = Nothing

        Try
            If dgvReportes.CurrentRow Is Nothing Then
                msg.setAdvertencia("Debe seleccionar un reporte para visualisar.")
                GoTo finalize
            End If

            If dgvReportes.CurrentRow.Index < 0 Then
                msg.setAdvertencia("Debe seleccionar un reporte para visualisar.")
                GoTo finalize
            End If

            If gpbParametros.Controls.Count.Equals(0) Then
                msg.setAdvertencia("Debe seleccionar un reporte para visualisar.")
                GoTo finalize
            End If

            With reps.Reportes.Item(dgvReportes.CurrentRow.Index)
                If Not Usua.Perfil.Detalle.obtenerAtomo(.OpcionId).Consulta Then
                    msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                    GoTo finalize
                End If

                For itmCounter = 0 To .Parametros.Count - 1
                    Select Case .Parametros.Item(itmCounter).TpodatId
                        Case 1
                            control = gpbParametros.Controls.Item("txtParam" + itmCounter.ToString)
                            valor = control.Text
                        Case 2
                            control = gpbParametros.Controls.Item("dtpParam" + itmCounter.ToString)
                            valor = Format(TryCast(control, DateTimePicker).Value, "yyyy-MM-dd")
                        Case 3
                            control = gpbParametros.Controls.Item("chkParam" + itmCounter.ToString)
                            valor = Math.Abs(CInt(TryCast(control, CheckBox).Checked)).ToString
                        Case 4
                            control = gpbParametros.Controls.Item("dtpParam" + itmCounter.ToString)
                            valor = Format(TryCast(control, DateTimePicker).Value, "yyyy-MM-ddTHH:mm:dd")
                        Case 5
                            control = gpbParametros.Controls.Item("rdbParam" + itmCounter.ToString)
                            valor = Math.Abs(CInt(TryCast(control, RadioButton).Checked)).ToString
                    End Select

                    If valor.Trim.Length.Equals(0) And .Parametros.Item(itmCounter).Rqrido Then
                        control.Focus()
                        msg.setError("El valor de " + .Parametros.Item(itmCounter).Dscrpcion + " es requerido.")

                        GoTo finalize
                    End If

                    param.Add(New ParametroImpresion(itmCounter, .Parametros.Item(itmCounter).Nmbparam, "", valor))
                Next

                frmVisorInf = New frmVisorInforme(cliente, GenW, param, _
                                                  Cnfg.CarpImp + .Nmbrpt, .Titulo)
            End With

            frmVisorInf.MdiParent = Me.MdiParent
            frmVisorInf.Show()

            msg = frmVisorInf.Mensaje
        Catch ex As Exception
            msg.setError("No fue posible procesar el reporte: " + ex.Message)
        End Try

finalize:
        GenW.publicar(InfDoc, msg)
    End Sub





    Private Sub dgvReportes_Click(sender As Object, e As EventArgs) Handles dgvReportes.Click
        If dgvReportes.CurrentRow Is Nothing Then Exit Sub
        If dgvReportes.CurrentRow.Index < 0 Then Exit Sub

        cargarControles(dgvReportes.CurrentRow.Index)
    End Sub

    Private Sub frmReportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        If dgvReportes.RowCount > 0 Then
            msg.setInfo("Seleccione un informe para visualizar.")
            GenW.publicar(InfDoc, msg)
        End If

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class