<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjuste
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjuste))
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblFechaAjuste = New System.Windows.Forms.Label()
        Me.dtpFechaAjuste = New System.Windows.Forms.DateTimePicker()
        Me.txtAjustId = New System.Windows.Forms.TextBox()
        Me.lblAjustId = New System.Windows.Forms.Label()
        Me.gpbGeneral = New System.Windows.Forms.GroupBox()
        Me.lblObgen = New System.Windows.Forms.Label()
        Me.txtObsrv = New System.Windows.Forms.TextBox()
        Me.txtMerma3 = New System.Windows.Forms.TextBox()
        Me.lblMerma3 = New System.Windows.Forms.Label()
        Me.txtMerma2 = New System.Windows.Forms.TextBox()
        Me.lblMerma2 = New System.Windows.Forms.Label()
        Me.txtMerma1 = New System.Windows.Forms.TextBox()
        Me.lblMerma1 = New System.Windows.Forms.Label()
        Me.txtCompensa = New System.Windows.Forms.TextBox()
        Me.lblCompensa = New System.Windows.Forms.Label()
        Me.cmdOrden = New System.Windows.Forms.Button()
        Me.lblOrdenId = New System.Windows.Forms.Label()
        Me.txtOrdenId = New System.Windows.Forms.TextBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gpbGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(541, 19)
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
        Me.cmbEstado.Location = New System.Drawing.Point(544, 35)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(109, 21)
        Me.cmbEstado.TabIndex = 11
        '
        'lblFechaAjuste
        '
        Me.lblFechaAjuste.AutoSize = True
        Me.lblFechaAjuste.Location = New System.Drawing.Point(14, 44)
        Me.lblFechaAjuste.Name = "lblFechaAjuste"
        Me.lblFechaAjuste.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaAjuste.TabIndex = 8
        Me.lblFechaAjuste.Text = "Fecha"
        '
        'dtpFechaAjuste
        '
        Me.dtpFechaAjuste.Checked = False
        Me.dtpFechaAjuste.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAjuste.Location = New System.Drawing.Point(57, 38)
        Me.dtpFechaAjuste.Name = "dtpFechaAjuste"
        Me.dtpFechaAjuste.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaAjuste.TabIndex = 9
        '
        'txtAjustId
        '
        Me.txtAjustId.AcceptsReturn = True
        Me.txtAjustId.Location = New System.Drawing.Point(57, 12)
        Me.txtAjustId.Multiline = True
        Me.txtAjustId.Name = "txtAjustId"
        Me.txtAjustId.Size = New System.Drawing.Size(109, 20)
        Me.txtAjustId.TabIndex = 7
        '
        'lblAjustId
        '
        Me.lblAjustId.AutoSize = True
        Me.lblAjustId.Location = New System.Drawing.Point(32, 15)
        Me.lblAjustId.Name = "lblAjustId"
        Me.lblAjustId.Size = New System.Drawing.Size(19, 13)
        Me.lblAjustId.TabIndex = 6
        Me.lblAjustId.Text = "Nº"
        '
        'gpbGeneral
        '
        Me.gpbGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbGeneral.Controls.Add(Me.lblObgen)
        Me.gpbGeneral.Controls.Add(Me.txtObsrv)
        Me.gpbGeneral.Controls.Add(Me.txtMerma3)
        Me.gpbGeneral.Controls.Add(Me.lblMerma3)
        Me.gpbGeneral.Controls.Add(Me.txtMerma2)
        Me.gpbGeneral.Controls.Add(Me.lblMerma2)
        Me.gpbGeneral.Controls.Add(Me.txtMerma1)
        Me.gpbGeneral.Controls.Add(Me.lblMerma1)
        Me.gpbGeneral.Controls.Add(Me.txtCompensa)
        Me.gpbGeneral.Controls.Add(Me.lblCompensa)
        Me.gpbGeneral.Controls.Add(Me.cmdOrden)
        Me.gpbGeneral.Controls.Add(Me.lblOrdenId)
        Me.gpbGeneral.Controls.Add(Me.txtOrdenId)
        Me.gpbGeneral.Location = New System.Drawing.Point(17, 83)
        Me.gpbGeneral.Name = "gpbGeneral"
        Me.gpbGeneral.Size = New System.Drawing.Size(636, 278)
        Me.gpbGeneral.TabIndex = 12
        Me.gpbGeneral.TabStop = False
        Me.gpbGeneral.Text = "General"
        '
        'lblObgen
        '
        Me.lblObgen.AutoSize = True
        Me.lblObgen.Location = New System.Drawing.Point(20, 142)
        Me.lblObgen.Name = "lblObgen"
        Me.lblObgen.Size = New System.Drawing.Size(78, 13)
        Me.lblObgen.TabIndex = 46
        Me.lblObgen.Text = "Observaciones"
        '
        'txtObsrv
        '
        Me.txtObsrv.AcceptsReturn = True
        Me.txtObsrv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObsrv.Location = New System.Drawing.Point(23, 158)
        Me.txtObsrv.Multiline = True
        Me.txtObsrv.Name = "txtObsrv"
        Me.txtObsrv.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsrv.Size = New System.Drawing.Size(592, 102)
        Me.txtObsrv.TabIndex = 47
        '
        'txtMerma3
        '
        Me.txtMerma3.Location = New System.Drawing.Point(433, 110)
        Me.txtMerma3.Name = "txtMerma3"
        Me.txtMerma3.Size = New System.Drawing.Size(182, 20)
        Me.txtMerma3.TabIndex = 45
        '
        'lblMerma3
        '
        Me.lblMerma3.AutoSize = True
        Me.lblMerma3.Location = New System.Drawing.Point(430, 94)
        Me.lblMerma3.Name = "lblMerma3"
        Me.lblMerma3.Size = New System.Drawing.Size(48, 13)
        Me.lblMerma3.TabIndex = 44
        Me.lblMerma3.Text = "Merma 3"
        '
        'txtMerma2
        '
        Me.txtMerma2.Location = New System.Drawing.Point(227, 110)
        Me.txtMerma2.Name = "txtMerma2"
        Me.txtMerma2.Size = New System.Drawing.Size(187, 20)
        Me.txtMerma2.TabIndex = 43
        '
        'lblMerma2
        '
        Me.lblMerma2.AutoSize = True
        Me.lblMerma2.Location = New System.Drawing.Point(224, 94)
        Me.lblMerma2.Name = "lblMerma2"
        Me.lblMerma2.Size = New System.Drawing.Size(48, 13)
        Me.lblMerma2.TabIndex = 42
        Me.lblMerma2.Text = "Merma 2"
        '
        'txtMerma1
        '
        Me.txtMerma1.Location = New System.Drawing.Point(23, 110)
        Me.txtMerma1.Name = "txtMerma1"
        Me.txtMerma1.Size = New System.Drawing.Size(187, 20)
        Me.txtMerma1.TabIndex = 41
        '
        'lblMerma1
        '
        Me.lblMerma1.AutoSize = True
        Me.lblMerma1.Location = New System.Drawing.Point(20, 94)
        Me.lblMerma1.Name = "lblMerma1"
        Me.lblMerma1.Size = New System.Drawing.Size(48, 13)
        Me.lblMerma1.TabIndex = 40
        Me.lblMerma1.Text = "Merma 1"
        '
        'txtCompensa
        '
        Me.txtCompensa.Location = New System.Drawing.Point(23, 71)
        Me.txtCompensa.Name = "txtCompensa"
        Me.txtCompensa.Size = New System.Drawing.Size(187, 20)
        Me.txtCompensa.TabIndex = 39
        '
        'lblCompensa
        '
        Me.lblCompensa.AutoSize = True
        Me.lblCompensa.Location = New System.Drawing.Point(20, 55)
        Me.lblCompensa.Name = "lblCompensa"
        Me.lblCompensa.Size = New System.Drawing.Size(77, 13)
        Me.lblCompensa.TabIndex = 38
        Me.lblCompensa.Text = "Compensación"
        '
        'cmdOrden
        '
        Me.cmdOrden.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdOrden.FlatAppearance.BorderSize = 0
        Me.cmdOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOrden.Location = New System.Drawing.Point(23, 29)
        Me.cmdOrden.Name = "cmdOrden"
        Me.cmdOrden.Size = New System.Drawing.Size(23, 23)
        Me.cmdOrden.TabIndex = 9
        Me.cmdOrden.Text = ">>"
        Me.cmdOrden.UseVisualStyleBackColor = True
        '
        'lblOrdenId
        '
        Me.lblOrdenId.AutoSize = True
        Me.lblOrdenId.Location = New System.Drawing.Point(52, 16)
        Me.lblOrdenId.Name = "lblOrdenId"
        Me.lblOrdenId.Size = New System.Drawing.Size(36, 13)
        Me.lblOrdenId.TabIndex = 10
        Me.lblOrdenId.Text = "Orden"
        '
        'txtOrdenId
        '
        Me.txtOrdenId.AcceptsReturn = True
        Me.txtOrdenId.AcceptsTab = True
        Me.txtOrdenId.Location = New System.Drawing.Point(51, 32)
        Me.txtOrdenId.Multiline = True
        Me.txtOrdenId.Name = "txtOrdenId"
        Me.txtOrdenId.Size = New System.Drawing.Size(159, 20)
        Me.txtOrdenId.TabIndex = 11
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(102, 381)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 45
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(17, 381)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 44
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmAjuste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 419)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbGeneral)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.lblFechaAjuste)
        Me.Controls.Add(Me.dtpFechaAjuste)
        Me.Controls.Add(Me.txtAjustId)
        Me.Controls.Add(Me.lblAjustId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAjuste"
        Me.Text = "Ajustes"
        Me.gpbGeneral.ResumeLayout(False)
        Me.gpbGeneral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaAjuste As System.Windows.Forms.Label
    Friend WithEvents dtpFechaAjuste As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAjustId As System.Windows.Forms.TextBox
    Friend WithEvents lblAjustId As System.Windows.Forms.Label
    Friend WithEvents gpbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOrden As System.Windows.Forms.Button
    Friend WithEvents lblOrdenId As System.Windows.Forms.Label
    Friend WithEvents txtOrdenId As System.Windows.Forms.TextBox
    Friend WithEvents txtMerma3 As System.Windows.Forms.TextBox
    Friend WithEvents lblMerma3 As System.Windows.Forms.Label
    Friend WithEvents txtMerma2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMerma2 As System.Windows.Forms.Label
    Friend WithEvents txtMerma1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMerma1 As System.Windows.Forms.Label
    Friend WithEvents txtCompensa As System.Windows.Forms.TextBox
    Friend WithEvents lblCompensa As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblObgen As System.Windows.Forms.Label
    Friend WithEvents txtObsrv As System.Windows.Forms.TextBox
End Class
