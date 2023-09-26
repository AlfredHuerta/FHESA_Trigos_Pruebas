<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmbarque
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmbarque))
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtEmbId = New System.Windows.Forms.TextBox()
        Me.lblEmbId = New System.Windows.Forms.Label()
        Me.tbcEmbarques = New System.Windows.Forms.TabControl()
        Me.tbpEmbarque = New System.Windows.Forms.TabPage()
        Me.txtTarifa = New System.Windows.Forms.TextBox()
        Me.lblTarifa = New System.Windows.Forms.Label()
        Me.cmbMonedaId = New System.Windows.Forms.ComboBox()
        Me.lblMonedaId = New System.Windows.Forms.Label()
        Me.lblObgen = New System.Windows.Forms.Label()
        Me.txtObgen = New System.Windows.Forms.TextBox()
        Me.txtSelloe = New System.Windows.Forms.TextBox()
        Me.lblSelloe = New System.Windows.Forms.Label()
        Me.txtFactfl = New System.Windows.Forms.TextBox()
        Me.lblFactfl = New System.Windows.Forms.Label()
        Me.txtPesoEmb = New System.Windows.Forms.TextBox()
        Me.lblPesoEmb = New System.Windows.Forms.Label()
        Me.txtProvFlete = New System.Windows.Forms.TextBox()
        Me.cmdProvFlete = New System.Windows.Forms.Button()
        Me.lblProvFleteId = New System.Windows.Forms.Label()
        Me.txtProvFleteId = New System.Windows.Forms.TextBox()
        Me.txtOrigen = New System.Windows.Forms.TextBox()
        Me.cmdOrigen = New System.Windows.Forms.Button()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.txtOrigenId = New System.Windows.Forms.TextBox()
        Me.txtProvTrigo = New System.Windows.Forms.TextBox()
        Me.cmdProvTrigo = New System.Windows.Forms.Button()
        Me.lblProvTrigoId = New System.Windows.Forms.Label()
        Me.txtProvTrigoId = New System.Windows.Forms.TextBox()
        Me.txtTrigo = New System.Windows.Forms.TextBox()
        Me.cmdTrigo = New System.Windows.Forms.Button()
        Me.lblTrigoId = New System.Windows.Forms.Label()
        Me.txtTrigoId = New System.Windows.Forms.TextBox()
        Me.cmbLote = New System.Windows.Forms.Button()
        Me.lblLoteId = New System.Windows.Forms.Label()
        Me.txtLoteId = New System.Windows.Forms.TextBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.lblFechaOrden = New System.Windows.Forms.Label()
        Me.dtpFechaEmbarque = New System.Windows.Forms.DateTimePicker()
        Me.cmdDstino = New System.Windows.Forms.Button()
        Me.lblDstinoId = New System.Windows.Forms.Label()
        Me.txtDstinoId = New System.Windows.Forms.TextBox()
        Me.txtReftrans = New System.Windows.Forms.TextBox()
        Me.lblReftrans = New System.Windows.Forms.Label()
        Me.cmdOrden = New System.Windows.Forms.Button()
        Me.lblOrdenId = New System.Windows.Forms.Label()
        Me.txtOrdenId = New System.Windows.Forms.TextBox()
        Me.tbpRecepcion = New System.Windows.Forms.TabPage()
        Me.txtPesoembc = New System.Windows.Forms.TextBox()
        Me.lblPesoembc = New System.Windows.Forms.Label()
        Me.lblInformacionEmbarque = New System.Windows.Forms.Label()
        Me.lstSilos = New System.Windows.Forms.CheckedListBox()
        Me.lblAlertaDif = New System.Windows.Forms.Label()
        Me.txtSelloRecep = New System.Windows.Forms.TextBox()
        Me.lblSelloRecep = New System.Windows.Forms.Label()
        Me.lblSilos = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.cmdOperador = New System.Windows.Forms.Button()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.txtOperadorId = New System.Windows.Forms.TextBox()
        Me.txtDiferencia = New System.Windows.Forms.TextBox()
        Me.lblDif = New System.Windows.Forms.Label()
        Me.txtPesoRecibido = New System.Windows.Forms.TextBox()
        Me.lblPesoRecibido = New System.Windows.Forms.Label()
        Me.lblFchrec = New System.Windows.Forms.Label()
        Me.dtpFchrec = New System.Windows.Forms.DateTimePicker()
        Me.tbpInspeccionTrigo = New System.Windows.Forms.TabPage()
        Me.txtObservacionestri = New System.Windows.Forms.TextBox()
        Me.lblObservacionestri = New System.Windows.Forms.Label()
        Me.chkConformetri = New System.Windows.Forms.CheckBox()
        Me.txtOtrost = New System.Windows.Forms.TextBox()
        Me.lblOtrost = New System.Windows.Forms.Label()
        Me.txtPlagas = New System.Windows.Forms.TextBox()
        Me.lblPlagas = New System.Windows.Forms.Label()
        Me.txtDaniado = New System.Windows.Forms.TextBox()
        Me.lblDaniado = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtOlor = New System.Windows.Forms.TextBox()
        Me.lblOlor = New System.Windows.Forms.Label()
        Me.chkCondLimpieza = New System.Windows.Forms.CheckBox()
        Me.tbpInspeccionTransporte = New System.Windows.Forms.TabPage()
        Me.txtObservacionestra = New System.Windows.Forms.TextBox()
        Me.lblObservacionestra = New System.Windows.Forms.Label()
        Me.chkConformetra = New System.Windows.Forms.CheckBox()
        Me.txtServtra = New System.Windows.Forms.TextBox()
        Me.lblServtra = New System.Windows.Forms.Label()
        Me.txtSellosc = New System.Windows.Forms.TextBox()
        Me.lblSellosc = New System.Windows.Forms.Label()
        Me.txtOtrosp = New System.Windows.Forms.TextBox()
        Me.lblOtrosp = New System.Windows.Forms.Label()
        Me.txtLibregra = New System.Windows.Forms.TextBox()
        Me.lblLibregra = New System.Windows.Forms.Label()
        Me.txtLibreba = New System.Windows.Forms.TextBox()
        Me.lblLibreba = New System.Windows.Forms.Label()
        Me.chkCondTransporte = New System.Windows.Forms.CheckBox()
        Me.tbpLaboratorio = New System.Windows.Forms.TabPage()
        Me.txtObslab = New System.Windows.Forms.TextBox()
        Me.lblObslab = New System.Windows.Forms.Label()
        Me.txtImpurezar = New System.Windows.Forms.TextBox()
        Me.lblImpurezar = New System.Windows.Forms.Label()
        Me.txtPhectolitror = New System.Windows.Forms.TextBox()
        Me.lblPhectolitror = New System.Windows.Forms.Label()
        Me.txtHumedadr = New System.Windows.Forms.TextBox()
        Me.lblHumedadr = New System.Windows.Forms.Label()
        Me.txtProteinar = New System.Windows.Forms.TextBox()
        Me.lblProteinar = New System.Windows.Forms.Label()
        Me.lblResultadoAnalisis = New System.Windows.Forms.Label()
        Me.txtImpurezal = New System.Windows.Forms.TextBox()
        Me.lblImpurezal = New System.Windows.Forms.Label()
        Me.txtphectolitrol = New System.Windows.Forms.TextBox()
        Me.lblphectolitrol = New System.Windows.Forms.Label()
        Me.txtHumedadl = New System.Windows.Forms.TextBox()
        Me.lblHumedadl = New System.Windows.Forms.Label()
        Me.txtProteinal = New System.Windows.Forms.TextBox()
        Me.lblProteinal = New System.Windows.Forms.Label()
        Me.lblEstandarLote = New System.Windows.Forms.Label()
        Me.chkLaboratorio = New System.Windows.Forms.CheckBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.tbcEmbarques.SuspendLayout()
        Me.tbpEmbarque.SuspendLayout()
        Me.tbpRecepcion.SuspendLayout()
        Me.tbpInspeccionTrigo.SuspendLayout()
        Me.tbpInspeccionTransporte.SuspendLayout()
        Me.tbpLaboratorio.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(663, 9)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(666, 25)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(119, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'txtEmbId
        '
        Me.txtEmbId.AcceptsReturn = True
        Me.txtEmbId.Location = New System.Drawing.Point(62, 12)
        Me.txtEmbId.Multiline = True
        Me.txtEmbId.Name = "txtEmbId"
        Me.txtEmbId.Size = New System.Drawing.Size(109, 20)
        Me.txtEmbId.TabIndex = 1
        '
        'lblEmbId
        '
        Me.lblEmbId.AutoSize = True
        Me.lblEmbId.Location = New System.Drawing.Point(23, 15)
        Me.lblEmbId.Name = "lblEmbId"
        Me.lblEmbId.Size = New System.Drawing.Size(19, 13)
        Me.lblEmbId.TabIndex = 0
        Me.lblEmbId.Text = "Nº"
        '
        'tbcEmbarques
        '
        Me.tbcEmbarques.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcEmbarques.Controls.Add(Me.tbpEmbarque)
        Me.tbcEmbarques.Controls.Add(Me.tbpRecepcion)
        Me.tbcEmbarques.Controls.Add(Me.tbpInspeccionTrigo)
        Me.tbcEmbarques.Controls.Add(Me.tbpInspeccionTransporte)
        Me.tbcEmbarques.Controls.Add(Me.tbpLaboratorio)
        Me.tbcEmbarques.Enabled = False
        Me.tbcEmbarques.Location = New System.Drawing.Point(22, 55)
        Me.tbcEmbarques.Name = "tbcEmbarques"
        Me.tbcEmbarques.SelectedIndex = 0
        Me.tbcEmbarques.Size = New System.Drawing.Size(767, 439)
        Me.tbcEmbarques.TabIndex = 18
        '
        'tbpEmbarque
        '
        Me.tbpEmbarque.Controls.Add(Me.txtTarifa)
        Me.tbpEmbarque.Controls.Add(Me.lblTarifa)
        Me.tbpEmbarque.Controls.Add(Me.cmbMonedaId)
        Me.tbpEmbarque.Controls.Add(Me.lblMonedaId)
        Me.tbpEmbarque.Controls.Add(Me.lblObgen)
        Me.tbpEmbarque.Controls.Add(Me.txtObgen)
        Me.tbpEmbarque.Controls.Add(Me.txtSelloe)
        Me.tbpEmbarque.Controls.Add(Me.lblSelloe)
        Me.tbpEmbarque.Controls.Add(Me.txtFactfl)
        Me.tbpEmbarque.Controls.Add(Me.lblFactfl)
        Me.tbpEmbarque.Controls.Add(Me.txtPesoEmb)
        Me.tbpEmbarque.Controls.Add(Me.lblPesoEmb)
        Me.tbpEmbarque.Controls.Add(Me.txtProvFlete)
        Me.tbpEmbarque.Controls.Add(Me.cmdProvFlete)
        Me.tbpEmbarque.Controls.Add(Me.lblProvFleteId)
        Me.tbpEmbarque.Controls.Add(Me.txtProvFleteId)
        Me.tbpEmbarque.Controls.Add(Me.txtOrigen)
        Me.tbpEmbarque.Controls.Add(Me.cmdOrigen)
        Me.tbpEmbarque.Controls.Add(Me.lblOrigen)
        Me.tbpEmbarque.Controls.Add(Me.txtOrigenId)
        Me.tbpEmbarque.Controls.Add(Me.txtProvTrigo)
        Me.tbpEmbarque.Controls.Add(Me.cmdProvTrigo)
        Me.tbpEmbarque.Controls.Add(Me.lblProvTrigoId)
        Me.tbpEmbarque.Controls.Add(Me.txtProvTrigoId)
        Me.tbpEmbarque.Controls.Add(Me.txtTrigo)
        Me.tbpEmbarque.Controls.Add(Me.cmdTrigo)
        Me.tbpEmbarque.Controls.Add(Me.lblTrigoId)
        Me.tbpEmbarque.Controls.Add(Me.txtTrigoId)
        Me.tbpEmbarque.Controls.Add(Me.cmbLote)
        Me.tbpEmbarque.Controls.Add(Me.lblLoteId)
        Me.tbpEmbarque.Controls.Add(Me.txtLoteId)
        Me.tbpEmbarque.Controls.Add(Me.txtDestino)
        Me.tbpEmbarque.Controls.Add(Me.lblFechaOrden)
        Me.tbpEmbarque.Controls.Add(Me.dtpFechaEmbarque)
        Me.tbpEmbarque.Controls.Add(Me.cmdDstino)
        Me.tbpEmbarque.Controls.Add(Me.lblDstinoId)
        Me.tbpEmbarque.Controls.Add(Me.txtDstinoId)
        Me.tbpEmbarque.Controls.Add(Me.txtReftrans)
        Me.tbpEmbarque.Controls.Add(Me.lblReftrans)
        Me.tbpEmbarque.Controls.Add(Me.cmdOrden)
        Me.tbpEmbarque.Controls.Add(Me.lblOrdenId)
        Me.tbpEmbarque.Controls.Add(Me.txtOrdenId)
        Me.tbpEmbarque.Location = New System.Drawing.Point(4, 22)
        Me.tbpEmbarque.Name = "tbpEmbarque"
        Me.tbpEmbarque.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpEmbarque.Size = New System.Drawing.Size(759, 413)
        Me.tbpEmbarque.TabIndex = 0
        Me.tbpEmbarque.Text = "Embarque"
        Me.tbpEmbarque.UseVisualStyleBackColor = True
        '
        'txtTarifa
        '
        Me.txtTarifa.Location = New System.Drawing.Point(224, 307)
        Me.txtTarifa.Name = "txtTarifa"
        Me.txtTarifa.Size = New System.Drawing.Size(129, 20)
        Me.txtTarifa.TabIndex = 41
        '
        'lblTarifa
        '
        Me.lblTarifa.AutoSize = True
        Me.lblTarifa.Location = New System.Drawing.Point(225, 291)
        Me.lblTarifa.Name = "lblTarifa"
        Me.lblTarifa.Size = New System.Drawing.Size(34, 13)
        Me.lblTarifa.TabIndex = 40
        Me.lblTarifa.Text = "Tarifa"
        '
        'cmbMonedaId
        '
        Me.cmbMonedaId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonedaId.FormattingEnabled = True
        Me.cmbMonedaId.Location = New System.Drawing.Point(16, 307)
        Me.cmbMonedaId.Name = "cmbMonedaId"
        Me.cmbMonedaId.Size = New System.Drawing.Size(192, 21)
        Me.cmbMonedaId.TabIndex = 39
        '
        'lblMonedaId
        '
        Me.lblMonedaId.AutoSize = True
        Me.lblMonedaId.Location = New System.Drawing.Point(13, 291)
        Me.lblMonedaId.Name = "lblMonedaId"
        Me.lblMonedaId.Size = New System.Drawing.Size(46, 13)
        Me.lblMonedaId.TabIndex = 38
        Me.lblMonedaId.Text = "Moneda"
        '
        'lblObgen
        '
        Me.lblObgen.AutoSize = True
        Me.lblObgen.Location = New System.Drawing.Point(369, 191)
        Me.lblObgen.Name = "lblObgen"
        Me.lblObgen.Size = New System.Drawing.Size(78, 13)
        Me.lblObgen.TabIndex = 44
        Me.lblObgen.Text = "Observaciones"
        '
        'txtObgen
        '
        Me.txtObgen.AcceptsReturn = True
        Me.txtObgen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObgen.Location = New System.Drawing.Point(372, 207)
        Me.txtObgen.Multiline = True
        Me.txtObgen.Name = "txtObgen"
        Me.txtObgen.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObgen.Size = New System.Drawing.Size(371, 180)
        Me.txtObgen.TabIndex = 45
        '
        'txtSelloe
        '
        Me.txtSelloe.Location = New System.Drawing.Point(16, 358)
        Me.txtSelloe.Name = "txtSelloe"
        Me.txtSelloe.Size = New System.Drawing.Size(336, 20)
        Me.txtSelloe.TabIndex = 43
        '
        'lblSelloe
        '
        Me.lblSelloe.AutoSize = True
        Me.lblSelloe.Location = New System.Drawing.Point(13, 342)
        Me.lblSelloe.Name = "lblSelloe"
        Me.lblSelloe.Size = New System.Drawing.Size(95, 13)
        Me.lblSelloe.TabIndex = 42
        Me.lblSelloe.Text = "Sello de embarque"
        '
        'txtFactfl
        '
        Me.txtFactfl.Location = New System.Drawing.Point(165, 258)
        Me.txtFactfl.Name = "txtFactfl"
        Me.txtFactfl.Size = New System.Drawing.Size(187, 20)
        Me.txtFactfl.TabIndex = 37
        '
        'lblFactfl
        '
        Me.lblFactfl.AutoSize = True
        Me.lblFactfl.Location = New System.Drawing.Point(162, 242)
        Me.lblFactfl.Name = "lblFactfl"
        Me.lblFactfl.Size = New System.Drawing.Size(66, 13)
        Me.lblFactfl.TabIndex = 36
        Me.lblFactfl.Text = "Factura flete"
        '
        'txtPesoEmb
        '
        Me.txtPesoEmb.Location = New System.Drawing.Point(16, 258)
        Me.txtPesoEmb.Name = "txtPesoEmb"
        Me.txtPesoEmb.Size = New System.Drawing.Size(129, 20)
        Me.txtPesoEmb.TabIndex = 35
        '
        'lblPesoEmb
        '
        Me.lblPesoEmb.AutoSize = True
        Me.lblPesoEmb.Location = New System.Drawing.Point(17, 242)
        Me.lblPesoEmb.Name = "lblPesoEmb"
        Me.lblPesoEmb.Size = New System.Drawing.Size(112, 13)
        Me.lblPesoEmb.TabIndex = 34
        Me.lblPesoEmb.Text = "Peso embarcado (Tn.)"
        '
        'txtProvFlete
        '
        Me.txtProvFlete.AcceptsTab = True
        Me.txtProvFlete.Location = New System.Drawing.Point(44, 209)
        Me.txtProvFlete.Multiline = True
        Me.txtProvFlete.Name = "txtProvFlete"
        Me.txtProvFlete.Size = New System.Drawing.Size(308, 20)
        Me.txtProvFlete.TabIndex = 33
        '
        'cmdProvFlete
        '
        Me.cmdProvFlete.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdProvFlete.FlatAppearance.BorderSize = 0
        Me.cmdProvFlete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProvFlete.Location = New System.Drawing.Point(16, 207)
        Me.cmdProvFlete.Name = "cmdProvFlete"
        Me.cmdProvFlete.Size = New System.Drawing.Size(23, 23)
        Me.cmdProvFlete.TabIndex = 31
        Me.cmdProvFlete.Text = ">>"
        Me.cmdProvFlete.UseVisualStyleBackColor = True
        '
        'lblProvFleteId
        '
        Me.lblProvFleteId.AutoSize = True
        Me.lblProvFleteId.Location = New System.Drawing.Point(45, 191)
        Me.lblProvFleteId.Name = "lblProvFleteId"
        Me.lblProvFleteId.Size = New System.Drawing.Size(94, 13)
        Me.lblProvFleteId.TabIndex = 30
        Me.lblProvFleteId.Text = "Proveedor de flete"
        '
        'txtProvFleteId
        '
        Me.txtProvFleteId.AcceptsReturn = True
        Me.txtProvFleteId.AcceptsTab = True
        Me.txtProvFleteId.Location = New System.Drawing.Point(45, 209)
        Me.txtProvFleteId.Multiline = True
        Me.txtProvFleteId.Name = "txtProvFleteId"
        Me.txtProvFleteId.Size = New System.Drawing.Size(81, 20)
        Me.txtProvFleteId.TabIndex = 32
        Me.txtProvFleteId.Visible = False
        '
        'txtOrigen
        '
        Me.txtOrigen.Location = New System.Drawing.Point(44, 108)
        Me.txtOrigen.Name = "txtOrigen"
        Me.txtOrigen.Size = New System.Drawing.Size(332, 20)
        Me.txtOrigen.TabIndex = 23
        '
        'cmdOrigen
        '
        Me.cmdOrigen.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdOrigen.FlatAppearance.BorderSize = 0
        Me.cmdOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOrigen.Location = New System.Drawing.Point(20, 105)
        Me.cmdOrigen.Name = "cmdOrigen"
        Me.cmdOrigen.Size = New System.Drawing.Size(23, 23)
        Me.cmdOrigen.TabIndex = 20
        Me.cmdOrigen.Text = ">>"
        Me.cmdOrigen.UseVisualStyleBackColor = True
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.Location = New System.Drawing.Point(45, 92)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(38, 13)
        Me.lblOrigen.TabIndex = 21
        Me.lblOrigen.Text = "Origen"
        '
        'txtOrigenId
        '
        Me.txtOrigenId.AcceptsReturn = True
        Me.txtOrigenId.AcceptsTab = True
        Me.txtOrigenId.Location = New System.Drawing.Point(44, 107)
        Me.txtOrigenId.Multiline = True
        Me.txtOrigenId.Name = "txtOrigenId"
        Me.txtOrigenId.Size = New System.Drawing.Size(101, 20)
        Me.txtOrigenId.TabIndex = 22
        Me.txtOrigenId.Visible = False
        '
        'txtProvTrigo
        '
        Me.txtProvTrigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProvTrigo.Location = New System.Drawing.Point(422, 69)
        Me.txtProvTrigo.Name = "txtProvTrigo"
        Me.txtProvTrigo.Size = New System.Drawing.Size(318, 20)
        Me.txtProvTrigo.TabIndex = 19
        '
        'cmdProvTrigo
        '
        Me.cmdProvTrigo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdProvTrigo.FlatAppearance.BorderSize = 0
        Me.cmdProvTrigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdProvTrigo.Location = New System.Drawing.Point(393, 66)
        Me.cmdProvTrigo.Name = "cmdProvTrigo"
        Me.cmdProvTrigo.Size = New System.Drawing.Size(23, 23)
        Me.cmdProvTrigo.TabIndex = 16
        Me.cmdProvTrigo.Text = ">>"
        Me.cmdProvTrigo.UseVisualStyleBackColor = True
        '
        'lblProvTrigoId
        '
        Me.lblProvTrigoId.AutoSize = True
        Me.lblProvTrigoId.Location = New System.Drawing.Point(422, 53)
        Me.lblProvTrigoId.Name = "lblProvTrigoId"
        Me.lblProvTrigoId.Size = New System.Drawing.Size(83, 13)
        Me.lblProvTrigoId.TabIndex = 17
        Me.lblProvTrigoId.Text = "Proveedor Trigo"
        '
        'txtProvTrigoId
        '
        Me.txtProvTrigoId.AcceptsReturn = True
        Me.txtProvTrigoId.AcceptsTab = True
        Me.txtProvTrigoId.Location = New System.Drawing.Point(422, 69)
        Me.txtProvTrigoId.Multiline = True
        Me.txtProvTrigoId.Name = "txtProvTrigoId"
        Me.txtProvTrigoId.Size = New System.Drawing.Size(81, 20)
        Me.txtProvTrigoId.TabIndex = 18
        Me.txtProvTrigoId.Visible = False
        '
        'txtTrigo
        '
        Me.txtTrigo.Location = New System.Drawing.Point(44, 69)
        Me.txtTrigo.Name = "txtTrigo"
        Me.txtTrigo.Size = New System.Drawing.Size(331, 20)
        Me.txtTrigo.TabIndex = 15
        '
        'cmdTrigo
        '
        Me.cmdTrigo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdTrigo.FlatAppearance.BorderSize = 0
        Me.cmdTrigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTrigo.Location = New System.Drawing.Point(16, 66)
        Me.cmdTrigo.Name = "cmdTrigo"
        Me.cmdTrigo.Size = New System.Drawing.Size(23, 23)
        Me.cmdTrigo.TabIndex = 13
        Me.cmdTrigo.Text = ">>"
        Me.cmdTrigo.UseVisualStyleBackColor = True
        '
        'lblTrigoId
        '
        Me.lblTrigoId.AutoSize = True
        Me.lblTrigoId.Location = New System.Drawing.Point(45, 53)
        Me.lblTrigoId.Name = "lblTrigoId"
        Me.lblTrigoId.Size = New System.Drawing.Size(31, 13)
        Me.lblTrigoId.TabIndex = 12
        Me.lblTrigoId.Text = "Trigo"
        '
        'txtTrigoId
        '
        Me.txtTrigoId.AcceptsReturn = True
        Me.txtTrigoId.AcceptsTab = True
        Me.txtTrigoId.Location = New System.Drawing.Point(44, 69)
        Me.txtTrigoId.Multiline = True
        Me.txtTrigoId.Name = "txtTrigoId"
        Me.txtTrigoId.Size = New System.Drawing.Size(101, 20)
        Me.txtTrigoId.TabIndex = 14
        Me.txtTrigoId.Visible = False
        '
        'cmbLote
        '
        Me.cmbLote.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbLote.FlatAppearance.BorderSize = 0
        Me.cmbLote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbLote.Location = New System.Drawing.Point(312, 26)
        Me.cmbLote.Name = "cmbLote"
        Me.cmbLote.Size = New System.Drawing.Size(23, 23)
        Me.cmbLote.TabIndex = 9
        Me.cmbLote.Text = ">>"
        Me.cmbLote.UseVisualStyleBackColor = True
        '
        'lblLoteId
        '
        Me.lblLoteId.AutoSize = True
        Me.lblLoteId.Location = New System.Drawing.Point(341, 13)
        Me.lblLoteId.Name = "lblLoteId"
        Me.lblLoteId.Size = New System.Drawing.Size(28, 13)
        Me.lblLoteId.TabIndex = 10
        Me.lblLoteId.Text = "Lote"
        '
        'txtLoteId
        '
        Me.txtLoteId.AcceptsReturn = True
        Me.txtLoteId.AcceptsTab = True
        Me.txtLoteId.Location = New System.Drawing.Point(340, 29)
        Me.txtLoteId.Multiline = True
        Me.txtLoteId.Name = "txtLoteId"
        Me.txtLoteId.Size = New System.Drawing.Size(121, 20)
        Me.txtLoteId.TabIndex = 11
        '
        'txtDestino
        '
        Me.txtDestino.AcceptsTab = True
        Me.txtDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDestino.Location = New System.Drawing.Point(308, 158)
        Me.txtDestino.Multiline = True
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(435, 20)
        Me.txtDestino.TabIndex = 29
        '
        'lblFechaOrden
        '
        Me.lblFechaOrden.AutoSize = True
        Me.lblFechaOrden.Location = New System.Drawing.Point(13, 12)
        Me.lblFechaOrden.Name = "lblFechaOrden"
        Me.lblFechaOrden.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaOrden.TabIndex = 4
        Me.lblFechaOrden.Text = "Fecha"
        '
        'dtpFechaEmbarque
        '
        Me.dtpFechaEmbarque.Checked = False
        Me.dtpFechaEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEmbarque.Location = New System.Drawing.Point(16, 28)
        Me.dtpFechaEmbarque.Name = "dtpFechaEmbarque"
        Me.dtpFechaEmbarque.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaEmbarque.TabIndex = 5
        '
        'cmdDstino
        '
        Me.cmdDstino.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdDstino.FlatAppearance.BorderSize = 0
        Me.cmdDstino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDstino.Location = New System.Drawing.Point(279, 155)
        Me.cmdDstino.Name = "cmdDstino"
        Me.cmdDstino.Size = New System.Drawing.Size(23, 23)
        Me.cmdDstino.TabIndex = 26
        Me.cmdDstino.Text = ">>"
        Me.cmdDstino.UseVisualStyleBackColor = True
        '
        'lblDstinoId
        '
        Me.lblDstinoId.AutoSize = True
        Me.lblDstinoId.Location = New System.Drawing.Point(309, 142)
        Me.lblDstinoId.Name = "lblDstinoId"
        Me.lblDstinoId.Size = New System.Drawing.Size(43, 13)
        Me.lblDstinoId.TabIndex = 27
        Me.lblDstinoId.Text = "Destino"
        '
        'txtDstinoId
        '
        Me.txtDstinoId.AcceptsReturn = True
        Me.txtDstinoId.AcceptsTab = True
        Me.txtDstinoId.Location = New System.Drawing.Point(308, 158)
        Me.txtDstinoId.Multiline = True
        Me.txtDstinoId.Name = "txtDstinoId"
        Me.txtDstinoId.Size = New System.Drawing.Size(121, 20)
        Me.txtDstinoId.TabIndex = 28
        Me.txtDstinoId.Visible = False
        '
        'txtReftrans
        '
        Me.txtReftrans.Location = New System.Drawing.Point(20, 158)
        Me.txtReftrans.Name = "txtReftrans"
        Me.txtReftrans.Size = New System.Drawing.Size(239, 20)
        Me.txtReftrans.TabIndex = 25
        '
        'lblReftrans
        '
        Me.lblReftrans.AutoSize = True
        Me.lblReftrans.Location = New System.Drawing.Point(17, 142)
        Me.lblReftrans.Name = "lblReftrans"
        Me.lblReftrans.Size = New System.Drawing.Size(77, 13)
        Me.lblReftrans.TabIndex = 24
        Me.lblReftrans.Text = "Ref. transporte"
        '
        'cmdOrden
        '
        Me.cmdOrden.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdOrden.FlatAppearance.BorderSize = 0
        Me.cmdOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOrden.Location = New System.Drawing.Point(143, 25)
        Me.cmdOrden.Name = "cmdOrden"
        Me.cmdOrden.Size = New System.Drawing.Size(23, 23)
        Me.cmdOrden.TabIndex = 6
        Me.cmdOrden.Text = ">>"
        Me.cmdOrden.UseVisualStyleBackColor = True
        '
        'lblOrdenId
        '
        Me.lblOrdenId.AutoSize = True
        Me.lblOrdenId.Location = New System.Drawing.Point(172, 12)
        Me.lblOrdenId.Name = "lblOrdenId"
        Me.lblOrdenId.Size = New System.Drawing.Size(36, 13)
        Me.lblOrdenId.TabIndex = 7
        Me.lblOrdenId.Text = "Orden"
        '
        'txtOrdenId
        '
        Me.txtOrdenId.AcceptsReturn = True
        Me.txtOrdenId.AcceptsTab = True
        Me.txtOrdenId.Location = New System.Drawing.Point(172, 28)
        Me.txtOrdenId.Multiline = True
        Me.txtOrdenId.Name = "txtOrdenId"
        Me.txtOrdenId.Size = New System.Drawing.Size(121, 20)
        Me.txtOrdenId.TabIndex = 8
        '
        'tbpRecepcion
        '
        Me.tbpRecepcion.Controls.Add(Me.txtPesoembc)
        Me.tbpRecepcion.Controls.Add(Me.lblPesoembc)
        Me.tbpRecepcion.Controls.Add(Me.lblInformacionEmbarque)
        Me.tbpRecepcion.Controls.Add(Me.lstSilos)
        Me.tbpRecepcion.Controls.Add(Me.lblAlertaDif)
        Me.tbpRecepcion.Controls.Add(Me.txtSelloRecep)
        Me.tbpRecepcion.Controls.Add(Me.lblSelloRecep)
        Me.tbpRecepcion.Controls.Add(Me.lblSilos)
        Me.tbpRecepcion.Controls.Add(Me.txtOperador)
        Me.tbpRecepcion.Controls.Add(Me.cmdOperador)
        Me.tbpRecepcion.Controls.Add(Me.lblOperador)
        Me.tbpRecepcion.Controls.Add(Me.txtOperadorId)
        Me.tbpRecepcion.Controls.Add(Me.txtDiferencia)
        Me.tbpRecepcion.Controls.Add(Me.lblDif)
        Me.tbpRecepcion.Controls.Add(Me.txtPesoRecibido)
        Me.tbpRecepcion.Controls.Add(Me.lblPesoRecibido)
        Me.tbpRecepcion.Controls.Add(Me.lblFchrec)
        Me.tbpRecepcion.Controls.Add(Me.dtpFchrec)
        Me.tbpRecepcion.Location = New System.Drawing.Point(4, 22)
        Me.tbpRecepcion.Name = "tbpRecepcion"
        Me.tbpRecepcion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRecepcion.Size = New System.Drawing.Size(759, 413)
        Me.tbpRecepcion.TabIndex = 1
        Me.tbpRecepcion.Text = "Recepción"
        Me.tbpRecepcion.UseVisualStyleBackColor = True
        '
        'txtPesoembc
        '
        Me.txtPesoembc.Location = New System.Drawing.Point(20, 75)
        Me.txtPesoembc.Name = "txtPesoembc"
        Me.txtPesoembc.Size = New System.Drawing.Size(108, 20)
        Me.txtPesoembc.TabIndex = 52
        '
        'lblPesoembc
        '
        Me.lblPesoembc.AutoSize = True
        Me.lblPesoembc.Location = New System.Drawing.Point(16, 59)
        Me.lblPesoembc.Name = "lblPesoembc"
        Me.lblPesoembc.Size = New System.Drawing.Size(112, 13)
        Me.lblPesoembc.TabIndex = 51
        Me.lblPesoembc.Text = "Peso embarcado (Tn.)"
        '
        'lblInformacionEmbarque
        '
        Me.lblInformacionEmbarque.Location = New System.Drawing.Point(213, 163)
        Me.lblInformacionEmbarque.Name = "lblInformacionEmbarque"
        Me.lblInformacionEmbarque.Size = New System.Drawing.Size(529, 220)
        Me.lblInformacionEmbarque.TabIndex = 50
        Me.lblInformacionEmbarque.Text = "Informacion de Embarque"
        '
        'lstSilos
        '
        Me.lstSilos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstSilos.FormattingEnabled = True
        Me.lstSilos.Location = New System.Drawing.Point(15, 174)
        Me.lstSilos.Name = "lstSilos"
        Me.lstSilos.Size = New System.Drawing.Size(149, 214)
        Me.lstSilos.TabIndex = 49
        '
        'lblAlertaDif
        '
        Me.lblAlertaDif.Location = New System.Drawing.Point(388, 59)
        Me.lblAlertaDif.Name = "lblAlertaDif"
        Me.lblAlertaDif.Size = New System.Drawing.Size(354, 47)
        Me.lblAlertaDif.TabIndex = 48
        Me.lblAlertaDif.Text = "Sin información sobre la Diferencia"
        Me.lblAlertaDif.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSelloRecep
        '
        Me.txtSelloRecep.Location = New System.Drawing.Point(447, 122)
        Me.txtSelloRecep.Name = "txtSelloRecep"
        Me.txtSelloRecep.Size = New System.Drawing.Size(149, 20)
        Me.txtSelloRecep.TabIndex = 47
        '
        'lblSelloRecep
        '
        Me.lblSelloRecep.AutoSize = True
        Me.lblSelloRecep.Location = New System.Drawing.Point(448, 106)
        Me.lblSelloRecep.Name = "lblSelloRecep"
        Me.lblSelloRecep.Size = New System.Drawing.Size(80, 13)
        Me.lblSelloRecep.TabIndex = 46
        Me.lblSelloRecep.Text = "Sello recepción"
        '
        'lblSilos
        '
        Me.lblSilos.AutoSize = True
        Me.lblSilos.Location = New System.Drawing.Point(18, 158)
        Me.lblSilos.Name = "lblSilos"
        Me.lblSilos.Size = New System.Drawing.Size(35, 13)
        Me.lblSilos.TabIndex = 44
        Me.lblSilos.Text = "Silo(s)"
        '
        'txtOperador
        '
        Me.txtOperador.AcceptsTab = True
        Me.txtOperador.Location = New System.Drawing.Point(44, 124)
        Me.txtOperador.Multiline = True
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(386, 20)
        Me.txtOperador.TabIndex = 43
        '
        'cmdOperador
        '
        Me.cmdOperador.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdOperador.FlatAppearance.BorderSize = 0
        Me.cmdOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOperador.Location = New System.Drawing.Point(15, 122)
        Me.cmdOperador.Name = "cmdOperador"
        Me.cmdOperador.Size = New System.Drawing.Size(23, 23)
        Me.cmdOperador.TabIndex = 41
        Me.cmdOperador.Text = ">>"
        Me.cmdOperador.UseVisualStyleBackColor = True
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(41, 106)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(51, 13)
        Me.lblOperador.TabIndex = 40
        Me.lblOperador.Text = "Operador"
        '
        'txtOperadorId
        '
        Me.txtOperadorId.AcceptsReturn = True
        Me.txtOperadorId.AcceptsTab = True
        Me.txtOperadorId.Location = New System.Drawing.Point(44, 125)
        Me.txtOperadorId.Multiline = True
        Me.txtOperadorId.Name = "txtOperadorId"
        Me.txtOperadorId.Size = New System.Drawing.Size(81, 20)
        Me.txtOperadorId.TabIndex = 42
        Me.txtOperadorId.Visible = False
        '
        'txtDiferencia
        '
        Me.txtDiferencia.Enabled = False
        Me.txtDiferencia.Location = New System.Drawing.Point(276, 75)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.Size = New System.Drawing.Size(106, 20)
        Me.txtDiferencia.TabIndex = 39
        '
        'lblDif
        '
        Me.lblDif.AutoSize = True
        Me.lblDif.Location = New System.Drawing.Point(273, 59)
        Me.lblDif.Name = "lblDif"
        Me.lblDif.Size = New System.Drawing.Size(80, 13)
        Me.lblDif.TabIndex = 38
        Me.lblDif.Text = "Diferencia (Tn.)"
        '
        'txtPesoRecibido
        '
        Me.txtPesoRecibido.Location = New System.Drawing.Point(144, 75)
        Me.txtPesoRecibido.Name = "txtPesoRecibido"
        Me.txtPesoRecibido.Size = New System.Drawing.Size(115, 20)
        Me.txtPesoRecibido.TabIndex = 37
        '
        'lblPesoRecibido
        '
        Me.lblPesoRecibido.AutoSize = True
        Me.lblPesoRecibido.Location = New System.Drawing.Point(141, 59)
        Me.lblPesoRecibido.Name = "lblPesoRecibido"
        Me.lblPesoRecibido.Size = New System.Drawing.Size(96, 13)
        Me.lblPesoRecibido.TabIndex = 36
        Me.lblPesoRecibido.Text = "Peso recibido (Tn.)"
        '
        'lblFchrec
        '
        Me.lblFchrec.AutoSize = True
        Me.lblFchrec.Location = New System.Drawing.Point(16, 13)
        Me.lblFchrec.Name = "lblFchrec"
        Me.lblFchrec.Size = New System.Drawing.Size(37, 13)
        Me.lblFchrec.TabIndex = 6
        Me.lblFchrec.Text = "Fecha"
        '
        'dtpFchrec
        '
        Me.dtpFchrec.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFchrec.Location = New System.Drawing.Point(19, 29)
        Me.dtpFchrec.Name = "dtpFchrec"
        Me.dtpFchrec.Size = New System.Drawing.Size(109, 20)
        Me.dtpFchrec.TabIndex = 7
        '
        'tbpInspeccionTrigo
        '
        Me.tbpInspeccionTrigo.Controls.Add(Me.txtObservacionestri)
        Me.tbpInspeccionTrigo.Controls.Add(Me.lblObservacionestri)
        Me.tbpInspeccionTrigo.Controls.Add(Me.chkConformetri)
        Me.tbpInspeccionTrigo.Controls.Add(Me.txtOtrost)
        Me.tbpInspeccionTrigo.Controls.Add(Me.lblOtrost)
        Me.tbpInspeccionTrigo.Controls.Add(Me.txtPlagas)
        Me.tbpInspeccionTrigo.Controls.Add(Me.lblPlagas)
        Me.tbpInspeccionTrigo.Controls.Add(Me.txtDaniado)
        Me.tbpInspeccionTrigo.Controls.Add(Me.lblDaniado)
        Me.tbpInspeccionTrigo.Controls.Add(Me.txtColor)
        Me.tbpInspeccionTrigo.Controls.Add(Me.lblColor)
        Me.tbpInspeccionTrigo.Controls.Add(Me.txtOlor)
        Me.tbpInspeccionTrigo.Controls.Add(Me.lblOlor)
        Me.tbpInspeccionTrigo.Controls.Add(Me.chkCondLimpieza)
        Me.tbpInspeccionTrigo.Location = New System.Drawing.Point(4, 22)
        Me.tbpInspeccionTrigo.Name = "tbpInspeccionTrigo"
        Me.tbpInspeccionTrigo.Size = New System.Drawing.Size(759, 413)
        Me.tbpInspeccionTrigo.TabIndex = 2
        Me.tbpInspeccionTrigo.Text = "Problemas en la inspección primaria"
        Me.tbpInspeccionTrigo.UseVisualStyleBackColor = True
        '
        'txtObservacionestri
        '
        Me.txtObservacionestri.AcceptsReturn = True
        Me.txtObservacionestri.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionestri.Location = New System.Drawing.Point(113, 330)
        Me.txtObservacionestri.Multiline = True
        Me.txtObservacionestri.Name = "txtObservacionestri"
        Me.txtObservacionestri.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacionestri.Size = New System.Drawing.Size(605, 71)
        Me.txtObservacionestri.TabIndex = 60
        '
        'lblObservacionestri
        '
        Me.lblObservacionestri.AutoSize = True
        Me.lblObservacionestri.Location = New System.Drawing.Point(33, 330)
        Me.lblObservacionestri.Name = "lblObservacionestri"
        Me.lblObservacionestri.Size = New System.Drawing.Size(78, 13)
        Me.lblObservacionestri.TabIndex = 59
        Me.lblObservacionestri.Text = "Observaciones"
        '
        'chkConformetri
        '
        Me.chkConformetri.AutoSize = True
        Me.chkConformetri.Location = New System.Drawing.Point(36, 384)
        Me.chkConformetri.Name = "chkConformetri"
        Me.chkConformetri.Size = New System.Drawing.Size(71, 17)
        Me.chkConformetri.TabIndex = 58
        Me.chkConformetri.Text = "Conforme"
        Me.chkConformetri.UseVisualStyleBackColor = True
        '
        'txtOtrost
        '
        Me.txtOtrost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtrost.Location = New System.Drawing.Point(54, 290)
        Me.txtOtrost.Name = "txtOtrost"
        Me.txtOtrost.Size = New System.Drawing.Size(664, 20)
        Me.txtOtrost.TabIndex = 57
        '
        'lblOtrost
        '
        Me.lblOtrost.AutoSize = True
        Me.lblOtrost.Location = New System.Drawing.Point(51, 274)
        Me.lblOtrost.Name = "lblOtrost"
        Me.lblOtrost.Size = New System.Drawing.Size(32, 13)
        Me.lblOtrost.TabIndex = 56
        Me.lblOtrost.Text = "Otros"
        '
        'txtPlagas
        '
        Me.txtPlagas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPlagas.Location = New System.Drawing.Point(54, 233)
        Me.txtPlagas.Name = "txtPlagas"
        Me.txtPlagas.Size = New System.Drawing.Size(664, 20)
        Me.txtPlagas.TabIndex = 55
        '
        'lblPlagas
        '
        Me.lblPlagas.AutoSize = True
        Me.lblPlagas.Location = New System.Drawing.Point(51, 217)
        Me.lblPlagas.Name = "lblPlagas"
        Me.lblPlagas.Size = New System.Drawing.Size(39, 13)
        Me.lblPlagas.TabIndex = 54
        Me.lblPlagas.Text = "Plagas"
        '
        'txtDaniado
        '
        Me.txtDaniado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDaniado.Location = New System.Drawing.Point(54, 179)
        Me.txtDaniado.Name = "txtDaniado"
        Me.txtDaniado.Size = New System.Drawing.Size(664, 20)
        Me.txtDaniado.TabIndex = 53
        '
        'lblDaniado
        '
        Me.lblDaniado.AutoSize = True
        Me.lblDaniado.Location = New System.Drawing.Point(51, 163)
        Me.lblDaniado.Name = "lblDaniado"
        Me.lblDaniado.Size = New System.Drawing.Size(45, 13)
        Me.lblDaniado.TabIndex = 52
        Me.lblDaniado.Text = "Dañado"
        '
        'txtColor
        '
        Me.txtColor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColor.Location = New System.Drawing.Point(54, 127)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(664, 20)
        Me.txtColor.TabIndex = 51
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(51, 111)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 50
        Me.lblColor.Text = "Color"
        '
        'txtOlor
        '
        Me.txtOlor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOlor.Location = New System.Drawing.Point(54, 75)
        Me.txtOlor.Name = "txtOlor"
        Me.txtOlor.Size = New System.Drawing.Size(664, 20)
        Me.txtOlor.TabIndex = 49
        '
        'lblOlor
        '
        Me.lblOlor.AutoSize = True
        Me.lblOlor.Location = New System.Drawing.Point(51, 59)
        Me.lblOlor.Name = "lblOlor"
        Me.lblOlor.Size = New System.Drawing.Size(26, 13)
        Me.lblOlor.TabIndex = 48
        Me.lblOlor.Text = "Olor"
        '
        'chkCondLimpieza
        '
        Me.chkCondLimpieza.AutoSize = True
        Me.chkCondLimpieza.Location = New System.Drawing.Point(36, 22)
        Me.chkCondLimpieza.Name = "chkCondLimpieza"
        Me.chkCondLimpieza.Size = New System.Drawing.Size(143, 17)
        Me.chkCondLimpieza.TabIndex = 0
        Me.chkCondLimpieza.Text = "Condiciones de Limpieza"
        Me.chkCondLimpieza.UseVisualStyleBackColor = True
        '
        'tbpInspeccionTransporte
        '
        Me.tbpInspeccionTransporte.Controls.Add(Me.txtObservacionestra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.lblObservacionestra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.chkConformetra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.txtServtra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.lblServtra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.txtSellosc)
        Me.tbpInspeccionTransporte.Controls.Add(Me.lblSellosc)
        Me.tbpInspeccionTransporte.Controls.Add(Me.txtOtrosp)
        Me.tbpInspeccionTransporte.Controls.Add(Me.lblOtrosp)
        Me.tbpInspeccionTransporte.Controls.Add(Me.txtLibregra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.lblLibregra)
        Me.tbpInspeccionTransporte.Controls.Add(Me.txtLibreba)
        Me.tbpInspeccionTransporte.Controls.Add(Me.lblLibreba)
        Me.tbpInspeccionTransporte.Controls.Add(Me.chkCondTransporte)
        Me.tbpInspeccionTransporte.Location = New System.Drawing.Point(4, 22)
        Me.tbpInspeccionTransporte.Name = "tbpInspeccionTransporte"
        Me.tbpInspeccionTransporte.Size = New System.Drawing.Size(759, 413)
        Me.tbpInspeccionTransporte.TabIndex = 3
        Me.tbpInspeccionTransporte.Text = "Problemas en la inspección al transporte"
        Me.tbpInspeccionTransporte.UseVisualStyleBackColor = True
        '
        'txtObservacionestra
        '
        Me.txtObservacionestra.AcceptsReturn = True
        Me.txtObservacionestra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionestra.Location = New System.Drawing.Point(113, 327)
        Me.txtObservacionestra.Multiline = True
        Me.txtObservacionestra.Name = "txtObservacionestra"
        Me.txtObservacionestra.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacionestra.Size = New System.Drawing.Size(607, 71)
        Me.txtObservacionestra.TabIndex = 71
        '
        'lblObservacionestra
        '
        Me.lblObservacionestra.AutoSize = True
        Me.lblObservacionestra.Location = New System.Drawing.Point(33, 327)
        Me.lblObservacionestra.Name = "lblObservacionestra"
        Me.lblObservacionestra.Size = New System.Drawing.Size(78, 13)
        Me.lblObservacionestra.TabIndex = 70
        Me.lblObservacionestra.Text = "Observaciones"
        '
        'chkConformetra
        '
        Me.chkConformetra.AutoSize = True
        Me.chkConformetra.Location = New System.Drawing.Point(36, 381)
        Me.chkConformetra.Name = "chkConformetra"
        Me.chkConformetra.Size = New System.Drawing.Size(71, 17)
        Me.chkConformetra.TabIndex = 69
        Me.chkConformetra.Text = "Conforme"
        Me.chkConformetra.UseVisualStyleBackColor = True
        '
        'txtServtra
        '
        Me.txtServtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServtra.Location = New System.Drawing.Point(54, 290)
        Me.txtServtra.Name = "txtServtra"
        Me.txtServtra.Size = New System.Drawing.Size(664, 20)
        Me.txtServtra.TabIndex = 68
        '
        'lblServtra
        '
        Me.lblServtra.AutoSize = True
        Me.lblServtra.Location = New System.Drawing.Point(51, 274)
        Me.lblServtra.Name = "lblServtra"
        Me.lblServtra.Size = New System.Drawing.Size(115, 13)
        Me.lblServtra.TabIndex = 67
        Me.lblServtra.Text = "Servicios de transporte"
        '
        'txtSellosc
        '
        Me.txtSellosc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSellosc.Location = New System.Drawing.Point(54, 233)
        Me.txtSellosc.Name = "txtSellosc"
        Me.txtSellosc.Size = New System.Drawing.Size(664, 20)
        Me.txtSellosc.TabIndex = 66
        '
        'lblSellosc
        '
        Me.lblSellosc.AutoSize = True
        Me.lblSellosc.Location = New System.Drawing.Point(51, 217)
        Me.lblSellosc.Name = "lblSellosc"
        Me.lblSellosc.Size = New System.Drawing.Size(86, 13)
        Me.lblSellosc.TabIndex = 65
        Me.lblSellosc.Text = "Sellos completos"
        '
        'txtOtrosp
        '
        Me.txtOtrosp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtrosp.Location = New System.Drawing.Point(54, 179)
        Me.txtOtrosp.Name = "txtOtrosp"
        Me.txtOtrosp.Size = New System.Drawing.Size(664, 20)
        Me.txtOtrosp.TabIndex = 64
        '
        'lblOtrosp
        '
        Me.lblOtrosp.AutoSize = True
        Me.lblOtrosp.Location = New System.Drawing.Point(51, 163)
        Me.lblOtrosp.Name = "lblOtrosp"
        Me.lblOtrosp.Size = New System.Drawing.Size(32, 13)
        Me.lblOtrosp.TabIndex = 63
        Me.lblOtrosp.Text = "Otros"
        '
        'txtLibregra
        '
        Me.txtLibregra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLibregra.Location = New System.Drawing.Point(54, 127)
        Me.txtLibregra.Name = "txtLibregra"
        Me.txtLibregra.Size = New System.Drawing.Size(664, 20)
        Me.txtLibregra.TabIndex = 62
        '
        'lblLibregra
        '
        Me.lblLibregra.AutoSize = True
        Me.lblLibregra.Location = New System.Drawing.Point(51, 111)
        Me.lblLibregra.Name = "lblLibregra"
        Me.lblLibregra.Size = New System.Drawing.Size(80, 13)
        Me.lblLibregra.TabIndex = 61
        Me.lblLibregra.Text = "Libre de granos"
        '
        'txtLibreba
        '
        Me.txtLibreba.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLibreba.Location = New System.Drawing.Point(54, 75)
        Me.txtLibreba.Name = "txtLibreba"
        Me.txtLibreba.Size = New System.Drawing.Size(664, 20)
        Me.txtLibreba.TabIndex = 60
        '
        'lblLibreba
        '
        Me.lblLibreba.AutoSize = True
        Me.lblLibreba.Location = New System.Drawing.Point(51, 59)
        Me.lblLibreba.Name = "lblLibreba"
        Me.lblLibreba.Size = New System.Drawing.Size(80, 13)
        Me.lblLibreba.TabIndex = 59
        Me.lblLibreba.Text = "Libre de basura"
        '
        'chkCondTransporte
        '
        Me.chkCondTransporte.AutoSize = True
        Me.chkCondTransporte.Location = New System.Drawing.Point(36, 22)
        Me.chkCondTransporte.Name = "chkCondTransporte"
        Me.chkCondTransporte.Size = New System.Drawing.Size(153, 17)
        Me.chkCondTransporte.TabIndex = 58
        Me.chkCondTransporte.Text = "Condiciones de Transporte"
        Me.chkCondTransporte.UseVisualStyleBackColor = True
        '
        'tbpLaboratorio
        '
        Me.tbpLaboratorio.Controls.Add(Me.txtObslab)
        Me.tbpLaboratorio.Controls.Add(Me.lblObslab)
        Me.tbpLaboratorio.Controls.Add(Me.txtImpurezar)
        Me.tbpLaboratorio.Controls.Add(Me.lblImpurezar)
        Me.tbpLaboratorio.Controls.Add(Me.txtPhectolitror)
        Me.tbpLaboratorio.Controls.Add(Me.lblPhectolitror)
        Me.tbpLaboratorio.Controls.Add(Me.txtHumedadr)
        Me.tbpLaboratorio.Controls.Add(Me.lblHumedadr)
        Me.tbpLaboratorio.Controls.Add(Me.txtProteinar)
        Me.tbpLaboratorio.Controls.Add(Me.lblProteinar)
        Me.tbpLaboratorio.Controls.Add(Me.lblResultadoAnalisis)
        Me.tbpLaboratorio.Controls.Add(Me.txtImpurezal)
        Me.tbpLaboratorio.Controls.Add(Me.lblImpurezal)
        Me.tbpLaboratorio.Controls.Add(Me.txtphectolitrol)
        Me.tbpLaboratorio.Controls.Add(Me.lblphectolitrol)
        Me.tbpLaboratorio.Controls.Add(Me.txtHumedadl)
        Me.tbpLaboratorio.Controls.Add(Me.lblHumedadl)
        Me.tbpLaboratorio.Controls.Add(Me.txtProteinal)
        Me.tbpLaboratorio.Controls.Add(Me.lblProteinal)
        Me.tbpLaboratorio.Controls.Add(Me.lblEstandarLote)
        Me.tbpLaboratorio.Controls.Add(Me.chkLaboratorio)
        Me.tbpLaboratorio.Location = New System.Drawing.Point(4, 22)
        Me.tbpLaboratorio.Name = "tbpLaboratorio"
        Me.tbpLaboratorio.Size = New System.Drawing.Size(759, 413)
        Me.tbpLaboratorio.TabIndex = 4
        Me.tbpLaboratorio.Text = "Análisis Físicos"
        Me.tbpLaboratorio.UseVisualStyleBackColor = True
        '
        'txtObslab
        '
        Me.txtObslab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObslab.Location = New System.Drawing.Point(62, 251)
        Me.txtObslab.Multiline = True
        Me.txtObslab.Name = "txtObslab"
        Me.txtObslab.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObslab.Size = New System.Drawing.Size(608, 83)
        Me.txtObslab.TabIndex = 100
        '
        'lblObslab
        '
        Me.lblObslab.AutoSize = True
        Me.lblObslab.Location = New System.Drawing.Point(59, 235)
        Me.lblObslab.Name = "lblObslab"
        Me.lblObslab.Size = New System.Drawing.Size(78, 13)
        Me.lblObslab.TabIndex = 99
        Me.lblObslab.Text = "Observaciones"
        '
        'txtImpurezar
        '
        Me.txtImpurezar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImpurezar.Location = New System.Drawing.Point(462, 201)
        Me.txtImpurezar.Name = "txtImpurezar"
        Me.txtImpurezar.Size = New System.Drawing.Size(171, 20)
        Me.txtImpurezar.TabIndex = 98
        '
        'lblImpurezar
        '
        Me.lblImpurezar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblImpurezar.AutoSize = True
        Me.lblImpurezar.Location = New System.Drawing.Point(459, 185)
        Me.lblImpurezar.Name = "lblImpurezar"
        Me.lblImpurezar.Size = New System.Drawing.Size(50, 13)
        Me.lblImpurezar.TabIndex = 97
        Me.lblImpurezar.Text = "Impureza"
        '
        'txtPhectolitror
        '
        Me.txtPhectolitror.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPhectolitror.Location = New System.Drawing.Point(462, 160)
        Me.txtPhectolitror.Name = "txtPhectolitror"
        Me.txtPhectolitror.Size = New System.Drawing.Size(171, 20)
        Me.txtPhectolitror.TabIndex = 96
        '
        'lblPhectolitror
        '
        Me.lblPhectolitror.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPhectolitror.AutoSize = True
        Me.lblPhectolitror.Location = New System.Drawing.Point(459, 144)
        Me.lblPhectolitror.Name = "lblPhectolitror"
        Me.lblPhectolitror.Size = New System.Drawing.Size(77, 13)
        Me.lblPhectolitror.TabIndex = 95
        Me.lblPhectolitror.Text = "Peso hectolitro"
        '
        'txtHumedadr
        '
        Me.txtHumedadr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHumedadr.Location = New System.Drawing.Point(462, 116)
        Me.txtHumedadr.Name = "txtHumedadr"
        Me.txtHumedadr.Size = New System.Drawing.Size(171, 20)
        Me.txtHumedadr.TabIndex = 94
        '
        'lblHumedadr
        '
        Me.lblHumedadr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHumedadr.AutoSize = True
        Me.lblHumedadr.Location = New System.Drawing.Point(459, 100)
        Me.lblHumedadr.Name = "lblHumedadr"
        Me.lblHumedadr.Size = New System.Drawing.Size(53, 13)
        Me.lblHumedadr.TabIndex = 93
        Me.lblHumedadr.Text = "Humedad"
        '
        'txtProteinar
        '
        Me.txtProteinar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProteinar.Location = New System.Drawing.Point(462, 73)
        Me.txtProteinar.Name = "txtProteinar"
        Me.txtProteinar.Size = New System.Drawing.Size(171, 20)
        Me.txtProteinar.TabIndex = 92
        '
        'lblProteinar
        '
        Me.lblProteinar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProteinar.AutoSize = True
        Me.lblProteinar.Location = New System.Drawing.Point(459, 57)
        Me.lblProteinar.Name = "lblProteinar"
        Me.lblProteinar.Size = New System.Drawing.Size(48, 13)
        Me.lblProteinar.TabIndex = 91
        Me.lblProteinar.Text = "Proteína"
        '
        'lblResultadoAnalisis
        '
        Me.lblResultadoAnalisis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResultadoAnalisis.AutoSize = True
        Me.lblResultadoAnalisis.Location = New System.Drawing.Point(438, 36)
        Me.lblResultadoAnalisis.Name = "lblResultadoAnalisis"
        Me.lblResultadoAnalisis.Size = New System.Drawing.Size(101, 13)
        Me.lblResultadoAnalisis.TabIndex = 90
        Me.lblResultadoAnalisis.Text = "Estándares del Lote"
        '
        'txtImpurezal
        '
        Me.txtImpurezal.Location = New System.Drawing.Point(116, 201)
        Me.txtImpurezal.Name = "txtImpurezal"
        Me.txtImpurezal.Size = New System.Drawing.Size(171, 20)
        Me.txtImpurezal.TabIndex = 89
        '
        'lblImpurezal
        '
        Me.lblImpurezal.AutoSize = True
        Me.lblImpurezal.Location = New System.Drawing.Point(113, 185)
        Me.lblImpurezal.Name = "lblImpurezal"
        Me.lblImpurezal.Size = New System.Drawing.Size(50, 13)
        Me.lblImpurezal.TabIndex = 88
        Me.lblImpurezal.Text = "Impureza"
        '
        'txtphectolitrol
        '
        Me.txtphectolitrol.Location = New System.Drawing.Point(116, 160)
        Me.txtphectolitrol.Name = "txtphectolitrol"
        Me.txtphectolitrol.Size = New System.Drawing.Size(171, 20)
        Me.txtphectolitrol.TabIndex = 87
        '
        'lblphectolitrol
        '
        Me.lblphectolitrol.AutoSize = True
        Me.lblphectolitrol.Location = New System.Drawing.Point(113, 144)
        Me.lblphectolitrol.Name = "lblphectolitrol"
        Me.lblphectolitrol.Size = New System.Drawing.Size(77, 13)
        Me.lblphectolitrol.TabIndex = 86
        Me.lblphectolitrol.Text = "Peso hectolitro"
        '
        'txtHumedadl
        '
        Me.txtHumedadl.Location = New System.Drawing.Point(116, 116)
        Me.txtHumedadl.Name = "txtHumedadl"
        Me.txtHumedadl.Size = New System.Drawing.Size(171, 20)
        Me.txtHumedadl.TabIndex = 85
        '
        'lblHumedadl
        '
        Me.lblHumedadl.AutoSize = True
        Me.lblHumedadl.Location = New System.Drawing.Point(113, 100)
        Me.lblHumedadl.Name = "lblHumedadl"
        Me.lblHumedadl.Size = New System.Drawing.Size(53, 13)
        Me.lblHumedadl.TabIndex = 84
        Me.lblHumedadl.Text = "Humedad"
        '
        'txtProteinal
        '
        Me.txtProteinal.Location = New System.Drawing.Point(116, 73)
        Me.txtProteinal.Name = "txtProteinal"
        Me.txtProteinal.Size = New System.Drawing.Size(171, 20)
        Me.txtProteinal.TabIndex = 83
        '
        'lblProteinal
        '
        Me.lblProteinal.AutoSize = True
        Me.lblProteinal.Location = New System.Drawing.Point(113, 57)
        Me.lblProteinal.Name = "lblProteinal"
        Me.lblProteinal.Size = New System.Drawing.Size(48, 13)
        Me.lblProteinal.TabIndex = 82
        Me.lblProteinal.Text = "Proteína"
        '
        'lblEstandarLote
        '
        Me.lblEstandarLote.AutoSize = True
        Me.lblEstandarLote.Location = New System.Drawing.Point(92, 36)
        Me.lblEstandarLote.Name = "lblEstandarLote"
        Me.lblEstandarLote.Size = New System.Drawing.Size(101, 13)
        Me.lblEstandarLote.TabIndex = 81
        Me.lblEstandarLote.Text = "Estándares del Lote"
        '
        'chkLaboratorio
        '
        Me.chkLaboratorio.AutoSize = True
        Me.chkLaboratorio.Location = New System.Drawing.Point(69, 16)
        Me.chkLaboratorio.Name = "chkLaboratorio"
        Me.chkLaboratorio.Size = New System.Drawing.Size(135, 17)
        Me.chkLaboratorio.TabIndex = 80
        Me.chkLaboratorio.Text = "Reporte de Laboratorio"
        Me.chkLaboratorio.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(107, 513)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 43
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(22, 513)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 42
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmEmbarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 562)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.tbcEmbarques)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.txtEmbId)
        Me.Controls.Add(Me.lblEmbId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmbarque"
        Me.Text = "Embarque"
        Me.tbcEmbarques.ResumeLayout(False)
        Me.tbpEmbarque.ResumeLayout(False)
        Me.tbpEmbarque.PerformLayout()
        Me.tbpRecepcion.ResumeLayout(False)
        Me.tbpRecepcion.PerformLayout()
        Me.tbpInspeccionTrigo.ResumeLayout(False)
        Me.tbpInspeccionTrigo.PerformLayout()
        Me.tbpInspeccionTransporte.ResumeLayout(False)
        Me.tbpInspeccionTransporte.PerformLayout()
        Me.tbpLaboratorio.ResumeLayout(False)
        Me.tbpLaboratorio.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtEmbId As System.Windows.Forms.TextBox
    Friend WithEvents lblEmbId As System.Windows.Forms.Label
    Friend WithEvents tbcEmbarques As System.Windows.Forms.TabControl
    Friend WithEvents tbpEmbarque As System.Windows.Forms.TabPage
    Friend WithEvents tbpRecepcion As System.Windows.Forms.TabPage
    Friend WithEvents cmdOrden As System.Windows.Forms.Button
    Friend WithEvents lblOrdenId As System.Windows.Forms.Label
    Friend WithEvents txtOrdenId As System.Windows.Forms.TextBox
    Friend WithEvents txtProvFlete As System.Windows.Forms.TextBox
    Friend WithEvents cmdProvFlete As System.Windows.Forms.Button
    Friend WithEvents lblProvFleteId As System.Windows.Forms.Label
    Friend WithEvents txtProvFleteId As System.Windows.Forms.TextBox
    Friend WithEvents txtOrigen As System.Windows.Forms.TextBox
    Friend WithEvents cmdOrigen As System.Windows.Forms.Button
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents txtOrigenId As System.Windows.Forms.TextBox
    Friend WithEvents txtProvTrigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdProvTrigo As System.Windows.Forms.Button
    Friend WithEvents lblProvTrigoId As System.Windows.Forms.Label
    Friend WithEvents txtProvTrigoId As System.Windows.Forms.TextBox
    Friend WithEvents txtTrigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdTrigo As System.Windows.Forms.Button
    Friend WithEvents lblTrigoId As System.Windows.Forms.Label
    Friend WithEvents txtTrigoId As System.Windows.Forms.TextBox
    Friend WithEvents cmbLote As System.Windows.Forms.Button
    Friend WithEvents lblLoteId As System.Windows.Forms.Label
    Friend WithEvents txtLoteId As System.Windows.Forms.TextBox
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaOrden As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEmbarque As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdDstino As System.Windows.Forms.Button
    Friend WithEvents lblDstinoId As System.Windows.Forms.Label
    Friend WithEvents txtDstinoId As System.Windows.Forms.TextBox
    Friend WithEvents txtReftrans As System.Windows.Forms.TextBox
    Friend WithEvents lblReftrans As System.Windows.Forms.Label
    Friend WithEvents lblObgen As System.Windows.Forms.Label
    Friend WithEvents txtObgen As System.Windows.Forms.TextBox
    Friend WithEvents txtSelloe As System.Windows.Forms.TextBox
    Friend WithEvents lblSelloe As System.Windows.Forms.Label
    Friend WithEvents txtFactfl As System.Windows.Forms.TextBox
    Friend WithEvents lblFactfl As System.Windows.Forms.Label
    Friend WithEvents txtPesoEmb As System.Windows.Forms.TextBox
    Friend WithEvents lblPesoEmb As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblDif As System.Windows.Forms.Label
    Friend WithEvents txtPesoRecibido As System.Windows.Forms.TextBox
    Friend WithEvents lblPesoRecibido As System.Windows.Forms.Label
    Friend WithEvents lblFchrec As System.Windows.Forms.Label
    Friend WithEvents dtpFchrec As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSelloRecep As System.Windows.Forms.TextBox
    Friend WithEvents lblSelloRecep As System.Windows.Forms.Label
    Friend WithEvents lblSilos As System.Windows.Forms.Label
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents cmdOperador As System.Windows.Forms.Button
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents txtOperadorId As System.Windows.Forms.TextBox
    Friend WithEvents lblAlertaDif As System.Windows.Forms.Label
    Friend WithEvents tbpInspeccionTrigo As System.Windows.Forms.TabPage
    Friend WithEvents chkCondLimpieza As System.Windows.Forms.CheckBox
    Friend WithEvents txtOtrost As System.Windows.Forms.TextBox
    Friend WithEvents lblOtrost As System.Windows.Forms.Label
    Friend WithEvents txtPlagas As System.Windows.Forms.TextBox
    Friend WithEvents lblPlagas As System.Windows.Forms.Label
    Friend WithEvents txtDaniado As System.Windows.Forms.TextBox
    Friend WithEvents lblDaniado As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtOlor As System.Windows.Forms.TextBox
    Friend WithEvents lblOlor As System.Windows.Forms.Label
    Friend WithEvents tbpInspeccionTransporte As System.Windows.Forms.TabPage
    Friend WithEvents txtServtra As System.Windows.Forms.TextBox
    Friend WithEvents lblServtra As System.Windows.Forms.Label
    Friend WithEvents txtSellosc As System.Windows.Forms.TextBox
    Friend WithEvents lblSellosc As System.Windows.Forms.Label
    Friend WithEvents txtOtrosp As System.Windows.Forms.TextBox
    Friend WithEvents lblOtrosp As System.Windows.Forms.Label
    Friend WithEvents txtLibregra As System.Windows.Forms.TextBox
    Friend WithEvents lblLibregra As System.Windows.Forms.Label
    Friend WithEvents txtLibreba As System.Windows.Forms.TextBox
    Friend WithEvents lblLibreba As System.Windows.Forms.Label
    Friend WithEvents chkCondTransporte As System.Windows.Forms.CheckBox
    Friend WithEvents tbpLaboratorio As System.Windows.Forms.TabPage
    Friend WithEvents txtObslab As System.Windows.Forms.TextBox
    Friend WithEvents lblObslab As System.Windows.Forms.Label
    Friend WithEvents txtImpurezar As System.Windows.Forms.TextBox
    Friend WithEvents lblImpurezar As System.Windows.Forms.Label
    Friend WithEvents txtPhectolitror As System.Windows.Forms.TextBox
    Friend WithEvents lblPhectolitror As System.Windows.Forms.Label
    Friend WithEvents txtHumedadr As System.Windows.Forms.TextBox
    Friend WithEvents lblHumedadr As System.Windows.Forms.Label
    Friend WithEvents txtProteinar As System.Windows.Forms.TextBox
    Friend WithEvents lblProteinar As System.Windows.Forms.Label
    Friend WithEvents lblResultadoAnalisis As System.Windows.Forms.Label
    Friend WithEvents txtImpurezal As System.Windows.Forms.TextBox
    Friend WithEvents lblImpurezal As System.Windows.Forms.Label
    Friend WithEvents txtphectolitrol As System.Windows.Forms.TextBox
    Friend WithEvents lblphectolitrol As System.Windows.Forms.Label
    Friend WithEvents txtHumedadl As System.Windows.Forms.TextBox
    Friend WithEvents lblHumedadl As System.Windows.Forms.Label
    Friend WithEvents txtProteinal As System.Windows.Forms.TextBox
    Friend WithEvents lblProteinal As System.Windows.Forms.Label
    Friend WithEvents lblEstandarLote As System.Windows.Forms.Label
    Friend WithEvents chkLaboratorio As System.Windows.Forms.CheckBox
    Friend WithEvents txtTarifa As System.Windows.Forms.TextBox
    Friend WithEvents lblTarifa As System.Windows.Forms.Label
    Friend WithEvents cmbMonedaId As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonedaId As System.Windows.Forms.Label
    Friend WithEvents lstSilos As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblInformacionEmbarque As System.Windows.Forms.Label
    Friend WithEvents txtPesoembc As System.Windows.Forms.TextBox
    Friend WithEvents lblPesoembc As System.Windows.Forms.Label
    Friend WithEvents txtObservacionestri As TextBox
    Friend WithEvents lblObservacionestri As Label
    Friend WithEvents chkConformetri As CheckBox
    Friend WithEvents txtObservacionestra As TextBox
    Friend WithEvents lblObservacionestra As Label
    Friend WithEvents chkConformetra As CheckBox
End Class
