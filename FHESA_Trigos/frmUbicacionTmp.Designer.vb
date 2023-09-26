<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUbicacionTmp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUbicacionTmp))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtUbcTmpId = New System.Windows.Forms.TextBox()
        Me.lblUbcTmpId = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(153, 171)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(112, 35)
        Me.cmdCancelar.TabIndex = 20
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(26, 171)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(112, 35)
        Me.cmdAceptar.TabIndex = 19
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(26, 100)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(538, 26)
        Me.txtNombre.TabIndex = 18
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(26, 75)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(65, 20)
        Me.lblNombre.TabIndex = 17
        Me.lblNombre.Text = "Nombre"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(482, 25)
        Me.chkActivo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(78, 24)
        Me.chkActivo.TabIndex = 16
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtUbcTmpId
        '
        Me.txtUbcTmpId.AcceptsReturn = True
        Me.txtUbcTmpId.Location = New System.Drawing.Point(78, 20)
        Me.txtUbcTmpId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUbcTmpId.Multiline = True
        Me.txtUbcTmpId.Name = "txtUbcTmpId"
        Me.txtUbcTmpId.Size = New System.Drawing.Size(148, 29)
        Me.txtUbcTmpId.TabIndex = 15
        '
        'lblUbcTmpId
        '
        Me.lblUbcTmpId.AutoSize = True
        Me.lblUbcTmpId.Location = New System.Drawing.Point(26, 25)
        Me.lblUbcTmpId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUbcTmpId.Name = "lblUbcTmpId"
        Me.lblUbcTmpId.Size = New System.Drawing.Size(26, 20)
        Me.lblUbcTmpId.TabIndex = 14
        Me.lblUbcTmpId.Text = "Nº"
        '
        'frmUbicacionTmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 226)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtUbcTmpId)
        Me.Controls.Add(Me.lblUbcTmpId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmUbicacionTmp"
        Me.Text = "frmUbicacionTmp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtUbcTmpId As System.Windows.Forms.TextBox
    Friend WithEvents lblUbcTmpId As System.Windows.Forms.Label
End Class
