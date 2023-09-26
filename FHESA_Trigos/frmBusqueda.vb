

Imports Genericas
Imports ObjEntidades

Public Class frmBusqueda
    Private msg As Mensaje
    Private genW As GenericasWin
    Private InfDoc As InformacionDocumento

    Private valorResult As String()
    Private Opcion As Integer
    Private bSelec As Boolean

    Private dgvea As DataGridViewCellMouseEventArgs

    Public ReadOnly Property Resultados() As String()
        Get
            Return valorResult
        End Get
    End Property

    Public ReadOnly Property Seleccionado() As Boolean
        Get
            Return bSelec
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pGenW As GenericasWin, _
                   ByVal pOpcion As Integer, ByVal pFuncion As Integer, _
                   ByVal pParam1 As String, ByVal pParam2 As String, ByVal pParam3 As String, _
                   ByVal pParam4 As String, ByVal pParam5 As String, ByVal pParam6 As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        msg = New Mensaje
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Opcion = pOpcion
        genW = pGenW

        valorResult = {""}
        bSelec = False

        InfDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dNinguno, pCliente.ParametrosConexion.BaseDeDatos, _
                                          "NINGUNA", "", "", "")
        llenarGrid(pCliente, pOpcion, pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5, pParam6)
    End Sub
    Private Sub frmBusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function llenarGrid(ByVal pCliente As ClienteSql, ByVal pOpcion As Integer, ByVal pFuncion As Integer, _
                                ByVal pParam1 As String, ByVal pParam2 As String, ByVal pParam3 As String, _
                                ByVal pParam4 As String, ByVal pParam5 As String, ByVal pParam6 As String) As Mensaje
        Dim Busq As Busquedas = Nothing
        Dim resultados As DataTable = Nothing

        Try
            msg.reset()
            Busq = New Busquedas(pCliente)

            Select Case pOpcion
                Case 1
                    Me.Text = "Buscar Proveedor..."
                    resultados = Busq.buscarProveedor(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5)
                Case 2
                    Me.Text = "Buscar Trigo..."
                    resultados = Busq.buscarTrigo(pFuncion, pParam1, pParam2, pParam3)
                Case 3
                    Me.Text = "Buscar Lote..."
                    resultados = Busq.buscarLote(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5)
                Case 4
                    Me.Text = "Buscar Origen..."
                    resultados = Busq.buscarOrigen(pFuncion, pParam1, pParam2, pParam3)
                Case 5
                    Me.Text = "Buscar Orden..."
                    resultados = Busq.buscarOrden(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5, pParam6)
                Case 6
                    Me.Text = "Buscar Destino..."
                    resultados = Busq.buscarDestino(pFuncion, pParam1, pParam2, pParam3)
                Case 7
                    Me.Text = "Buscar Operador..."
                    resultados = Busq.buscarOperador(pFuncion, pParam1, pParam2, pParam3)
                Case 8
                    Me.Text = "Buscar Embarque..."
                    resultados = Busq.buscarEmbarque(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5, pParam6)
                Case 9
                    Me.Text = "Buscar Ajuste..."
                    resultados = Busq.buscarAjuste(pFuncion, pParam1, pParam2, pParam3, pParam4)
                Case 10
                    Me.Text = "Buscar Venta..."
                    resultados = Busq.buscarVenta(pFuncion, pParam1, pParam2, pParam3, pParam4)
                Case 11
                    Me.Text = "Buscar Silo..."
                    resultados = Busq.buscarSilo(pFuncion, pParam1, pParam2)
                Case 15
                    Me.Text = "Buscar Perfil..."
                    resultados = Busq.buscarPerfiles(pFuncion, pParam1, pParam2, pParam3)
                Case 16
                    Me.Text = "Buscar Usuario..."
                    resultados = Busq.buscarUsuarios(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5, pParam6)
                Case 17
                    Me.Text = "Buscar Orden Transferencia..."
                    resultados = Busq.buscarOrdenOrigen(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5, pParam6)
                Case 18
                    Me.Text = "Buscar Ubicación Temporal..."
                    resultados = Busq.buscarUbicaciones(pFuncion, pParam1, pParam2, pParam3)
                Case 19
                    Me.Text = "Buscar Orden..."
                    resultados = Busq.buscarOrdenSOrigen(pFuncion, pParam1, pParam2, pParam3, pParam4, pParam5, pParam6)
            End Select

            grdResultados.DataSource = Nothing
            grdResultados.Rows.Clear()
            grdResultados.Columns.Clear()

            grdResultados.Font = New Font(grdResultados.Font.FontFamily.Name, 7, FontStyle.Regular)

            grdResultados.DataSource = New DataView(resultados)
            grdResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grdResultados.AllowUserToDeleteRows = False
            grdResultados.AllowUserToOrderColumns = True
            grdResultados.AllowUserToAddRows = False
            grdResultados.AllowUserToResizeColumns = True
            grdResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grdResultados.EditMode = DataGridViewEditMode.EditProgrammatically


            If grdResultados.Rows.Count = 1 Then
                grdResultados.CurrentCell = grdResultados(0, 0)
                seleccion()

                genW.publicar(InfDoc, msg, True)

                If Not msg.EsError Then
                    bSelec = True
                    Me.Close()
                End If
            End If

            grdResultados.AutoResizeColumns()
            grdResultados_ColumnHeaderMouseClick(New Object, New DataGridViewCellMouseEventArgs(0, 0, 0, 0, New MouseEventArgs(Windows.Forms.MouseButtons.None, 0, 0, 0, 0)))
        Catch ex As Exception
            msg.setError("No fue posible llenar el Grid: " + ex.Message)
        End Try

        genW.publicar(InfDoc, msg, True)
        Return msg
    End Function

    Private Function seleccion() As Mensaje
        Try
            If grdResultados.CurrentRow.Index < 0 Then
                msg.setError("La selección no es válida")

                GoTo finalize
            End If

            Select Case Opcion
                Case 1
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 2
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 3
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value}
                Case 4
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 5
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(2).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(5).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(6).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(8).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(9).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(10).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(11).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(12).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(13).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(14).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(15).Value}
                Case 6
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 7
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 8
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 9
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 10
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 11
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 15
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 16
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 17
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(2).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(5).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(6).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(8).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(9).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(10).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(11).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(12).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(13).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(14).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(15).Value}
                Case 18
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value}
                Case 19
                    valorResult = {grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(0).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(1).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(2).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(5).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(6).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(8).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(9).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(10).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(11).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(12).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(13).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(14).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(15).Value, _
                                   grdResultados.Rows(grdResultados.CurrentRow.Index).Cells(16).Value}
            End Select
        Catch ex As Exception
            msg.setError("No fue posible establecer la selección: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Sub grdResultados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdResultados.CellClick

    End Sub

    Private Sub grdResultados_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdResultados.ColumnHeaderMouseClick
        dgvea = e
        txtBuscar.Focus()
    End Sub



    Private Sub grdResultados_DoubleClick(sender As Object, e As EventArgs) Handles grdResultados.DoubleClick
        seleccion()

        genW.publicar(InfDoc, msg, True)

        If Not msg.EsError Then
            bSelec = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdSeleccionar_Click(sender As Object, e As EventArgs) Handles cmdSeleccionar.Click
        seleccion()

        genW.publicar(InfDoc, msg, True)

        If Not msg.EsError Then
            bSelec = True
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub



    Private Sub txtBuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyUp
        Dim itmCounter As Integer = 0

        For itmCounter = 0 To grdResultados.RowCount - 1
            If grdResultados(dgvea.ColumnIndex, itmCounter).Value.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper()) Then
                grdResultados.CurrentCell = grdResultados.Rows(itmCounter).Cells(dgvea.ColumnIndex)
                Exit For
            End If
        Next


    End Sub
End Class