<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportes))
        Me.lblReportesDisponibles = New System.Windows.Forms.Label()
        Me.dgvReportes = New System.Windows.Forms.DataGridView()
        Me.gpbParametros = New System.Windows.Forms.GroupBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        CType(Me.dgvReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblReportesDisponibles
        '
        Me.lblReportesDisponibles.AutoSize = True
        Me.lblReportesDisponibles.Location = New System.Drawing.Point(26, 22)
        Me.lblReportesDisponibles.Name = "lblReportesDisponibles"
        Me.lblReportesDisponibles.Size = New System.Drawing.Size(111, 13)
        Me.lblReportesDisponibles.TabIndex = 0
        Me.lblReportesDisponibles.Text = "Listado de disponibles"
        '
        'dgvReportes
        '
        Me.dgvReportes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportes.Location = New System.Drawing.Point(29, 38)
        Me.dgvReportes.Name = "dgvReportes"
        Me.dgvReportes.Size = New System.Drawing.Size(308, 344)
        Me.dgvReportes.TabIndex = 1
        '
        'gpbParametros
        '
        Me.gpbParametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbParametros.Location = New System.Drawing.Point(367, 38)
        Me.gpbParametros.Name = "gpbParametros"
        Me.gpbParametros.Size = New System.Drawing.Size(240, 315)
        Me.gpbParametros.TabIndex = 2
        Me.gpbParametros.TabStop = False
        Me.gpbParametros.Text = "Parámetros de selección"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(452, 359)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(367, 359)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 14
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 405)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbParametros)
        Me.Controls.Add(Me.dgvReportes)
        Me.Controls.Add(Me.lblReportesDisponibles)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportes"
        Me.Text = "Reportes del Sistema"
        CType(Me.dgvReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReportesDisponibles As System.Windows.Forms.Label
    Friend WithEvents dgvReportes As System.Windows.Forms.DataGridView
    Friend WithEvents gpbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
