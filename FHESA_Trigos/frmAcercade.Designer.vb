<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcercade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcercade))
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblEditor = New System.Windows.Forms.Label()
        Me.lblFechaCompilacion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(12, 150)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "Version"
        '
        'lblEditor
        '
        Me.lblEditor.AutoSize = True
        Me.lblEditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditor.Location = New System.Drawing.Point(12, 187)
        Me.lblEditor.Name = "lblEditor"
        Me.lblEditor.Size = New System.Drawing.Size(260, 13)
        Me.lblEditor.TabIndex = 1
        Me.lblEditor.Text = "2017 Tecno-Logic Soluciones Tecnológicas."
        '
        'lblFechaCompilacion
        '
        Me.lblFechaCompilacion.AutoSize = True
        Me.lblFechaCompilacion.Location = New System.Drawing.Point(12, 163)
        Me.lblFechaCompilacion.Name = "lblFechaCompilacion"
        Me.lblFechaCompilacion.Size = New System.Drawing.Size(111, 13)
        Me.lblFechaCompilacion.TabIndex = 2
        Me.lblFechaCompilacion.Text = "Fecha de compilación"
        '
        'frmAcercade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 211)
        Me.Controls.Add(Me.lblFechaCompilacion)
        Me.Controls.Add(Me.lblEditor)
        Me.Controls.Add(Me.lblVersion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAcercade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de Logística de Trigos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblEditor As System.Windows.Forms.Label
    Friend WithEvents lblFechaCompilacion As System.Windows.Forms.Label
End Class
