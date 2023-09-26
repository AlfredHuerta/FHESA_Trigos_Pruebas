<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisorEventos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisorEventos))
        Me.gpbVisorEventosAd = New System.Windows.Forms.GroupBox()
        Me.chkGuardarLog = New System.Windows.Forms.CheckBox()
        Me.tbcVisor = New System.Windows.Forms.TabControl()
        Me.gpbVisorEventosAd.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbVisorEventosAd
        '
        Me.gpbVisorEventosAd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbVisorEventosAd.Controls.Add(Me.chkGuardarLog)
        Me.gpbVisorEventosAd.Controls.Add(Me.tbcVisor)
        Me.gpbVisorEventosAd.Location = New System.Drawing.Point(12, 3)
        Me.gpbVisorEventosAd.Name = "gpbVisorEventosAd"
        Me.gpbVisorEventosAd.Size = New System.Drawing.Size(1303, 257)
        Me.gpbVisorEventosAd.TabIndex = 0
        Me.gpbVisorEventosAd.TabStop = False
        Me.gpbVisorEventosAd.Text = "Visor de Eventos"
        '
        'chkGuardarLog
        '
        Me.chkGuardarLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkGuardarLog.AutoSize = True
        Me.chkGuardarLog.Checked = True
        Me.chkGuardarLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGuardarLog.Location = New System.Drawing.Point(1212, 234)
        Me.chkGuardarLog.Name = "chkGuardarLog"
        Me.chkGuardarLog.Size = New System.Drawing.Size(85, 17)
        Me.chkGuardarLog.TabIndex = 1
        Me.chkGuardarLog.Text = "Guardar Log"
        Me.chkGuardarLog.UseVisualStyleBackColor = True
        '
        'tbcVisor
        '
        Me.tbcVisor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcVisor.Location = New System.Drawing.Point(6, 19)
        Me.tbcVisor.Name = "tbcVisor"
        Me.tbcVisor.SelectedIndex = 0
        Me.tbcVisor.Size = New System.Drawing.Size(1291, 209)
        Me.tbcVisor.TabIndex = 1
        '
        'frmVisorEventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1327, 272)
        Me.Controls.Add(Me.gpbVisorEventosAd)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVisorEventos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Visor de Eventos"
        Me.gpbVisorEventosAd.ResumeLayout(False)
        Me.gpbVisorEventosAd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbVisorEventosAd As System.Windows.Forms.GroupBox
    Friend WithEvents chkGuardarLog As System.Windows.Forms.CheckBox
    Friend WithEvents tbcVisor As System.Windows.Forms.TabControl
End Class
