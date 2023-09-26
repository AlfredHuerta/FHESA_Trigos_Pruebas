<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHistorial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorial))
        Me.grdHistorial = New System.Windows.Forms.DataGridView()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.lblListaCambios = New System.Windows.Forms.Label()
        Me.grdDetalleCambios = New System.Windows.Forms.DataGridView()
        Me.lblDetalleCambios = New System.Windows.Forms.Label()
        CType(Me.grdHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdHistorial
        '
        Me.grdHistorial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdHistorial.Location = New System.Drawing.Point(23, 40)
        Me.grdHistorial.Name = "grdHistorial"
        Me.grdHistorial.Size = New System.Drawing.Size(726, 214)
        Me.grdHistorial.TabIndex = 0
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(23, 462)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 39
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'lblListaCambios
        '
        Me.lblListaCambios.AutoSize = True
        Me.lblListaCambios.Location = New System.Drawing.Point(20, 24)
        Me.lblListaCambios.Name = "lblListaCambios"
        Me.lblListaCambios.Size = New System.Drawing.Size(55, 13)
        Me.lblListaCambios.TabIndex = 41
        Me.lblListaCambios.Text = "Instancias"
        '
        'grdDetalleCambios
        '
        Me.grdDetalleCambios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalleCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalleCambios.Location = New System.Drawing.Point(23, 285)
        Me.grdDetalleCambios.Name = "grdDetalleCambios"
        Me.grdDetalleCambios.Size = New System.Drawing.Size(726, 159)
        Me.grdDetalleCambios.TabIndex = 42
        '
        'lblDetalleCambios
        '
        Me.lblDetalleCambios.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDetalleCambios.AutoSize = True
        Me.lblDetalleCambios.Location = New System.Drawing.Point(20, 269)
        Me.lblDetalleCambios.Name = "lblDetalleCambios"
        Me.lblDetalleCambios.Size = New System.Drawing.Size(128, 13)
        Me.lblDetalleCambios.TabIndex = 43
        Me.lblDetalleCambios.Text = "Detalle de modificaciones"
        '
        'frmHistorial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 504)
        Me.Controls.Add(Me.lblDetalleCambios)
        Me.Controls.Add(Me.grdDetalleCambios)
        Me.Controls.Add(Me.lblListaCambios)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grdHistorial)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHistorial"
        Me.Text = "frmHistorial"
        CType(Me.grdHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleCambios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdHistorial As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblListaCambios As System.Windows.Forms.Label
    Friend WithEvents grdDetalleCambios As System.Windows.Forms.DataGridView
    Friend WithEvents lblDetalleCambios As System.Windows.Forms.Label
End Class
