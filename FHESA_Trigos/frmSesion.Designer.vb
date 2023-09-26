<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSesion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSesion))
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.txtBaseDatos = New System.Windows.Forms.TextBox()
        Me.txtNkname = New System.Windows.Forms.TextBox()
        Me.lblNkname = New System.Windows.Forms.Label()
        Me.txtCntrsnia = New System.Windows.Forms.TextBox()
        Me.lblCntrsnia = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.AutoSize = True
        Me.lblBaseDatos.Location = New System.Drawing.Point(219, 21)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(77, 13)
        Me.lblBaseDatos.TabIndex = 0
        Me.lblBaseDatos.Text = "Base de Datos"
        '
        'txtBaseDatos
        '
        Me.txtBaseDatos.Enabled = False
        Me.txtBaseDatos.Location = New System.Drawing.Point(222, 37)
        Me.txtBaseDatos.Name = "txtBaseDatos"
        Me.txtBaseDatos.Size = New System.Drawing.Size(251, 20)
        Me.txtBaseDatos.TabIndex = 1
        '
        'txtNkname
        '
        Me.txtNkname.AcceptsReturn = True
        Me.txtNkname.Location = New System.Drawing.Point(222, 89)
        Me.txtNkname.Multiline = True
        Me.txtNkname.Name = "txtNkname"
        Me.txtNkname.Size = New System.Drawing.Size(251, 20)
        Me.txtNkname.TabIndex = 3
        '
        'lblNkname
        '
        Me.lblNkname.AutoSize = True
        Me.lblNkname.Location = New System.Drawing.Point(219, 73)
        Me.lblNkname.Name = "lblNkname"
        Me.lblNkname.Size = New System.Drawing.Size(73, 13)
        Me.lblNkname.TabIndex = 2
        Me.lblNkname.Text = "Id. de Usuario"
        '
        'txtCntrsnia
        '
        Me.txtCntrsnia.AcceptsReturn = True
        Me.txtCntrsnia.Location = New System.Drawing.Point(222, 128)
        Me.txtCntrsnia.Multiline = True
        Me.txtCntrsnia.Name = "txtCntrsnia"
        Me.txtCntrsnia.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCntrsnia.Size = New System.Drawing.Size(251, 20)
        Me.txtCntrsnia.TabIndex = 5
        '
        'lblCntrsnia
        '
        Me.lblCntrsnia.AutoSize = True
        Me.lblCntrsnia.Location = New System.Drawing.Point(219, 112)
        Me.lblCntrsnia.Name = "lblCntrsnia"
        Me.lblCntrsnia.Size = New System.Drawing.Size(61, 13)
        Me.lblCntrsnia.TabIndex = 4
        Me.lblCntrsnia.Text = "Contraseña"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(396, 160)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 40
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(311, 160)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 39
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSesion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 202)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtCntrsnia)
        Me.Controls.Add(Me.lblCntrsnia)
        Me.Controls.Add(Me.txtNkname)
        Me.Controls.Add(Me.lblNkname)
        Me.Controls.Add(Me.txtBaseDatos)
        Me.Controls.Add(Me.lblBaseDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSesion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Logística de Trigos - Iniciar Sesión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
    Friend WithEvents txtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents txtNkname As System.Windows.Forms.TextBox
    Friend WithEvents lblNkname As System.Windows.Forms.Label
    Friend WithEvents txtCntrsnia As System.Windows.Forms.TextBox
    Friend WithEvents lblCntrsnia As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
