Imports System.IO

Imports Genericas
Imports ObjEntidades

Public Class frmCargadorMasivoEmb
    Private msg As Mensaje
    Private infDoc As InformacionDocumento
    Private cliente As ClienteSql
    Private Cnfg As Configuracion
    Private Usua As Usuario
    Private atmPerf As AtomoPerfil

    Private genW As GenericasWin

    Private Modop As SysEnums.Modos
    Private modificado As Boolean = False
    Private forzarBusqueda As Boolean = False


    Private ubicMouse As DataGridViewCellEventArgs


    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property Modo() As SysEnums.Modos
        Get
            Return Modop
        End Get
    End Property

    Public ReadOnly Property PermiteMoverRegistros() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarDocumentos() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarEstado() As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property PermiteImprimir() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteBuscarHistorial() As Boolean
        Get
            Return True
        End Get
    End Property

#Region "Métodos de usuario"
    Public Sub New(ByVal pCliente As ClienteSql, ByVal pgenW As GenericasWin, _
                   ByVal pConfiguracion As Configuracion, ByVal pUsuario As Usuario)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        msg = New Mensaje
        cliente = pCliente
        genW = pgenW


        Try
            If inicializarControles().EsError Then GoTo finalize
            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, cliente.ParametrosConexion.BaseDeDatos, _
                                              "sEmb1", "", "", "")

            Cnfg = pConfiguracion
            Usua = pUsuario
            atmPerf = Usua.Perfil.Detalle.obtenerAtomo(28)


            setConsultar()

        Catch ex As Exception
            msg.setError("No fue posible inicializar la ventana: " + ex.Message)
        End Try
finalize:
        genW.publicar(infDoc, msg, True)
    End Sub

    Private Function inicializarControles() As Mensaje
        Dim Cats As Catalogos = Nothing

        Try
            msg = genW.initControles(Me).clonar()
            If msg.EsError Then GoTo finalize

        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la entidad: " + ex.Message)
        End Try

finalize:
        genW.publicar(New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, cliente.ParametrosConexion.BaseDeDatos, _
                                               "", "", "", ""), msg, True)

        Return msg
    End Function

    Public Function setConsultar() As Mensaje
        Try
            msg.reset()

            msg = genW.initControlesConsultar(Me).clonar()
            If msg.EsError Then GoTo finalize

            txtRutaArchivoFuente.Enabled = False
            cmbNombreHoja.Enabled = False
            cmdLeerHoja.Enabled = False

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dEmbarque, _
                                              cliente.ParametrosConexion.BaseDeDatos, "sOrdenes", _
                                              "", "", "")


            cmdAceptar.Text = "Ok"
            Modop = SysEnums.Modos.mConsultar

            modificado = False
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Consultar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Public Function setModificar() As Mensaje
        Try
            forzarBusqueda = False

            If Modop <> SysEnums.Modos.mBuscar Then modificado = True
            If Modop <> SysEnums.Modos.mConsultar Then GoTo finalize

            msg.reset()

            cmdAceptar.Text = "Importar"
            Modop = SysEnums.Modos.mModificar
        Catch ex As Exception
            msg.setError("No fue posible establecer el modo de Modificar: " + ex.Message)
        End Try

finalize:
        genW.publicar(infDoc, msg, True)
        If Not Modop = SysEnums.Modos.mBuscar Then forzarBusqueda = True

        Return msg
    End Function

    Private Function cargarInfoDocumento(ByVal pRutaArch As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing
        Dim itmCounter As Integer = 0

        Try
            msg.reset()

            gen3E = New Genericas3E()

            resultados = gen3E.tablasExcel(pRutaArch)

            cmbNombreHoja.Items.Clear()

            For itmCounter = 0 To resultados.Rows.Count - 1
                cmbNombreHoja.Items.Add(New SubItem(resultados.Rows(itmCounter).Item("TABLE_NAME"), _
                                   resultados.Rows(itmCounter).Item("TABLE_NAME")))
            Next

            If cmbNombreHoja.Items.Count > 0 Then
                txtRutaArchivoFuente.Text = pRutaArch
                cmbNombreHoja.SelectedIndex = 0

                cmbNombreHoja.Enabled = True
                cmdLeerHoja.Enabled = True
            Else
                cmbNombreHoja.Enabled = False
                cmdLeerHoja.Enabled = False
            End If

        Catch ex As Exception
            msg.setError("No fue posible cargar la información del archivo origen: " + ex.Message)

            cmbNombreHoja.Enabled = False
            cmdLeerHoja.Enabled = False
        End Try

        genW.publicar(infDoc, msg, True)
        Return msg
    End Function

    Private Function cargarInfoHoja() As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing
        Dim itmCounter As Integer = 0

        Try
            msg.reset()

            gen3E = New Genericas3E()

            resultados = gen3E.aTabla(txtRutaArchivoFuente.Text, cmbNombreHoja.SelectedItem.ItemData)

            Dim col As DataGridViewColumn = Nothing
            Dim reng As DataRow = Nothing

            dgvEmbEncontrados.DataSource = Nothing
            dgvEmbEncontrados.Rows.Clear()
            dgvEmbEncontrados.Columns.Clear()

            dgvEmbEncontrados.Font = New Font(dgvEmbEncontrados.Font.FontFamily.Name, 9, FontStyle.Regular)

            dgvEmbEncontrados.DataSource = resultados
            dgvEmbEncontrados.SelectionMode = DataGridViewSelectionMode.CellSelect
            dgvEmbEncontrados.AllowUserToDeleteRows = False
            dgvEmbEncontrados.AllowUserToOrderColumns = True
            dgvEmbEncontrados.AllowUserToAddRows = False
            dgvEmbEncontrados.AllowUserToResizeColumns = True
            dgvEmbEncontrados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            dgvEmbEncontrados.EditMode = DataGridViewEditMode.EditProgrammatically

            col = New DataGridViewColumn()
            col.Name = "Embarque"
            col.HeaderText = "Embarque"
            col.ValueType = GetType(String)
            col.CellTemplate = New DataGridViewTextBoxCell
            col.Width = 1000

            dgvEmbEncontrados.Columns.Add(col)

            col = New DataGridViewColumn()
            col.Name = "Leyenda"
            col.HeaderText = "Leyenda"
            col.ValueType = GetType(String)
            col.CellTemplate = New DataGridViewTextBoxCell
            col.Width = 1000

            dgvEmbEncontrados.Columns.Add(col)

            setModificar()
        Catch ex As Exception
            msg.setError("No fue posible cargar la información del archivo origen: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Function importarEmbarques() As Mensaje
        Dim Embarque As Embarque = Nothing
        Dim algunError As Boolean = False

        Dim itmCouter As Integer = 0
        Try
            msg.reset()

            If Not Usua.Perfil.Detalle.obtenerAtomo(26).Creacion Then
                msg.setError("No tiene los privilegios suficientes para realizar esta acción.")
                genW.publicar(infDoc, msg)
                GoTo finalize
            End If

            For itmCouter = 0 To dgvEmbEncontrados.RowCount - 1                
                If Not IsDBNull(dgvEmbEncontrados.Rows(itmCouter).Cells(1).Value) Then
                    If Not Embarque Is Nothing Then Embarque.liberarObjetos()
                    Embarque = New Embarque(cliente, "", dgvEmbEncontrados.Rows(itmCouter).Cells(0).Value,
                                            dgvEmbEncontrados.Rows(itmCouter).Cells(1).Value,
                                            dgvEmbEncontrados.Rows(itmCouter).Cells(2).Value, "",
                                            dgvEmbEncontrados.Rows(itmCouter).Cells(3).Value, "",
                                            dgvEmbEncontrados.Rows(itmCouter).Cells(4).Value,
                                            Format(Now.Date, "yyyy-MM-ddTHH:mm:dd"),
                                            dgvEmbEncontrados.Rows(itmCouter).Cells(5).Value,
                                        Format(Now.Date, "yyyy-MM-ddTHH:mm:dd"), 0,
                                        Decimal.Parse(dgvEmbEncontrados.Rows(itmCouter).Cells(4).Value) * -1, "",
                                        "", "", "", "", Usua.UsrId, Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"),
                                        Format(Now, "yyyy-MM-ddTHH:mm:dd"), "A", "",
                                        0, "", "", "", "", "",
                                        "", "", "", Path.GetFileNameWithoutExtension(txtRutaArchivoFuente.Text))

                    msg = Embarque.InspeccionTrigo.alimentar(0, "", "", "", "",
                                                       "", "", Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), True, "").clonar()

                    msg = Embarque.InspeccionTransporte.alimentar(0, "", "", "",
                                                            "", "", "", Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), True, "").clonar()

                    msg = Embarque.Laboratorio.alimentar(0, 0, 0, 0, 0, 0, 0, 0, "", "", Usua.UsrId, Format(Now, "yyyy-MM-ddTHH:mm:dd"), 0)

                    msg = Embarque.guardar().clonar()

                    dgvEmbEncontrados.Rows(itmCouter).Cells(7).Value = msg.Descripcion
                    If msg.EsError Then
                        dgvEmbEncontrados.Rows(itmCouter).Cells(6).Value = "<ERROR>"
                        dgvEmbEncontrados.Rows(itmCouter).Cells(6).Style.ForeColor = Color.Red

                        dgvEmbEncontrados.Rows(itmCouter).Cells(7).Style.ForeColor = Color.Red
                        algunError = True
                    Else
                        dgvEmbEncontrados.Rows(itmCouter).Cells(6).Value = Embarque.EmbId
                        dgvEmbEncontrados.Rows(itmCouter).Cells(6).Style.ForeColor = Color.DarkGreen

                        dgvEmbEncontrados.Rows(itmCouter).Cells(7).Style.ForeColor = Color.DarkBlue
                    End If

                    dgvEmbEncontrados.Refresh()

                End If
            Next

            If Not algunError Then
                setConsultar()
                msg.setInfo("Todas las operaciones de importación han sido realizadas con éxito.")
            Else
                msg.setAdvertencia("Ocurrió al menos un error de importación de Embarques. Revise el detalle de importación para mayor información.")
            End If

        Catch ex As Exception
            msg.setError("No fue posible generar el origen de datos: " + ex.Message)
        End Try

Finalize:
        genW.publicar(infDoc, msg)
        Return msg
    End Function

    Private Sub abrirOrden(ByVal pNoRenglon As Integer)
        Dim frmOrden As frmOrden = Nothing

        Try
            If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value Is Nothing Then
                If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value.ToString.Equals("") Then
                    frmOrden = New frmOrden(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua, _
                                                  dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value)
                    frmOrden.MdiParent = Me.MdiParent
                    frmOrden.Show()
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible abrir la Orden: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub abrirDestino(ByVal pNoRenglon As Integer)
        Dim frmDestino As frmDestino = Nothing

        Try
            If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value Is Nothing Then
                If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value.ToString.Equals("") Then
                    frmDestino = New frmDestino(cliente, genW, SysEnums.Modos.mConsultar, Usua, _
                                                  dgvEmbEncontrados.Rows(pNoRenglon).Cells(2).Value)
                    frmDestino.MdiParent = Me.MdiParent
                    frmDestino.Show()
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible abrir el Destino: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub abrirProvFlete(ByVal pNoRenglon As Integer)
        Dim frmProveedor As frmProveedor = Nothing

        Try
            If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value Is Nothing Then
                If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value.ToString.Equals("") Then
                    frmProveedor = New frmProveedor(cliente, genW, SysEnums.Modos.mConsultar, Usua, _
                                                  dgvEmbEncontrados.Rows(pNoRenglon).Cells(3).Value)
                    frmProveedor.MdiParent = Me.MdiParent
                    frmProveedor.Show()
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible abrir el Proveedor: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub
    Private Sub abrirUbicacionTmp(ByVal pNoRenglon As Integer)
        Dim frmUbicacion As frmUbicacionTmp = Nothing

        Try
            If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value Is Nothing Then
                If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(0).Value.ToString.Equals("") Then
                    frmUbicacion = New frmUbicacionTmp(cliente, genW, SysEnums.Modos.mConsultar, Usua, _
                                                  dgvEmbEncontrados.Rows(pNoRenglon).Cells(6).Value)
                    frmUbicacion.MdiParent = Me.MdiParent
                    frmUbicacion.Show()
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible abrir la ubicación Temporal: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub abrirEmbarque(ByVal pNoRenglon As Integer)
        Dim frmEmbarque As frmEmbarque = Nothing

        Try
            If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(8).Value Is Nothing Then
                If Not dgvEmbEncontrados.Rows(pNoRenglon).Cells(8).Value.ToString.Equals("<ERROR>") Then
                    frmEmbarque = New frmEmbarque(cliente, genW, SysEnums.Modos.mConsultar, Cnfg, Usua, _
                                                  dgvEmbEncontrados.Rows(pNoRenglon).Cells(8).Value)
                    frmEmbarque.MdiParent = Me.MdiParent
                    frmEmbarque.Show()
                End If
            End If
        Catch ex As Exception
            msg.setError("No fue posible abrir el Embarque: " + ex.Message)
        End Try

        genW.publicar(InfDoc, msg, True)
    End Sub
#End Region

    Private Sub cmdRutaArchivoFuente_Click(sender As Object, e As EventArgs) Handles cmdRutaArchivoFuente.Click
        Dim arch As String = genW.obtenerArchivo("xls (*.xls)|*.xls")

        If Not arch.Length.Equals(0) Then cargarInfoDocumento(arch)
    End Sub

    Private Sub cmdLeerHoja_Click(sender As Object, e As EventArgs) Handles cmdLeerHoja.Click
        cargarInfoHoja()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Select Case Modop
            Case SysEnums.Modos.mModificar
                importarEmbarques()
            Case SysEnums.Modos.mConsultar, SysEnums.Modos.mHistorial
                Me.Close()
        End Select
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmCargadorMasivoEmb_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Usua.CerrandoSesion Then
            If Not genW.continuarSinGuardar(infDoc, modificado) Then
                e.Cancel = True
            Else
                forzarBusqueda = False
            End If
        End If

    End Sub

    Private Sub dgvEmbEncontrados_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEmbEncontrados.CellMouseDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Select Case e.ColumnIndex
            Case 0
                abrirOrden(e.RowIndex)
            Case 2
                abrirDestino(e.RowIndex)
            Case 3
                abrirProvFlete(e.RowIndex)
            Case 8
                abrirEmbarque(e.RowIndex)
            Case 6
                abrirUbicacionTmp(e.RowIndex)
        End Select
    End Sub
End Class