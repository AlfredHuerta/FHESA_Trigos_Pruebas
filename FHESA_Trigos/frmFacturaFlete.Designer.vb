<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaFlete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaFlete))
        Me.grdEmbarques = New System.Windows.Forms.DataGridView()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdRefrescar = New System.Windows.Forms.Button()
        CType(Me.grdEmbarques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdEmbarques
        '
        Me.grdEmbarques.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmbarques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdEmbarques.Location = New System.Drawing.Point(12, 12)
        Me.grdEmbarques.Name = "grdEmbarques"
        Me.grdEmbarques.Size = New System.Drawing.Size(819, 282)
        Me.grdEmbarques.TabIndex = 0
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCerrar.Location = New System.Drawing.Point(90, 310)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCerrar.TabIndex = 46
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdRefrescar
        '
        Me.cmdRefrescar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdRefrescar.Location = New System.Drawing.Point(9, 310)
        Me.cmdRefrescar.Name = "cmdRefrescar"
        Me.cmdRefrescar.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefrescar.TabIndex = 47
        Me.cmdRefrescar.Text = "Actualizar"
        Me.cmdRefrescar.UseVisualStyleBackColor = True
        '
        'frmFacturaFlete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 354)
        Me.Controls.Add(Me.cmdRefrescar)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.grdEmbarques)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFacturaFlete"
        Me.Text = "Factura Flete: Actualización masiva"
        CType(Me.grdEmbarques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdEmbarques As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdRefrescar As System.Windows.Forms.Button
End Class
