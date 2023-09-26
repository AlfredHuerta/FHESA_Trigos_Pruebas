<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConexion))
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.txtlogin = New System.Windows.Forms.TextBox()
        Me.txtContrasenia = New System.Windows.Forms.TextBox()
        Me.lblContrasenia = New System.Windows.Forms.Label()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.lblServidor = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtBaseDatos = New System.Windows.Forms.TextBox()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.txtTiempoEspera = New System.Windows.Forms.TextBox()
        Me.lblTiempoEspera = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(12, 88)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(33, 13)
        Me.lblLogin.TabIndex = 6
        Me.lblLogin.Text = "Login"
        '
        'txtlogin
        '
        Me.txtlogin.Location = New System.Drawing.Point(15, 108)
        Me.txtlogin.Name = "txtlogin"
        Me.txtlogin.Size = New System.Drawing.Size(212, 20)
        Me.txtlogin.TabIndex = 7
        '
        'txtContrasenia
        '
        Me.txtContrasenia.Location = New System.Drawing.Point(15, 151)
        Me.txtContrasenia.Name = "txtContrasenia"
        Me.txtContrasenia.Size = New System.Drawing.Size(212, 20)
        Me.txtContrasenia.TabIndex = 9
        Me.txtContrasenia.UseSystemPasswordChar = True
        '
        'lblContrasenia
        '
        Me.lblContrasenia.AutoSize = True
        Me.lblContrasenia.Location = New System.Drawing.Point(12, 135)
        Me.lblContrasenia.Name = "lblContrasenia"
        Me.lblContrasenia.Size = New System.Drawing.Size(61, 13)
        Me.lblContrasenia.TabIndex = 8
        Me.lblContrasenia.Text = "Contraseña"
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(15, 25)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.Size = New System.Drawing.Size(212, 20)
        Me.txtServidor.TabIndex = 1
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Location = New System.Drawing.Point(12, 9)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(70, 13)
        Me.lblServidor.TabIndex = 0
        Me.lblServidor.Text = "Servidor SQL"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(243, 25)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 10
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(243, 62)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 11
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'txtBaseDatos
        '
        Me.txtBaseDatos.Location = New System.Drawing.Point(15, 64)
        Me.txtBaseDatos.Name = "txtBaseDatos"
        Me.txtBaseDatos.Size = New System.Drawing.Size(131, 20)
        Me.txtBaseDatos.TabIndex = 4
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.AutoSize = True
        Me.lblBaseDatos.Location = New System.Drawing.Point(12, 48)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(77, 13)
        Me.lblBaseDatos.TabIndex = 2
        Me.lblBaseDatos.Text = "Base de Datos"
        '
        'txtTiempoEspera
        '
        Me.txtTiempoEspera.Location = New System.Drawing.Point(155, 64)
        Me.txtTiempoEspera.Name = "txtTiempoEspera"
        Me.txtTiempoEspera.Size = New System.Drawing.Size(72, 20)
        Me.txtTiempoEspera.TabIndex = 5
        '
        'lblTiempoEspera
        '
        Me.lblTiempoEspera.AutoSize = True
        Me.lblTiempoEspera.Location = New System.Drawing.Point(152, 48)
        Me.lblTiempoEspera.Name = "lblTiempoEspera"
        Me.lblTiempoEspera.Size = New System.Drawing.Size(55, 13)
        Me.lblTiempoEspera.TabIndex = 3
        Me.lblTiempoEspera.Text = "Tiempo E."
        '
        'frmConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 183)
        Me.Controls.Add(Me.txtTiempoEspera)
        Me.Controls.Add(Me.lblTiempoEspera)
        Me.Controls.Add(Me.txtBaseDatos)
        Me.Controls.Add(Me.lblBaseDatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.lblServidor)
        Me.Controls.Add(Me.txtContrasenia)
        Me.Controls.Add(Me.lblContrasenia)
        Me.Controls.Add(Me.txtlogin)
        Me.Controls.Add(Me.lblLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConexion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Parámetros de Conexión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents txtlogin As System.Windows.Forms.TextBox
    Friend WithEvents txtContrasenia As System.Windows.Forms.TextBox
    Friend WithEvents lblContrasenia As System.Windows.Forms.Label
    Friend WithEvents txtServidor As System.Windows.Forms.TextBox
    Friend WithEvents lblServidor As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents txtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
    Friend WithEvents txtTiempoEspera As System.Windows.Forms.TextBox
    Friend WithEvents lblTiempoEspera As System.Windows.Forms.Label
End Class
