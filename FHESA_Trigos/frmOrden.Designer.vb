<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrden
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrden))
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblFechaOrden = New System.Windows.Forms.Label()
        Me.dtpFechaOrden = New System.Windows.Forms.DateTimePicker()
        Me.txtOrdenId = New System.Windows.Forms.TextBox()
        Me.lblNoLote = New System.Windows.Forms.Label()
        Me.tbcOrdenes = New System.Windows.Forms.TabControl()
        Me.tbpGeneral = New System.Windows.Forms.TabPage()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtResponsable = New System.Windows.Forms.TextBox()
        Me.lblResponsable = New System.Windows.Forms.Label()
        Me.txtPrecioNeto = New System.Windows.Forms.TextBox()
        Me.lblPrecioNeto = New System.Windows.Forms.Label()
        Me.txtFutuMes = New System.Windows.Forms.TextBox()
        Me.lblMesFutu = New System.Windows.Forms.Label()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.lblBase = New System.Windows.Forms.Label()
        Me.txtRefftro = New System.Windows.Forms.TextBox()
        Me.lblRefftro = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.txtIncoterm = New System.Windows.Forms.TextBox()
        Me.lblIncoterm = New System.Windows.Forms.Label()
        Me.txtPeremb = New System.Windows.Forms.TextBox()
        Me.lblPeremb = New System.Windows.Forms.Label()
        Me.txtTolerancia = New System.Windows.Forms.TextBox()
        Me.lblTolerancia = New System.Windows.Forms.Label()
        Me.txtToneladas = New System.Windows.Forms.TextBox()
        Me.lblToneladas = New System.Windows.Forms.Label()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.cmdOrig = New System.Windows.Forms.Button()
        Me.lblOrigenId = New System.Windows.Forms.Label()
        Me.txtOrigenId = New System.Windows.Forms.TextBox()
        Me.cmdLote = New System.Windows.Forms.Button()
        Me.lblLoteId = New System.Windows.Forms.Label()
        Me.txtLoteId = New System.Windows.Forms.TextBox()
        Me.txtContrato = New System.Windows.Forms.TextBox()
        Me.lblContrato = New System.Windows.Forms.Label()
        Me.tbpFleteMarit = New System.Windows.Forms.TabPage()
        Me.txtRitmod = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRitmo = New System.Windows.Forms.TextBox()
        Me.lblRitmo = New System.Windows.Forms.Label()
        Me.txtTasaDmora = New System.Windows.Forms.TextBox()
        Me.lblTasaDmora = New System.Windows.Forms.Label()
        Me.txtCondPago = New System.Windows.Forms.TextBox()
        Me.lblCondPago = New System.Windows.Forms.Label()
        Me.txtNorDescarga = New System.Windows.Forms.TextBox()
        Me.lblNorDescarga = New System.Windows.Forms.Label()
        Me.txtNorCarga = New System.Windows.Forms.TextBox()
        Me.lblNorCarga = New System.Windows.Forms.Label()
        Me.txtPtoDescarga = New System.Windows.Forms.TextBox()
        Me.lblPtoDescarga = New System.Windows.Forms.Label()
        Me.txtPtoCarga = New System.Windows.Forms.TextBox()
        Me.lblPtoCarga = New System.Windows.Forms.Label()
        Me.txtLayTime = New System.Windows.Forms.TextBox()
        Me.lblLayTime = New System.Windows.Forms.Label()
        Me.txtLaycan = New System.Windows.Forms.TextBox()
        Me.lblLaycan = New System.Windows.Forms.Label()
        Me.cmdProvfl = New System.Windows.Forms.Button()
        Me.txtProveedorfl = New System.Windows.Forms.TextBox()
        Me.lblProvfl = New System.Windows.Forms.Label()
        Me.txtProvflId = New System.Windows.Forms.TextBox()
        Me.tbpAdjuntos = New System.Windows.Forms.TabPage()
        Me.dgvAdjuntos = New System.Windows.Forms.DataGridView()
        Me.colArchOrig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComentarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.tbcOrdenes.SuspendLayout()
        Me.tbpGeneral.SuspendLayout()
        Me.tbpFleteMarit.SuspendLayout()
        Me.tbpAdjuntos.SuspendLayout()
        CType(Me.dgvAdjuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(611, 24)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(614, 40)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(109, 21)
        Me.cmbEstado.TabIndex = 11
        '
        'lblFechaOrden
        '
        Me.lblFechaOrden.AutoSize = True
        Me.lblFechaOrden.Location = New System.Drawing.Point(16, 53)
        Me.lblFechaOrden.Name = "lblFechaOrden"
        Me.lblFechaOrden.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaOrden.TabIndex = 8
        Me.lblFechaOrden.Text = "Fecha"
        '
        'dtpFechaOrden
        '
        Me.dtpFechaOrden.Checked = False
        Me.dtpFechaOrden.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaOrden.Location = New System.Drawing.Point(59, 47)
        Me.dtpFechaOrden.Name = "dtpFechaOrden"
        Me.dtpFechaOrden.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaOrden.TabIndex = 9
        '
        'txtOrdenId
        '
        Me.txtOrdenId.AcceptsReturn = True
        Me.txtOrdenId.Location = New System.Drawing.Point(59, 21)
        Me.txtOrdenId.Multiline = True
        Me.txtOrdenId.Name = "txtOrdenId"
        Me.txtOrdenId.Size = New System.Drawing.Size(109, 20)
        Me.txtOrdenId.TabIndex = 7
        '
        'lblNoLote
        '
        Me.lblNoLote.AutoSize = True
        Me.lblNoLote.Location = New System.Drawing.Point(34, 24)
        Me.lblNoLote.Name = "lblNoLote"
        Me.lblNoLote.Size = New System.Drawing.Size(19, 13)
        Me.lblNoLote.TabIndex = 6
        Me.lblNoLote.Text = "Nº"
        '
        'tbcOrdenes
        '
        Me.tbcOrdenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcOrdenes.Controls.Add(Me.tbpGeneral)
        Me.tbcOrdenes.Controls.Add(Me.tbpFleteMarit)
        Me.tbcOrdenes.Controls.Add(Me.tbpAdjuntos)
        Me.tbcOrdenes.Location = New System.Drawing.Point(19, 86)
        Me.tbcOrdenes.Name = "tbcOrdenes"
        Me.tbcOrdenes.SelectedIndex = 0
        Me.tbcOrdenes.Size = New System.Drawing.Size(704, 352)
        Me.tbcOrdenes.TabIndex = 12
        '
        'tbpGeneral
        '
        Me.tbpGeneral.Controls.Add(Me.txtObservaciones)
        Me.tbpGeneral.Controls.Add(Me.lblObservaciones)
        Me.tbpGeneral.Controls.Add(Me.txtResponsable)
        Me.tbpGeneral.Controls.Add(Me.lblResponsable)
        Me.tbpGeneral.Controls.Add(Me.txtPrecioNeto)
        Me.tbpGeneral.Controls.Add(Me.lblPrecioNeto)
        Me.tbpGeneral.Controls.Add(Me.txtFutuMes)
        Me.tbpGeneral.Controls.Add(Me.lblMesFutu)
        Me.tbpGeneral.Controls.Add(Me.txtBase)
        Me.tbpGeneral.Controls.Add(Me.lblBase)
        Me.tbpGeneral.Controls.Add(Me.txtRefftro)
        Me.tbpGeneral.Controls.Add(Me.lblRefftro)
        Me.tbpGeneral.Controls.Add(Me.lblMoneda)
        Me.tbpGeneral.Controls.Add(Me.txtMoneda)
        Me.tbpGeneral.Controls.Add(Me.txtIncoterm)
        Me.tbpGeneral.Controls.Add(Me.lblIncoterm)
        Me.tbpGeneral.Controls.Add(Me.txtPeremb)
        Me.tbpGeneral.Controls.Add(Me.lblPeremb)
        Me.tbpGeneral.Controls.Add(Me.txtTolerancia)
        Me.tbpGeneral.Controls.Add(Me.lblTolerancia)
        Me.tbpGeneral.Controls.Add(Me.txtToneladas)
        Me.tbpGeneral.Controls.Add(Me.lblToneladas)
        Me.tbpGeneral.Controls.Add(Me.txtOrigen)
        Me.tbpGeneral.Controls.Add(Me.cmdOrig)
        Me.tbpGeneral.Controls.Add(Me.lblOrigenId)
        Me.tbpGeneral.Controls.Add(Me.txtOrigenId)
        Me.tbpGeneral.Controls.Add(Me.cmdLote)
        Me.tbpGeneral.Controls.Add(Me.lblLoteId)
        Me.tbpGeneral.Controls.Add(Me.txtLoteId)
        Me.tbpGeneral.Controls.Add(Me.txtContrato)
        Me.tbpGeneral.Controls.Add(Me.lblContrato)
        Me.tbpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbpGeneral.Name = "tbpGeneral"
        Me.tbpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpGeneral.Size = New System.Drawing.Size(696, 326)
        Me.tbpGeneral.TabIndex = 0
        Me.tbpGeneral.Text = "General"
        Me.tbpGeneral.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AcceptsReturn = True
        Me.txtObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(369, 181)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservaciones.Size = New System.Drawing.Size(309, 117)
        Me.txtObservaciones.TabIndex = 42
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(366, 165)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 41
        Me.lblObservaciones.Text = "Observaciones"
        '
        'txtResponsable
        '
        Me.txtResponsable.Location = New System.Drawing.Point(14, 278)
        Me.txtResponsable.Name = "txtResponsable"
        Me.txtResponsable.Size = New System.Drawing.Size(326, 20)
        Me.txtResponsable.TabIndex = 40
        '
        'lblResponsable
        '
        Me.lblResponsable.AutoSize = True
        Me.lblResponsable.Location = New System.Drawing.Point(11, 262)
        Me.lblResponsable.Name = "lblResponsable"
        Me.lblResponsable.Size = New System.Drawing.Size(69, 13)
        Me.lblResponsable.TabIndex = 39
        Me.lblResponsable.Text = "Responsable"
        '
        'txtPrecioNeto
        '
        Me.txtPrecioNeto.Location = New System.Drawing.Point(184, 230)
        Me.txtPrecioNeto.Name = "txtPrecioNeto"
        Me.txtPrecioNeto.Size = New System.Drawing.Size(156, 20)
        Me.txtPrecioNeto.TabIndex = 38
        '
        'lblPrecioNeto
        '
        Me.lblPrecioNeto.AutoSize = True
        Me.lblPrecioNeto.Location = New System.Drawing.Point(181, 214)
        Me.lblPrecioNeto.Name = "lblPrecioNeto"
        Me.lblPrecioNeto.Size = New System.Drawing.Size(61, 13)
        Me.lblPrecioNeto.TabIndex = 37
        Me.lblPrecioNeto.Text = "Precio neto"
        '
        'txtFutuMes
        '
        Me.txtFutuMes.Location = New System.Drawing.Point(14, 230)
        Me.txtFutuMes.Name = "txtFutuMes"
        Me.txtFutuMes.Size = New System.Drawing.Size(156, 20)
        Me.txtFutuMes.TabIndex = 34
        '
        'lblMesFutu
        '
        Me.lblMesFutu.AutoSize = True
        Me.lblMesFutu.Location = New System.Drawing.Point(11, 214)
        Me.lblMesFutu.Name = "lblMesFutu"
        Me.lblMesFutu.Size = New System.Drawing.Size(81, 13)
        Me.lblMesFutu.TabIndex = 33
        Me.lblMesFutu.Text = "Valor del Futuro"
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(184, 181)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(156, 20)
        Me.txtBase.TabIndex = 32
        '
        'lblBase
        '
        Me.lblBase.AutoSize = True
        Me.lblBase.Location = New System.Drawing.Point(181, 165)
        Me.lblBase.Name = "lblBase"
        Me.lblBase.Size = New System.Drawing.Size(31, 13)
        Me.lblBase.TabIndex = 31
        Me.lblBase.Text = "Base"
        '
        'txtRefftro
        '
        Me.txtRefftro.Location = New System.Drawing.Point(14, 181)
        Me.txtRefftro.Name = "txtRefftro"
        Me.txtRefftro.Size = New System.Drawing.Size(156, 20)
        Me.txtRefftro.TabIndex = 30
        '
        'lblRefftro
        '
        Me.lblRefftro.AutoSize = True
        Me.lblRefftro.Location = New System.Drawing.Point(11, 165)
        Me.lblRefftro.Name = "lblRefftro"
        Me.lblRefftro.Size = New System.Drawing.Size(89, 13)
        Me.lblRefftro.TabIndex = 29
        Me.lblRefftro.Text = "Referencia futuro"
        '
        'lblMoneda
        '
        Me.lblMoneda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.Location = New System.Drawing.Point(366, 117)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 27
        Me.lblMoneda.Text = "Moneda"
        '
        'txtMoneda
        '
        Me.txtMoneda.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMoneda.Location = New System.Drawing.Point(369, 133)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(129, 20)
        Me.txtMoneda.TabIndex = 28
        '
        'txtIncoterm
        '
        Me.txtIncoterm.Location = New System.Drawing.Point(14, 133)
        Me.txtIncoterm.Name = "txtIncoterm"
        Me.txtIncoterm.Size = New System.Drawing.Size(326, 20)
        Me.txtIncoterm.TabIndex = 24
        '
        'lblIncoterm
        '
        Me.lblIncoterm.AutoSize = True
        Me.lblIncoterm.Location = New System.Drawing.Point(11, 117)
        Me.lblIncoterm.Name = "lblIncoterm"
        Me.lblIncoterm.Size = New System.Drawing.Size(48, 13)
        Me.lblIncoterm.TabIndex = 23
        Me.lblIncoterm.Text = "Incoterm"
        '
        'txtPeremb
        '
        Me.txtPeremb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPeremb.Location = New System.Drawing.Point(369, 82)
        Me.txtPeremb.Name = "txtPeremb"
        Me.txtPeremb.Size = New System.Drawing.Size(309, 20)
        Me.txtPeremb.TabIndex = 22
        '
        'lblPeremb
        '
        Me.lblPeremb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPeremb.AutoSize = True
        Me.lblPeremb.Location = New System.Drawing.Point(366, 66)
        Me.lblPeremb.Name = "lblPeremb"
        Me.lblPeremb.Size = New System.Drawing.Size(115, 13)
        Me.lblPeremb.TabIndex = 21
        Me.lblPeremb.Text = "Período de embarques"
        '
        'txtTolerancia
        '
        Me.txtTolerancia.Location = New System.Drawing.Point(194, 82)
        Me.txtTolerancia.Name = "txtTolerancia"
        Me.txtTolerancia.Size = New System.Drawing.Size(146, 20)
        Me.txtTolerancia.TabIndex = 20
        '
        'lblTolerancia
        '
        Me.lblTolerancia.AutoSize = True
        Me.lblTolerancia.Location = New System.Drawing.Point(191, 66)
        Me.lblTolerancia.Name = "lblTolerancia"
        Me.lblTolerancia.Size = New System.Drawing.Size(57, 13)
        Me.lblTolerancia.TabIndex = 19
        Me.lblTolerancia.Text = "Tolerancia"
        '
        'txtToneladas
        '
        Me.txtToneladas.Location = New System.Drawing.Point(14, 82)
        Me.txtToneladas.Name = "txtToneladas"
        Me.txtToneladas.Size = New System.Drawing.Size(156, 20)
        Me.txtToneladas.TabIndex = 18
        '
        'lblToneladas
        '
        Me.lblToneladas.AutoSize = True
        Me.lblToneladas.Location = New System.Drawing.Point(11, 66)
        Me.lblToneladas.Name = "lblToneladas"
        Me.lblToneladas.Size = New System.Drawing.Size(57, 13)
        Me.lblToneladas.TabIndex = 17
        Me.lblToneladas.Text = "Toneladas"
        '
        'txtOrigen
        '
        Me.txtOrigen.AcceptsReturn = True
        Me.txtOrigen.AcceptsTab = True
        Me.txtOrigen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOrigen.Location = New System.Drawing.Point(398, 30)
        Me.txtOrigen.Multiline = True
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(280, 20)
        Me.txtOrigen.TabIndex = 16
        '
        'cmdOrig
        '
        Me.cmdOrig.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdOrig.FlatAppearance.BorderSize = 0
        Me.cmdOrig.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOrig.Location = New System.Drawing.Point(369, 27)
        Me.cmdOrig.Name = "cmdOrig"
        Me.cmdOrig.Size = New System.Drawing.Size(23, 23)
        Me.cmdOrig.TabIndex = 14
        Me.cmdOrig.Text = ">>"
        Me.cmdOrig.UseVisualStyleBackColor = True
        '
        'lblOrigenId
        '
        Me.lblOrigenId.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrigenId.AutoSize = True
        Me.lblOrigenId.Location = New System.Drawing.Point(399, 14)
        Me.lblOrigenId.Name = "lblOrigenId"
        Me.lblOrigenId.Size = New System.Drawing.Size(38, 13)
        Me.lblOrigenId.TabIndex = 13
        Me.lblOrigenId.Text = "Origen"
        '
        'txtOrigenId
        '
        Me.txtOrigenId.AcceptsReturn = True
        Me.txtOrigenId.AcceptsTab = True
        Me.txtOrigenId.Location = New System.Drawing.Point(398, 30)
        Me.txtOrigenId.Multiline = True
        Me.txtOrigenId.Name = "txtOrigenId"
        Me.txtOrigenId.Size = New System.Drawing.Size(100, 20)
        Me.txtOrigenId.TabIndex = 15
        Me.txtOrigenId.Visible = False
        '
        'cmdLote
        '
        Me.cmdLote.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdLote.FlatAppearance.BorderSize = 0
        Me.cmdLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLote.Location = New System.Drawing.Point(190, 27)
        Me.cmdLote.Name = "cmdLote"
        Me.cmdLote.Size = New System.Drawing.Size(23, 23)
        Me.cmdLote.TabIndex = 11
        Me.cmdLote.Text = ">>"
        Me.cmdLote.UseVisualStyleBackColor = True
        '
        'lblLoteId
        '
        Me.lblLoteId.AutoSize = True
        Me.lblLoteId.Location = New System.Drawing.Point(220, 14)
        Me.lblLoteId.Name = "lblLoteId"
        Me.lblLoteId.Size = New System.Drawing.Size(28, 13)
        Me.lblLoteId.TabIndex = 10
        Me.lblLoteId.Text = "Lote"
        '
        'txtLoteId
        '
        Me.txtLoteId.AcceptsReturn = True
        Me.txtLoteId.AcceptsTab = True
        Me.txtLoteId.Location = New System.Drawing.Point(219, 30)
        Me.txtLoteId.Multiline = True
        Me.txtLoteId.Name = "txtLoteId"
        Me.txtLoteId.Size = New System.Drawing.Size(121, 20)
        Me.txtLoteId.TabIndex = 12
        '
        'txtContrato
        '
        Me.txtContrato.Location = New System.Drawing.Point(14, 30)
        Me.txtContrato.Name = "txtContrato"
        Me.txtContrato.Size = New System.Drawing.Size(156, 20)
        Me.txtContrato.TabIndex = 1
        '
        'lblContrato
        '
        Me.lblContrato.AutoSize = True
        Me.lblContrato.Location = New System.Drawing.Point(11, 14)
        Me.lblContrato.Name = "lblContrato"
        Me.lblContrato.Size = New System.Drawing.Size(47, 13)
        Me.lblContrato.TabIndex = 0
        Me.lblContrato.Text = "Contrato"
        '
        'tbpFleteMarit
        '
        Me.tbpFleteMarit.Controls.Add(Me.txtRitmod)
        Me.tbpFleteMarit.Controls.Add(Me.Label1)
        Me.tbpFleteMarit.Controls.Add(Me.txtRitmo)
        Me.tbpFleteMarit.Controls.Add(Me.lblRitmo)
        Me.tbpFleteMarit.Controls.Add(Me.txtTasaDmora)
        Me.tbpFleteMarit.Controls.Add(Me.lblTasaDmora)
        Me.tbpFleteMarit.Controls.Add(Me.txtCondPago)
        Me.tbpFleteMarit.Controls.Add(Me.lblCondPago)
        Me.tbpFleteMarit.Controls.Add(Me.txtNorDescarga)
        Me.tbpFleteMarit.Controls.Add(Me.lblNorDescarga)
        Me.tbpFleteMarit.Controls.Add(Me.txtNorCarga)
        Me.tbpFleteMarit.Controls.Add(Me.lblNorCarga)
        Me.tbpFleteMarit.Controls.Add(Me.txtPtoDescarga)
        Me.tbpFleteMarit.Controls.Add(Me.lblPtoDescarga)
        Me.tbpFleteMarit.Controls.Add(Me.txtPtoCarga)
        Me.tbpFleteMarit.Controls.Add(Me.lblPtoCarga)
        Me.tbpFleteMarit.Controls.Add(Me.txtLayTime)
        Me.tbpFleteMarit.Controls.Add(Me.lblLayTime)
        Me.tbpFleteMarit.Controls.Add(Me.txtLaycan)
        Me.tbpFleteMarit.Controls.Add(Me.lblLaycan)
        Me.tbpFleteMarit.Controls.Add(Me.cmdProvfl)
        Me.tbpFleteMarit.Controls.Add(Me.txtProveedorfl)
        Me.tbpFleteMarit.Controls.Add(Me.lblProvfl)
        Me.tbpFleteMarit.Controls.Add(Me.txtProvflId)
        Me.tbpFleteMarit.Location = New System.Drawing.Point(4, 22)
        Me.tbpFleteMarit.Name = "tbpFleteMarit"
        Me.tbpFleteMarit.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFleteMarit.Size = New System.Drawing.Size(696, 326)
        Me.tbpFleteMarit.TabIndex = 1
        Me.tbpFleteMarit.Text = "Flete marítimo"
        Me.tbpFleteMarit.UseVisualStyleBackColor = True
        '
        'txtRitmod
        '
        Me.txtRitmod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRitmod.Location = New System.Drawing.Point(356, 180)
        Me.txtRitmod.Name = "txtRitmod"
        Me.txtRitmod.Size = New System.Drawing.Size(322, 20)
        Me.txtRitmod.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(353, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Ritmo Descarga"
        '
        'txtRitmo
        '
        Me.txtRitmo.Location = New System.Drawing.Point(15, 180)
        Me.txtRitmo.Name = "txtRitmo"
        Me.txtRitmo.Size = New System.Drawing.Size(322, 20)
        Me.txtRitmo.TabIndex = 27
        '
        'lblRitmo
        '
        Me.lblRitmo.AutoSize = True
        Me.lblRitmo.Location = New System.Drawing.Point(12, 164)
        Me.lblRitmo.Name = "lblRitmo"
        Me.lblRitmo.Size = New System.Drawing.Size(65, 13)
        Me.lblRitmo.TabIndex = 26
        Me.lblRitmo.Text = "Ritmo Carga"
        '
        'txtTasaDmora
        '
        Me.txtTasaDmora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTasaDmora.Location = New System.Drawing.Point(356, 276)
        Me.txtTasaDmora.Name = "txtTasaDmora"
        Me.txtTasaDmora.Size = New System.Drawing.Size(322, 20)
        Me.txtTasaDmora.TabIndex = 37
        '
        'lblTasaDmora
        '
        Me.lblTasaDmora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTasaDmora.AutoSize = True
        Me.lblTasaDmora.Location = New System.Drawing.Point(353, 260)
        Me.lblTasaDmora.Name = "lblTasaDmora"
        Me.lblTasaDmora.Size = New System.Drawing.Size(86, 13)
        Me.lblTasaDmora.TabIndex = 36
        Me.lblTasaDmora.Text = "Tasa de Demora"
        '
        'txtCondPago
        '
        Me.txtCondPago.Location = New System.Drawing.Point(14, 276)
        Me.txtCondPago.Name = "txtCondPago"
        Me.txtCondPago.Size = New System.Drawing.Size(322, 20)
        Me.txtCondPago.TabIndex = 35
        '
        'lblCondPago
        '
        Me.lblCondPago.AutoSize = True
        Me.lblCondPago.Location = New System.Drawing.Point(11, 260)
        Me.lblCondPago.Name = "lblCondPago"
        Me.lblCondPago.Size = New System.Drawing.Size(37, 13)
        Me.lblCondPago.TabIndex = 34
        Me.lblCondPago.Text = "Precio"
        '
        'txtNorDescarga
        '
        Me.txtNorDescarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNorDescarga.Location = New System.Drawing.Point(356, 225)
        Me.txtNorDescarga.Name = "txtNorDescarga"
        Me.txtNorDescarga.Size = New System.Drawing.Size(322, 20)
        Me.txtNorDescarga.TabIndex = 33
        '
        'lblNorDescarga
        '
        Me.lblNorDescarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNorDescarga.AutoSize = True
        Me.lblNorDescarga.Location = New System.Drawing.Point(353, 209)
        Me.lblNorDescarga.Name = "lblNorDescarga"
        Me.lblNorDescarga.Size = New System.Drawing.Size(80, 13)
        Me.lblNorDescarga.TabIndex = 32
        Me.lblNorDescarga.Text = "NOR Descarga"
        '
        'txtNorCarga
        '
        Me.txtNorCarga.Location = New System.Drawing.Point(15, 225)
        Me.txtNorCarga.Name = "txtNorCarga"
        Me.txtNorCarga.Size = New System.Drawing.Size(322, 20)
        Me.txtNorCarga.TabIndex = 31
        '
        'lblNorCarga
        '
        Me.lblNorCarga.AutoSize = True
        Me.lblNorCarga.Location = New System.Drawing.Point(12, 209)
        Me.lblNorCarga.Name = "lblNorCarga"
        Me.lblNorCarga.Size = New System.Drawing.Size(62, 13)
        Me.lblNorCarga.TabIndex = 30
        Me.lblNorCarga.Text = "NOR Carga"
        '
        'txtPtoDescarga
        '
        Me.txtPtoDescarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPtoDescarga.Location = New System.Drawing.Point(356, 132)
        Me.txtPtoDescarga.Name = "txtPtoDescarga"
        Me.txtPtoDescarga.Size = New System.Drawing.Size(322, 20)
        Me.txtPtoDescarga.TabIndex = 25
        '
        'lblPtoDescarga
        '
        Me.lblPtoDescarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPtoDescarga.AutoSize = True
        Me.lblPtoDescarga.Location = New System.Drawing.Point(353, 116)
        Me.lblPtoDescarga.Name = "lblPtoDescarga"
        Me.lblPtoDescarga.Size = New System.Drawing.Size(87, 13)
        Me.lblPtoDescarga.TabIndex = 24
        Me.lblPtoDescarga.Text = "Puerto Descarga"
        '
        'txtPtoCarga
        '
        Me.txtPtoCarga.Location = New System.Drawing.Point(15, 132)
        Me.txtPtoCarga.Name = "txtPtoCarga"
        Me.txtPtoCarga.Size = New System.Drawing.Size(322, 20)
        Me.txtPtoCarga.TabIndex = 23
        '
        'lblPtoCarga
        '
        Me.lblPtoCarga.AutoSize = True
        Me.lblPtoCarga.Location = New System.Drawing.Point(12, 116)
        Me.lblPtoCarga.Name = "lblPtoCarga"
        Me.lblPtoCarga.Size = New System.Drawing.Size(69, 13)
        Me.lblPtoCarga.TabIndex = 22
        Me.lblPtoCarga.Text = "Puerto Carga"
        '
        'txtLayTime
        '
        Me.txtLayTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLayTime.Location = New System.Drawing.Point(356, 82)
        Me.txtLayTime.Name = "txtLayTime"
        Me.txtLayTime.Size = New System.Drawing.Size(323, 20)
        Me.txtLayTime.TabIndex = 21
        '
        'lblLayTime
        '
        Me.lblLayTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLayTime.AutoSize = True
        Me.lblLayTime.Location = New System.Drawing.Point(353, 66)
        Me.lblLayTime.Name = "lblLayTime"
        Me.lblLayTime.Size = New System.Drawing.Size(83, 13)
        Me.lblLayTime.TabIndex = 20
        Me.lblLayTime.Text = "Tarifa Descarga"
        '
        'txtLaycan
        '
        Me.txtLaycan.Location = New System.Drawing.Point(15, 82)
        Me.txtLaycan.Name = "txtLaycan"
        Me.txtLaycan.Size = New System.Drawing.Size(322, 20)
        Me.txtLaycan.TabIndex = 19
        '
        'lblLaycan
        '
        Me.lblLaycan.AutoSize = True
        Me.lblLaycan.Location = New System.Drawing.Point(12, 66)
        Me.lblLaycan.Name = "lblLaycan"
        Me.lblLaycan.Size = New System.Drawing.Size(91, 13)
        Me.lblLaycan.TabIndex = 18
        Me.lblLaycan.Text = "LAYCAN-Plancha"
        '
        'cmdProvfl
        '
        Me.cmdProvfl.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdProvfl.FlatAppearance.BorderSize = 0
        Me.cmdProvfl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProvfl.Location = New System.Drawing.Point(15, 25)
        Me.cmdProvfl.Name = "cmdProvfl"
        Me.cmdProvfl.Size = New System.Drawing.Size(23, 23)
        Me.cmdProvfl.TabIndex = 15
        Me.cmdProvfl.Text = ">>"
        Me.cmdProvfl.UseVisualStyleBackColor = True
        '
        'txtProveedorfl
        '
        Me.txtProveedorfl.AcceptsTab = True
        Me.txtProveedorfl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProveedorfl.Location = New System.Drawing.Point(44, 28)
        Me.txtProveedorfl.Multiline = True
        Me.txtProveedorfl.Name = "txtProveedorfl"
        Me.txtProveedorfl.Size = New System.Drawing.Size(635, 20)
        Me.txtProveedorfl.TabIndex = 17
        '
        'lblProvfl
        '
        Me.lblProvfl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProvfl.AutoSize = True
        Me.lblProvfl.Location = New System.Drawing.Point(45, 12)
        Me.lblProvfl.Name = "lblProvfl"
        Me.lblProvfl.Size = New System.Drawing.Size(56, 13)
        Me.lblProvfl.TabIndex = 14
        Me.lblProvfl.Text = "Proveedor"
        '
        'txtProvflId
        '
        Me.txtProvflId.AcceptsReturn = True
        Me.txtProvflId.AcceptsTab = True
        Me.txtProvflId.Location = New System.Drawing.Point(44, 28)
        Me.txtProvflId.Multiline = True
        Me.txtProvflId.Name = "txtProvflId"
        Me.txtProvflId.Size = New System.Drawing.Size(100, 20)
        Me.txtProvflId.TabIndex = 16
        Me.txtProvflId.Visible = False
        '
        'tbpAdjuntos
        '
        Me.tbpAdjuntos.Controls.Add(Me.dgvAdjuntos)
        Me.tbpAdjuntos.Location = New System.Drawing.Point(4, 22)
        Me.tbpAdjuntos.Name = "tbpAdjuntos"
        Me.tbpAdjuntos.Size = New System.Drawing.Size(696, 326)
        Me.tbpAdjuntos.TabIndex = 2
        Me.tbpAdjuntos.Text = "Archivos Adjuntos"
        Me.tbpAdjuntos.UseVisualStyleBackColor = True
        '
        'dgvAdjuntos
        '
        Me.dgvAdjuntos.AllowUserToAddRows = False
        Me.dgvAdjuntos.AllowUserToDeleteRows = False
        Me.dgvAdjuntos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAdjuntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdjuntos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colArchOrig, Me.colRuta, Me.colExtension, Me.colComentarios})
        Me.dgvAdjuntos.Location = New System.Drawing.Point(3, 3)
        Me.dgvAdjuntos.Name = "dgvAdjuntos"
        Me.dgvAdjuntos.Size = New System.Drawing.Size(690, 320)
        Me.dgvAdjuntos.TabIndex = 0
        '
        'colArchOrig
        '
        Me.colArchOrig.HeaderText = "Archivo Original"
        Me.colArchOrig.Name = "colArchOrig"
        Me.colArchOrig.ReadOnly = True
        Me.colArchOrig.Visible = False
        '
        'colRuta
        '
        Me.colRuta.HeaderText = "Ruta del Archivo"
        Me.colRuta.Name = "colRuta"
        Me.colRuta.ReadOnly = True
        Me.colRuta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRuta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colRuta.Width = 250
        '
        'colExtension
        '
        Me.colExtension.HeaderText = "Extensión"
        Me.colExtension.Name = "colExtension"
        Me.colExtension.ReadOnly = True
        Me.colExtension.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colExtension.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colExtension.Width = 60
        '
        'colComentarios
        '
        Me.colComentarios.HeaderText = "Comentarios"
        Me.colComentarios.Name = "colComentarios"
        Me.colComentarios.Width = 1000
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(103, 456)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 40
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(18, 456)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 39
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmOrden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 500)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.tbcOrdenes)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.lblFechaOrden)
        Me.Controls.Add(Me.dtpFechaOrden)
        Me.Controls.Add(Me.txtOrdenId)
        Me.Controls.Add(Me.lblNoLote)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrden"
        Me.Text = "Orden"
        Me.tbcOrdenes.ResumeLayout(False)
        Me.tbpGeneral.ResumeLayout(False)
        Me.tbpGeneral.PerformLayout()
        Me.tbpFleteMarit.ResumeLayout(False)
        Me.tbpFleteMarit.PerformLayout()
        Me.tbpAdjuntos.ResumeLayout(False)
        CType(Me.dgvAdjuntos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaOrden As System.Windows.Forms.Label
    Friend WithEvents dtpFechaOrden As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtOrdenId As System.Windows.Forms.TextBox
    Friend WithEvents lblNoLote As System.Windows.Forms.Label
    Friend WithEvents tbcOrdenes As System.Windows.Forms.TabControl
    Friend WithEvents tbpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbpFleteMarit As System.Windows.Forms.TabPage
    Friend WithEvents txtContrato As System.Windows.Forms.TextBox
    Friend WithEvents lblContrato As System.Windows.Forms.Label
    Friend WithEvents cmdLote As System.Windows.Forms.Button
    Friend WithEvents lblLoteId As System.Windows.Forms.Label
    Friend WithEvents txtLoteId As System.Windows.Forms.TextBox
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents cmdOrig As System.Windows.Forms.Button
    Friend WithEvents lblOrigenId As System.Windows.Forms.Label
    Friend WithEvents txtOrigenId As System.Windows.Forms.TextBox
    Friend WithEvents txtRefftro As System.Windows.Forms.TextBox
    Friend WithEvents lblRefftro As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtIncoterm As System.Windows.Forms.TextBox
    Friend WithEvents lblIncoterm As System.Windows.Forms.Label
    Friend WithEvents txtPeremb As System.Windows.Forms.TextBox
    Friend WithEvents lblPeremb As System.Windows.Forms.Label
    Friend WithEvents txtTolerancia As System.Windows.Forms.TextBox
    Friend WithEvents lblTolerancia As System.Windows.Forms.Label
    Friend WithEvents txtToneladas As System.Windows.Forms.TextBox
    Friend WithEvents lblToneladas As System.Windows.Forms.Label
    Friend WithEvents txtFutuMes As System.Windows.Forms.TextBox
    Friend WithEvents lblMesFutu As System.Windows.Forms.Label
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents lblBase As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtResponsable As System.Windows.Forms.TextBox
    Friend WithEvents lblResponsable As System.Windows.Forms.Label
    Friend WithEvents txtPrecioNeto As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecioNeto As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdProvfl As System.Windows.Forms.Button
    Friend WithEvents txtProveedorfl As System.Windows.Forms.TextBox
    Friend WithEvents lblProvfl As System.Windows.Forms.Label
    Friend WithEvents txtProvflId As System.Windows.Forms.TextBox
    Friend WithEvents txtLayTime As System.Windows.Forms.TextBox
    Friend WithEvents lblLayTime As System.Windows.Forms.Label
    Friend WithEvents txtLaycan As System.Windows.Forms.TextBox
    Friend WithEvents lblLaycan As System.Windows.Forms.Label
    Friend WithEvents txtPtoCarga As System.Windows.Forms.TextBox
    Friend WithEvents lblPtoCarga As System.Windows.Forms.Label
    Friend WithEvents txtPtoDescarga As System.Windows.Forms.TextBox
    Friend WithEvents lblPtoDescarga As System.Windows.Forms.Label
    Friend WithEvents txtTasaDmora As System.Windows.Forms.TextBox
    Friend WithEvents lblTasaDmora As System.Windows.Forms.Label
    Friend WithEvents txtCondPago As System.Windows.Forms.TextBox
    Friend WithEvents lblCondPago As System.Windows.Forms.Label
    Friend WithEvents txtNorDescarga As System.Windows.Forms.TextBox
    Friend WithEvents lblNorDescarga As System.Windows.Forms.Label
    Friend WithEvents txtNorCarga As System.Windows.Forms.TextBox
    Friend WithEvents lblNorCarga As System.Windows.Forms.Label
    Friend WithEvents txtRitmo As System.Windows.Forms.TextBox
    Friend WithEvents lblRitmo As System.Windows.Forms.Label
    Friend WithEvents txtRitmod As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbpAdjuntos As System.Windows.Forms.TabPage
    Friend WithEvents dgvAdjuntos As System.Windows.Forms.DataGridView
    Friend WithEvents colArchOrig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtension As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComentarios As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
