<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperador))
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtOprdorId = New System.Windows.Forms.TextBox()
        Me.lblOprdorId = New System.Windows.Forms.Label()
        Me.gbpGeneral = New System.Windows.Forms.GroupBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNkName = New System.Windows.Forms.TextBox()
        Me.lblNkName = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gbpGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(448, 19)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 3
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtOprdorId
        '
        Me.txtOprdorId.AcceptsReturn = True
        Me.txtOprdorId.Location = New System.Drawing.Point(58, 16)
        Me.txtOprdorId.Multiline = True
        Me.txtOprdorId.Name = "txtOprdorId"
        Me.txtOprdorId.Size = New System.Drawing.Size(100, 20)
        Me.txtOprdorId.TabIndex = 2
        '
        'lblOprdorId
        '
        Me.lblOprdorId.AutoSize = True
        Me.lblOprdorId.Location = New System.Drawing.Point(23, 19)
        Me.lblOprdorId.Name = "lblOprdorId"
        Me.lblOprdorId.Size = New System.Drawing.Size(19, 13)
        Me.lblOprdorId.TabIndex = 1
        Me.lblOprdorId.Text = "Nº"
        '
        'gbpGeneral
        '
        Me.gbpGeneral.Controls.Add(Me.txtNombre)
        Me.gbpGeneral.Controls.Add(Me.lblNombre)
        Me.gbpGeneral.Controls.Add(Me.txtNkName)
        Me.gbpGeneral.Controls.Add(Me.lblNkName)
        Me.gbpGeneral.Location = New System.Drawing.Point(26, 64)
        Me.gbpGeneral.Name = "gbpGeneral"
        Me.gbpGeneral.Size = New System.Drawing.Size(478, 138)
        Me.gbpGeneral.TabIndex = 4
        Me.gbpGeneral.TabStop = False
        Me.gbpGeneral.Text = "General"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(18, 94)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(439, 20)
        Me.txtNombre.TabIndex = 8
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(15, 78)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 7
        Me.lblNombre.Text = "Nombre"
        '
        'txtNkName
        '
        Me.txtNkName.Location = New System.Drawing.Point(18, 44)
        Me.txtNkName.Name = "txtNkName"
        Me.txtNkName.Size = New System.Drawing.Size(188, 20)
        Me.txtNkName.TabIndex = 6
        '
        'lblNkName
        '
        Me.lblNkName.AutoSize = True
        Me.lblNkName.Location = New System.Drawing.Point(15, 28)
        Me.lblNkName.Name = "lblNkName"
        Me.lblNkName.Size = New System.Drawing.Size(55, 13)
        Me.lblNkName.TabIndex = 5
        Me.lblNkName.Text = "Nickname"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(111, 226)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(26, 226)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmOperador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 264)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gbpGeneral)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtOprdorId)
        Me.Controls.Add(Me.lblOprdorId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmOperador"
        Me.Text = "Operador"
        Me.gbpGeneral.ResumeLayout(False)
        Me.gbpGeneral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtOprdorId As System.Windows.Forms.TextBox
    Friend WithEvents lblOprdorId As System.Windows.Forms.Label
    Friend WithEvents gbpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNkName As System.Windows.Forms.TextBox
    Friend WithEvents lblNkName As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
