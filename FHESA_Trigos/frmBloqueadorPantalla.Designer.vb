<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBloqueadorPantalla
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
        Me.lblContrasenia = New System.Windows.Forms.Label()
        Me.txtContrasenia = New System.Windows.Forms.TextBox()
        Me.cmbDesbloquear = New System.Windows.Forms.Button()
        Me.lblBloqueadoPor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblContrasenia
        '
        Me.lblContrasenia.AutoSize = True
        Me.lblContrasenia.BackColor = System.Drawing.Color.Transparent
        Me.lblContrasenia.Location = New System.Drawing.Point(12, 226)
        Me.lblContrasenia.Name = "lblContrasenia"
        Me.lblContrasenia.Size = New System.Drawing.Size(61, 13)
        Me.lblContrasenia.TabIndex = 0
        Me.lblContrasenia.Text = "Contraseña"
        '
        'txtContrasenia
        '
        Me.txtContrasenia.AcceptsReturn = True
        Me.txtContrasenia.Location = New System.Drawing.Point(15, 242)
        Me.txtContrasenia.Multiline = True
        Me.txtContrasenia.Name = "txtContrasenia"
        Me.txtContrasenia.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasenia.Size = New System.Drawing.Size(218, 20)
        Me.txtContrasenia.TabIndex = 1
        '
        'cmbDesbloquear
        '
        Me.cmbDesbloquear.Location = New System.Drawing.Point(239, 240)
        Me.cmbDesbloquear.Name = "cmbDesbloquear"
        Me.cmbDesbloquear.Size = New System.Drawing.Size(46, 23)
        Me.cmbDesbloquear.TabIndex = 2
        Me.cmbDesbloquear.Text = "->"
        Me.cmbDesbloquear.UseVisualStyleBackColor = True
        '
        'lblBloqueadoPor
        '
        Me.lblBloqueadoPor.BackColor = System.Drawing.Color.Transparent
        Me.lblBloqueadoPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBloqueadoPor.Location = New System.Drawing.Point(12, 9)
        Me.lblBloqueadoPor.Name = "lblBloqueadoPor"
        Me.lblBloqueadoPor.Size = New System.Drawing.Size(287, 118)
        Me.lblBloqueadoPor.TabIndex = 3
        Me.lblBloqueadoPor.Text = "Bloqueado por..."
        '
        'frmBloqueadorPantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(297, 294)
        Me.Controls.Add(Me.lblBloqueadoPor)
        Me.Controls.Add(Me.cmbDesbloquear)
        Me.Controls.Add(Me.txtContrasenia)
        Me.Controls.Add(Me.lblContrasenia)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBloqueadorPantalla"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmBloqueadorPantalla"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblContrasenia As System.Windows.Forms.Label
    Friend WithEvents txtContrasenia As System.Windows.Forms.TextBox
    Friend WithEvents cmbDesbloquear As System.Windows.Forms.Button
    Friend WithEvents lblBloqueadoPor As System.Windows.Forms.Label
End Class
