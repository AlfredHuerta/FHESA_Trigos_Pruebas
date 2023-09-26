<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtUsrId = New System.Windows.Forms.TextBox()
        Me.lblUsrId = New System.Windows.Forms.Label()
        Me.gpbGeneral = New System.Windows.Forms.GroupBox()
        Me.txtConfirmarContrasenia = New System.Windows.Forms.TextBox()
        Me.lblConfirmarContrasenia = New System.Windows.Forms.Label()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.lblOperadorId = New System.Windows.Forms.Label()
        Me.cmbPerfil = New System.Windows.Forms.ComboBox()
        Me.lblPerfil = New System.Windows.Forms.Label()
        Me.cmbPuestoId = New System.Windows.Forms.ComboBox()
        Me.lblPuestoId = New System.Windows.Forms.Label()
        Me.txtCntrsenia = New System.Windows.Forms.TextBox()
        Me.lblCntrsenia = New System.Windows.Forms.Label()
        Me.txtApllidom = New System.Windows.Forms.TextBox()
        Me.lblApllidom = New System.Windows.Forms.Label()
        Me.txtApllidop = New System.Windows.Forms.TextBox()
        Me.lblApllidop = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNkName = New System.Windows.Forms.TextBox()
        Me.lblNkName = New System.Windows.Forms.Label()
        Me.gpbCorreo = New System.Windows.Forms.GroupBox()
        Me.txtConfContraseiaCuentaCorreo = New System.Windows.Forms.TextBox()
        Me.lblConfContraseiaCuentaCorreo = New System.Windows.Forms.Label()
        Me.txtContraseniaCuentaCorreo = New System.Windows.Forms.TextBox()
        Me.lblContraseiaCuentaCorreo = New System.Windows.Forms.Label()
        Me.txtCuentaCorreo = New System.Windows.Forms.TextBox()
        Me.lblCuentaCorreo = New System.Windows.Forms.Label()
        Me.cmbSmtpId = New System.Windows.Forms.ComboBox()
        Me.lblSmtpId = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gpbGeneral.SuspendLayout()
        Me.gpbCorreo.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(629, 29)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 2
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtUsrId
        '
        Me.txtUsrId.AcceptsReturn = True
        Me.txtUsrId.Location = New System.Drawing.Point(56, 26)
        Me.txtUsrId.Multiline = True
        Me.txtUsrId.Name = "txtUsrId"
        Me.txtUsrId.Size = New System.Drawing.Size(100, 20)
        Me.txtUsrId.TabIndex = 1
        '
        'lblUsrId
        '
        Me.lblUsrId.AutoSize = True
        Me.lblUsrId.Location = New System.Drawing.Point(21, 29)
        Me.lblUsrId.Name = "lblUsrId"
        Me.lblUsrId.Size = New System.Drawing.Size(19, 13)
        Me.lblUsrId.TabIndex = 0
        Me.lblUsrId.Text = "Nº"
        '
        'gpbGeneral
        '
        Me.gpbGeneral.Controls.Add(Me.txtConfirmarContrasenia)
        Me.gpbGeneral.Controls.Add(Me.lblConfirmarContrasenia)
        Me.gpbGeneral.Controls.Add(Me.cmbOperador)
        Me.gpbGeneral.Controls.Add(Me.lblOperadorId)
        Me.gpbGeneral.Controls.Add(Me.cmbPerfil)
        Me.gpbGeneral.Controls.Add(Me.lblPerfil)
        Me.gpbGeneral.Controls.Add(Me.cmbPuestoId)
        Me.gpbGeneral.Controls.Add(Me.lblPuestoId)
        Me.gpbGeneral.Controls.Add(Me.txtCntrsenia)
        Me.gpbGeneral.Controls.Add(Me.lblCntrsenia)
        Me.gpbGeneral.Controls.Add(Me.txtApllidom)
        Me.gpbGeneral.Controls.Add(Me.lblApllidom)
        Me.gpbGeneral.Controls.Add(Me.txtApllidop)
        Me.gpbGeneral.Controls.Add(Me.lblApllidop)
        Me.gpbGeneral.Controls.Add(Me.txtNombre)
        Me.gpbGeneral.Controls.Add(Me.lblNombre)
        Me.gpbGeneral.Controls.Add(Me.txtNkName)
        Me.gpbGeneral.Controls.Add(Me.lblNkName)
        Me.gpbGeneral.Location = New System.Drawing.Point(24, 76)
        Me.gpbGeneral.Name = "gpbGeneral"
        Me.gpbGeneral.Size = New System.Drawing.Size(661, 190)
        Me.gpbGeneral.TabIndex = 3
        Me.gpbGeneral.TabStop = False
        Me.gpbGeneral.Text = "General"
        '
        'txtConfirmarContrasenia
        '
        Me.txtConfirmarContrasenia.Location = New System.Drawing.Point(430, 42)
        Me.txtConfirmarContrasenia.Name = "txtConfirmarContrasenia"
        Me.txtConfirmarContrasenia.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarContrasenia.Size = New System.Drawing.Size(204, 20)
        Me.txtConfirmarContrasenia.TabIndex = 9
        '
        'lblConfirmarContrasenia
        '
        Me.lblConfirmarContrasenia.AutoSize = True
        Me.lblConfirmarContrasenia.Location = New System.Drawing.Point(427, 26)
        Me.lblConfirmarContrasenia.Name = "lblConfirmarContrasenia"
        Me.lblConfirmarContrasenia.Size = New System.Drawing.Size(108, 13)
        Me.lblConfirmarContrasenia.TabIndex = 8
        Me.lblConfirmarContrasenia.Text = "Confirmar Contraseña"
        '
        'cmbOperador
        '
        Me.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(431, 142)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(203, 21)
        Me.cmbOperador.TabIndex = 20
        '
        'lblOperadorId
        '
        Me.lblOperadorId.AutoSize = True
        Me.lblOperadorId.Location = New System.Drawing.Point(427, 126)
        Me.lblOperadorId.Name = "lblOperadorId"
        Me.lblOperadorId.Size = New System.Drawing.Size(51, 13)
        Me.lblOperadorId.TabIndex = 20
        Me.lblOperadorId.Text = "Operador"
        '
        'cmbPerfil
        '
        Me.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPerfil.FormattingEnabled = True
        Me.cmbPerfil.Location = New System.Drawing.Point(218, 142)
        Me.cmbPerfil.Name = "cmbPerfil"
        Me.cmbPerfil.Size = New System.Drawing.Size(203, 21)
        Me.cmbPerfil.TabIndex = 19
        '
        'lblPerfil
        '
        Me.lblPerfil.AutoSize = True
        Me.lblPerfil.Location = New System.Drawing.Point(215, 126)
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Size = New System.Drawing.Size(30, 13)
        Me.lblPerfil.TabIndex = 18
        Me.lblPerfil.Text = "Perfil"
        '
        'cmbPuestoId
        '
        Me.cmbPuestoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuestoId.FormattingEnabled = True
        Me.cmbPuestoId.Location = New System.Drawing.Point(21, 142)
        Me.cmbPuestoId.Name = "cmbPuestoId"
        Me.cmbPuestoId.Size = New System.Drawing.Size(188, 21)
        Me.cmbPuestoId.TabIndex = 17
        '
        'lblPuestoId
        '
        Me.lblPuestoId.AutoSize = True
        Me.lblPuestoId.Location = New System.Drawing.Point(18, 126)
        Me.lblPuestoId.Name = "lblPuestoId"
        Me.lblPuestoId.Size = New System.Drawing.Size(40, 13)
        Me.lblPuestoId.TabIndex = 16
        Me.lblPuestoId.Text = "Puesto"
        '
        'txtCntrsenia
        '
        Me.txtCntrsenia.Location = New System.Drawing.Point(217, 42)
        Me.txtCntrsenia.Name = "txtCntrsenia"
        Me.txtCntrsenia.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCntrsenia.Size = New System.Drawing.Size(204, 20)
        Me.txtCntrsenia.TabIndex = 7
        '
        'lblCntrsenia
        '
        Me.lblCntrsenia.AutoSize = True
        Me.lblCntrsenia.Location = New System.Drawing.Point(214, 26)
        Me.lblCntrsenia.Name = "lblCntrsenia"
        Me.lblCntrsenia.Size = New System.Drawing.Size(61, 13)
        Me.lblCntrsenia.TabIndex = 6
        Me.lblCntrsenia.Text = "Contraseña"
        '
        'txtApllidom
        '
        Me.txtApllidom.Location = New System.Drawing.Point(430, 91)
        Me.txtApllidom.Name = "txtApllidom"
        Me.txtApllidom.Size = New System.Drawing.Size(204, 20)
        Me.txtApllidom.TabIndex = 15
        '
        'lblApllidom
        '
        Me.lblApllidom.AutoSize = True
        Me.lblApllidom.Location = New System.Drawing.Point(427, 75)
        Me.lblApllidom.Name = "lblApllidom"
        Me.lblApllidom.Size = New System.Drawing.Size(86, 13)
        Me.lblApllidom.TabIndex = 14
        Me.lblApllidom.Text = "Apellido Materno"
        '
        'txtApllidop
        '
        Me.txtApllidop.Location = New System.Drawing.Point(217, 91)
        Me.txtApllidop.Name = "txtApllidop"
        Me.txtApllidop.Size = New System.Drawing.Size(204, 20)
        Me.txtApllidop.TabIndex = 13
        '
        'lblApllidop
        '
        Me.lblApllidop.AutoSize = True
        Me.lblApllidop.Location = New System.Drawing.Point(214, 75)
        Me.lblApllidop.Name = "lblApllidop"
        Me.lblApllidop.Size = New System.Drawing.Size(84, 13)
        Me.lblApllidop.TabIndex = 12
        Me.lblApllidop.Text = "Apellido Paterno"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(21, 91)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(188, 20)
        Me.txtNombre.TabIndex = 11
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(18, 75)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 10
        Me.lblNombre.Text = "Nombre"
        '
        'txtNkName
        '
        Me.txtNkName.Location = New System.Drawing.Point(21, 42)
        Me.txtNkName.Name = "txtNkName"
        Me.txtNkName.Size = New System.Drawing.Size(188, 20)
        Me.txtNkName.TabIndex = 5
        '
        'lblNkName
        '
        Me.lblNkName.AutoSize = True
        Me.lblNkName.Location = New System.Drawing.Point(18, 26)
        Me.lblNkName.Name = "lblNkName"
        Me.lblNkName.Size = New System.Drawing.Size(55, 13)
        Me.lblNkName.TabIndex = 4
        Me.lblNkName.Text = "Nickname"
        '
        'gpbCorreo
        '
        Me.gpbCorreo.Controls.Add(Me.txtConfContraseiaCuentaCorreo)
        Me.gpbCorreo.Controls.Add(Me.lblConfContraseiaCuentaCorreo)
        Me.gpbCorreo.Controls.Add(Me.txtContraseniaCuentaCorreo)
        Me.gpbCorreo.Controls.Add(Me.lblContraseiaCuentaCorreo)
        Me.gpbCorreo.Controls.Add(Me.txtCuentaCorreo)
        Me.gpbCorreo.Controls.Add(Me.lblCuentaCorreo)
        Me.gpbCorreo.Controls.Add(Me.cmbSmtpId)
        Me.gpbCorreo.Controls.Add(Me.lblSmtpId)
        Me.gpbCorreo.Location = New System.Drawing.Point(24, 288)
        Me.gpbCorreo.Name = "gpbCorreo"
        Me.gpbCorreo.Size = New System.Drawing.Size(661, 121)
        Me.gpbCorreo.TabIndex = 21
        Me.gpbCorreo.TabStop = False
        Me.gpbCorreo.Text = "Correo Electrónico"
        '
        'txtConfContraseiaCuentaCorreo
        '
        Me.txtConfContraseiaCuentaCorreo.Location = New System.Drawing.Point(237, 82)
        Me.txtConfContraseiaCuentaCorreo.Name = "txtConfContraseiaCuentaCorreo"
        Me.txtConfContraseiaCuentaCorreo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfContraseiaCuentaCorreo.Size = New System.Drawing.Size(204, 20)
        Me.txtConfContraseiaCuentaCorreo.TabIndex = 29
        '
        'lblConfContraseiaCuentaCorreo
        '
        Me.lblConfContraseiaCuentaCorreo.AutoSize = True
        Me.lblConfContraseiaCuentaCorreo.Location = New System.Drawing.Point(234, 66)
        Me.lblConfContraseiaCuentaCorreo.Name = "lblConfContraseiaCuentaCorreo"
        Me.lblConfContraseiaCuentaCorreo.Size = New System.Drawing.Size(108, 13)
        Me.lblConfContraseiaCuentaCorreo.TabIndex = 28
        Me.lblConfContraseiaCuentaCorreo.Text = "Confirmar Contraseña"
        '
        'txtContraseniaCuentaCorreo
        '
        Me.txtContraseniaCuentaCorreo.Location = New System.Drawing.Point(21, 82)
        Me.txtContraseniaCuentaCorreo.Name = "txtContraseniaCuentaCorreo"
        Me.txtContraseniaCuentaCorreo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContraseniaCuentaCorreo.Size = New System.Drawing.Size(204, 20)
        Me.txtContraseniaCuentaCorreo.TabIndex = 27
        '
        'lblContraseiaCuentaCorreo
        '
        Me.lblContraseiaCuentaCorreo.AutoSize = True
        Me.lblContraseiaCuentaCorreo.Location = New System.Drawing.Point(18, 66)
        Me.lblContraseiaCuentaCorreo.Name = "lblContraseiaCuentaCorreo"
        Me.lblContraseiaCuentaCorreo.Size = New System.Drawing.Size(61, 13)
        Me.lblContraseiaCuentaCorreo.TabIndex = 26
        Me.lblContraseiaCuentaCorreo.Text = "Contraseña"
        '
        'txtCuentaCorreo
        '
        Me.txtCuentaCorreo.Location = New System.Drawing.Point(237, 32)
        Me.txtCuentaCorreo.Name = "txtCuentaCorreo"
        Me.txtCuentaCorreo.Size = New System.Drawing.Size(271, 20)
        Me.txtCuentaCorreo.TabIndex = 25
        '
        'lblCuentaCorreo
        '
        Me.lblCuentaCorreo.AutoSize = True
        Me.lblCuentaCorreo.Location = New System.Drawing.Point(234, 16)
        Me.lblCuentaCorreo.Name = "lblCuentaCorreo"
        Me.lblCuentaCorreo.Size = New System.Drawing.Size(146, 13)
        Me.lblCuentaCorreo.TabIndex = 24
        Me.lblCuentaCorreo.Text = "Cuenta de Correo Electrónico"
        '
        'cmbSmtpId
        '
        Me.cmbSmtpId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSmtpId.FormattingEnabled = True
        Me.cmbSmtpId.Location = New System.Drawing.Point(21, 32)
        Me.cmbSmtpId.Name = "cmbSmtpId"
        Me.cmbSmtpId.Size = New System.Drawing.Size(188, 21)
        Me.cmbSmtpId.TabIndex = 23
        '
        'lblSmtpId
        '
        Me.lblSmtpId.AutoSize = True
        Me.lblSmtpId.Location = New System.Drawing.Point(18, 16)
        Me.lblSmtpId.Name = "lblSmtpId"
        Me.lblSmtpId.Size = New System.Drawing.Size(45, 13)
        Me.lblSmtpId.TabIndex = 22
        Me.lblSmtpId.Text = "Dominio"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(109, 429)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 31
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(24, 429)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 30
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 468)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbCorreo)
        Me.Controls.Add(Me.gpbGeneral)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtUsrId)
        Me.Controls.Add(Me.lblUsrId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmUsuario"
        Me.Text = "Usuarios"
        Me.gpbGeneral.ResumeLayout(False)
        Me.gpbGeneral.PerformLayout()
        Me.gpbCorreo.ResumeLayout(False)
        Me.gpbCorreo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtUsrId As System.Windows.Forms.TextBox
    Friend WithEvents lblUsrId As System.Windows.Forms.Label
    Friend WithEvents gpbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents txtNkName As System.Windows.Forms.TextBox
    Friend WithEvents lblNkName As System.Windows.Forms.Label
    Friend WithEvents txtApllidom As System.Windows.Forms.TextBox
    Friend WithEvents lblApllidom As System.Windows.Forms.Label
    Friend WithEvents txtApllidop As System.Windows.Forms.TextBox
    Friend WithEvents lblApllidop As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtCntrsenia As System.Windows.Forms.TextBox
    Friend WithEvents lblCntrsenia As System.Windows.Forms.Label
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents lblOperadorId As System.Windows.Forms.Label
    Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents cmbPuestoId As System.Windows.Forms.ComboBox
    Friend WithEvents lblPuestoId As System.Windows.Forms.Label
    Friend WithEvents gpbCorreo As System.Windows.Forms.GroupBox
    Friend WithEvents txtContraseniaCuentaCorreo As System.Windows.Forms.TextBox
    Friend WithEvents lblContraseiaCuentaCorreo As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCorreo As System.Windows.Forms.TextBox
    Friend WithEvents lblCuentaCorreo As System.Windows.Forms.Label
    Friend WithEvents cmbSmtpId As System.Windows.Forms.ComboBox
    Friend WithEvents lblSmtpId As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtConfirmarContrasenia As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmarContrasenia As System.Windows.Forms.Label
    Friend WithEvents txtConfContraseiaCuentaCorreo As System.Windows.Forms.TextBox
    Friend WithEvents lblConfContraseiaCuentaCorreo As System.Windows.Forms.Label
End Class
