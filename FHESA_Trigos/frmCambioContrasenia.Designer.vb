<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioContrasenia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioContrasenia))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.txtConfirmarContrasenia = New System.Windows.Forms.TextBox()
        Me.lblConfirmarContrasenia = New System.Windows.Forms.Label()
        Me.txtNuevaContrasenia = New System.Windows.Forms.TextBox()
        Me.lblNuevaContrasenia = New System.Windows.Forms.Label()
        Me.txtContraseniaAnterior = New System.Windows.Forms.TextBox()
        Me.lblContraseniaAnterior = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(340, 148)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 48
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(255, 148)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 47
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'txtConfirmarContrasenia
        '
        Me.txtConfirmarContrasenia.AcceptsReturn = True
        Me.txtConfirmarContrasenia.Location = New System.Drawing.Point(166, 116)
        Me.txtConfirmarContrasenia.Name = "txtConfirmarContrasenia"
        Me.txtConfirmarContrasenia.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarContrasenia.Size = New System.Drawing.Size(251, 20)
        Me.txtConfirmarContrasenia.TabIndex = 46
        '
        'lblConfirmarContrasenia
        '
        Me.lblConfirmarContrasenia.AutoSize = True
        Me.lblConfirmarContrasenia.Location = New System.Drawing.Point(163, 100)
        Me.lblConfirmarContrasenia.Name = "lblConfirmarContrasenia"
        Me.lblConfirmarContrasenia.Size = New System.Drawing.Size(108, 13)
        Me.lblConfirmarContrasenia.TabIndex = 45
        Me.lblConfirmarContrasenia.Text = "Confirmar Contraseña"
        '
        'txtNuevaContrasenia
        '
        Me.txtNuevaContrasenia.AcceptsReturn = True
        Me.txtNuevaContrasenia.Location = New System.Drawing.Point(166, 77)
        Me.txtNuevaContrasenia.Name = "txtNuevaContrasenia"
        Me.txtNuevaContrasenia.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevaContrasenia.Size = New System.Drawing.Size(251, 20)
        Me.txtNuevaContrasenia.TabIndex = 44
        '
        'lblNuevaContrasenia
        '
        Me.lblNuevaContrasenia.AutoSize = True
        Me.lblNuevaContrasenia.Location = New System.Drawing.Point(163, 61)
        Me.lblNuevaContrasenia.Name = "lblNuevaContrasenia"
        Me.lblNuevaContrasenia.Size = New System.Drawing.Size(96, 13)
        Me.lblNuevaContrasenia.TabIndex = 43
        Me.lblNuevaContrasenia.Text = "Nueva Contraseña"
        '
        'txtContraseniaAnterior
        '
        Me.txtContraseniaAnterior.Location = New System.Drawing.Point(166, 25)
        Me.txtContraseniaAnterior.Name = "txtContraseniaAnterior"
        Me.txtContraseniaAnterior.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseniaAnterior.Size = New System.Drawing.Size(251, 20)
        Me.txtContraseniaAnterior.TabIndex = 42
        '
        'lblContraseniaAnterior
        '
        Me.lblContraseniaAnterior.AutoSize = True
        Me.lblContraseniaAnterior.Location = New System.Drawing.Point(163, 9)
        Me.lblContraseniaAnterior.Name = "lblContraseniaAnterior"
        Me.lblContraseniaAnterior.Size = New System.Drawing.Size(100, 13)
        Me.lblContraseniaAnterior.TabIndex = 41
        Me.lblContraseniaAnterior.Text = "Contraseña Anterior"
        '
        'frmCambioContrasenia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 194)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtConfirmarContrasenia)
        Me.Controls.Add(Me.lblConfirmarContrasenia)
        Me.Controls.Add(Me.txtNuevaContrasenia)
        Me.Controls.Add(Me.lblNuevaContrasenia)
        Me.Controls.Add(Me.txtContraseniaAnterior)
        Me.Controls.Add(Me.lblContraseniaAnterior)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioContrasenia"
        Me.Text = "Cambiar Contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtConfirmarContrasenia As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmarContrasenia As System.Windows.Forms.Label
    Friend WithEvents txtNuevaContrasenia As System.Windows.Forms.TextBox
    Friend WithEvents lblNuevaContrasenia As System.Windows.Forms.Label
    Friend WithEvents txtContraseniaAnterior As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseniaAnterior As System.Windows.Forms.Label
End Class
