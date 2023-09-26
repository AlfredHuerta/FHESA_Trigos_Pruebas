<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVenta))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gpbGeneral = New System.Windows.Forms.GroupBox()
        Me.lblObgen = New System.Windows.Forms.Label()
        Me.txtObsrv = New System.Windows.Forms.TextBox()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.lblVenta = New System.Windows.Forms.Label()
        Me.cmdOrden = New System.Windows.Forms.Button()
        Me.lblOrdenId = New System.Windows.Forms.Label()
        Me.txtOrdenId = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblFechaAjuste = New System.Windows.Forms.Label()
        Me.dtpFechaVenta = New System.Windows.Forms.DateTimePicker()
        Me.txtVentaId = New System.Windows.Forms.TextBox()
        Me.lblVentaId = New System.Windows.Forms.Label()
        Me.gpbGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(112, 317)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 54
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(27, 317)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 53
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'gpbGeneral
        '
        Me.gpbGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbGeneral.Controls.Add(Me.lblObgen)
        Me.gpbGeneral.Controls.Add(Me.txtObsrv)
        Me.gpbGeneral.Controls.Add(Me.txtVenta)
        Me.gpbGeneral.Controls.Add(Me.lblVenta)
        Me.gpbGeneral.Controls.Add(Me.cmdOrden)
        Me.gpbGeneral.Controls.Add(Me.lblOrdenId)
        Me.gpbGeneral.Controls.Add(Me.txtOrdenId)
        Me.gpbGeneral.Location = New System.Drawing.Point(27, 88)
        Me.gpbGeneral.Name = "gpbGeneral"
        Me.gpbGeneral.Size = New System.Drawing.Size(454, 213)
        Me.gpbGeneral.TabIndex = 52
        Me.gpbGeneral.TabStop = False
        Me.gpbGeneral.Text = "General"
        '
        'lblObgen
        '
        Me.lblObgen.AutoSize = True
        Me.lblObgen.Location = New System.Drawing.Point(20, 73)
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
        Me.txtObsrv.Location = New System.Drawing.Point(23, 89)
        Me.txtObsrv.Multiline = True
        Me.txtObsrv.Name = "txtObsrv"
        Me.txtObsrv.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObsrv.Size = New System.Drawing.Size(405, 110)
        Me.txtObsrv.TabIndex = 47
        '
        'txtVenta
        '
        Me.txtVenta.Location = New System.Drawing.Point(241, 32)
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.Size = New System.Drawing.Size(187, 20)
        Me.txtVenta.TabIndex = 39
        '
        'lblVenta
        '
        Me.lblVenta.AutoSize = True
        Me.lblVenta.Location = New System.Drawing.Point(238, 16)
        Me.lblVenta.Name = "lblVenta"
        Me.lblVenta.Size = New System.Drawing.Size(104, 13)
        Me.lblVenta.TabIndex = 38
        Me.lblVenta.Text = "Toneladas Vendidas"
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
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(368, 24)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 50
        Me.lblEstado.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(371, 40)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(109, 21)
        Me.cmbEstado.TabIndex = 51
        '
        'lblFechaAjuste
        '
        Me.lblFechaAjuste.AutoSize = True
        Me.lblFechaAjuste.Location = New System.Drawing.Point(24, 49)
        Me.lblFechaAjuste.Name = "lblFechaAjuste"
        Me.lblFechaAjuste.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaAjuste.TabIndex = 48
        Me.lblFechaAjuste.Text = "Fecha"
        '
        'dtpFechaVenta
        '
        Me.dtpFechaVenta.Checked = False
        Me.dtpFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVenta.Location = New System.Drawing.Point(67, 43)
        Me.dtpFechaVenta.Name = "dtpFechaVenta"
        Me.dtpFechaVenta.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaVenta.TabIndex = 49
        '
        'txtVentaId
        '
        Me.txtVentaId.AcceptsReturn = True
        Me.txtVentaId.Location = New System.Drawing.Point(67, 17)
        Me.txtVentaId.Multiline = True
        Me.txtVentaId.Name = "txtVentaId"
        Me.txtVentaId.Size = New System.Drawing.Size(109, 20)
        Me.txtVentaId.TabIndex = 47
        '
        'lblVentaId
        '
        Me.lblVentaId.AutoSize = True
        Me.lblVentaId.Location = New System.Drawing.Point(42, 20)
        Me.lblVentaId.Name = "lblVentaId"
        Me.lblVentaId.Size = New System.Drawing.Size(19, 13)
        Me.lblVentaId.TabIndex = 46
        Me.lblVentaId.Text = "Nº"
        '
        'frmVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 356)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbGeneral)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.lblFechaAjuste)
        Me.Controls.Add(Me.dtpFechaVenta)
        Me.Controls.Add(Me.txtVentaId)
        Me.Controls.Add(Me.lblVentaId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVenta"
        Me.Text = "Venta"
        Me.gpbGeneral.ResumeLayout(False)
        Me.gpbGeneral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents gpbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents lblObgen As System.Windows.Forms.Label
    Friend WithEvents txtObsrv As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents lblVenta As System.Windows.Forms.Label
    Friend WithEvents cmdOrden As System.Windows.Forms.Button
    Friend WithEvents lblOrdenId As System.Windows.Forms.Label
    Friend WithEvents txtOrdenId As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblFechaAjuste As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtVentaId As System.Windows.Forms.TextBox
    Friend WithEvents lblVentaId As System.Windows.Forms.Label
End Class
