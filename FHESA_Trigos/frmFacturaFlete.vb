Imports Genericas
Imports ObjEntidades

Public Class frmFacturaFlete
    Private msg As Mensaje

    Private cliente As ClienteSql
    Private Cnfg As Configuracion
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil


    Private genW As GenericasWin
    Private InfDoc As InformacionDocumento

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
                   ByVal pConfiguracion As Configuracion, ByVal pUsuario As Usuario)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        msg = New Mensaje

        genW = pGenW
        cliente = pCliente
        Cnfg = pConfiguracion

        Usua = pUsuario
        atmPerf = Usua.Perfil.Detalle.obtenerAtomo(27)

        cargarEmbarques()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub cargarEmbarques()
        Dim itmCounter As Integer = 0
        Dim Emb As Embarque = Nothing
        Dim resultados As DataTable = Nothing

        Try
            InfDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dAjuste, cliente.ParametrosConexion.BaseDeDatos, _
                                              "", "", "", "")


            grdEmbarques.DataSource = Nothing
            grdEmbarques.Rows.Clear()
            grdEmbarques.Columns.Clear()

            Emb = New Embarque(cliente)
            resultados = Emb.sinFacturaFlete()

            grdEmbarques.Font = New Font(grdEmbarques.Font.FontFamily.Name, 8, FontStyle.Regular)
            grdEmbarques.DataSource = New DataView(resultados)
            grdEmbarques.SelectionMode = DataGridViewSelectionMode.CellSelect
            grdEmbarques.AllowUserToDeleteRows = False
            grdEmbarques.AllowUserToOrderColumns = True
            grdEmbarques.AllowUserToAddRows = False
            grdEmbarques.AllowUserToResizeColumns = True
            grdEmbarques.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grdEmbarques.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

            'For itmCounter = 6 To grdEmbarques.ColumnCount - 1
            '    grdEmbarques.Columns(itmCounter).Visible = False
            'Next

            If grdEmbarques.RowCount > 0 Then
                Dim eventarg As DataGridViewCellEventArgs = New DataGridViewCellEventArgs(0, 0)

                grdEmbarques_CellClick(New Object, eventarg)
            End If

            msg.setInfo(grdEmbarques.RowCount.ToString + " embarques encontrados sin Factura Flete.")
        Catch ex As Exception
            msg.setError("No fue posible cargar los Embarques sin Factura Flete: " + ex.Message)
        End Try

        genW.publicar(InfDoc, msg)
    End Sub

    Private Sub actualizarEmbarque(ByVal pNoRenglon As Integer)
        Dim emb As Embarque = Nothing
        Dim nfactfl As String = ""
        Dim nTarifa As Decimal = "0"
        Try
            msg.reset()

            nfactfl = grdEmbarques.Rows(pNoRenglon).Cells(grdEmbarques.ColumnCount - 1).Value.ToString.Trim
            nTarifa = grdEmbarques.Rows(pNoRenglon).Cells(6).Value.ToString.Trim

            emb = New Embarque(cliente, grdEmbarques.Rows(pNoRenglon).Cells(0).Value)

            If Not emb.Factfl.Equals(nfactfl) Then
                InfDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, cliente.ParametrosConexion.BaseDeDatos, _
                                                  "sEmb1", emb.EmbId, "", "")
                emb.setUsuarioModifica(Usua.UsrId)
                emb.setFacturaFlete(nfactfl)
                msg = emb.actualizar().clonar()
            Else
                msg.setAdvertencia("El embarque " + emb.EmbId + " ya tiene asignada la factura Flete " + nfactfl + ". No se actualizará el documento.")
            End If
            If Not emb.Tarifa.Equals(nTarifa) Then
                InfDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, cliente.ParametrosConexion.BaseDeDatos, _
                                                  "sEmb1", emb.EmbId, "", "")
                emb.setUsuarioModifica(Usua.UsrId)
                emb.setTarifa(nTarifa)
                msg = emb.actualizar().clonar()
            Else
                msg.setAdvertencia("El embarque " + emb.EmbId + " ya tiene asignada la factura Flete " + nfactfl + ". No se actualizará el documento.")
            End If


        Catch ex As Exception
            msg.setError("No fue posible actualizar el Embarque: " + ex.Message)
        End Try

        genW.publicar(InfDoc, msg)
    End Sub

    Private Sub abrirEmbarque(ByVal pNoRenglon As Integer)
        Dim frmEmbarque As frmEmbarque = Nothing

        Try
            frmEmbarque = New frmEmbarque(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua, _
                                          grdEmbarques.Rows(pNoRenglon).Cells(0).Value)
            frmEmbarque.MdiParent = Me.MdiParent
            frmEmbarque.Show()

        Catch ex As Exception
            msg.setError("No fue posible abrir el Embarque: " + ex.Message)
        End Try

        genW.publicar(InfDoc, msg, True)
    End Sub

    Private Sub grdEmbarques_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grdEmbarques.CellBeginEdit
        If e.ColumnIndex < 0 Then Exit Sub
        If e.ColumnIndex < grdEmbarques.ColumnCount - 2 Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub grdEmbarques_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdEmbarques.CellClick

    End Sub

    Private Sub grdEmbarques_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdEmbarques.CellEndEdit
        If e.RowIndex < 0 Then Exit Sub

        actualizarEmbarque(e.RowIndex)
    End Sub

    Private Sub cmdActualizar_Click(sender As Object, e As EventArgs) Handles cmdRefrescar.Click
        cargarEmbarques()
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdEmbarques_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdEmbarques.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        If Not e.ColumnIndex.Equals(0) Then Exit Sub

        abrirEmbarque(e.RowIndex)
    End Sub


    Private Sub grdEmbarques_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdEmbarques.CellContentClick

    End Sub
End Class