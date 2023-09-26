<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargadorMasivoEmb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargadorMasivoEmb))
        Me.lblRutaArchivoFuente = New System.Windows.Forms.Label()
        Me.txtRutaArchivoFuente = New System.Windows.Forms.TextBox()
        Me.cmdRutaArchivoFuente = New System.Windows.Forms.Button()
        Me.dgvEmbEncontrados = New System.Windows.Forms.DataGridView()
        Me.lblEmbEncontrados = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.lblNombreHoja = New System.Windows.Forms.Label()
        Me.cmbNombreHoja = New System.Windows.Forms.ComboBox()
        Me.cmdLeerHoja = New System.Windows.Forms.Button()
        CType(Me.dgvEmbEncontrados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRutaArchivoFuente
        '
        Me.lblRutaArchivoFuente.AutoSize = True
        Me.lblRutaArchivoFuente.Location = New System.Drawing.Point(12, 19)
        Me.lblRutaArchivoFuente.Name = "lblRutaArchivoFuente"
        Me.lblRutaArchivoFuente.Size = New System.Drawing.Size(143, 13)
        Me.lblRutaArchivoFuente.TabIndex = 0
        Me.lblRutaArchivoFuente.Text = "Ubicación del archivo fuente"
        '
        'txtRutaArchivoFuente
        '
        Me.txtRutaArchivoFuente.Location = New System.Drawing.Point(15, 35)
        Me.txtRutaArchivoFuente.Name = "txtRutaArchivoFuente"
        Me.txtRutaArchivoFuente.Size = New System.Drawing.Size(681, 20)
        Me.txtRutaArchivoFuente.TabIndex = 1
        '
        'cmdRutaArchivoFuente
        '
        Me.cmdRutaArchivoFuente.Location = New System.Drawing.Point(702, 33)
        Me.cmdRutaArchivoFuente.Name = "cmdRutaArchivoFuente"
        Me.cmdRutaArchivoFuente.Size = New System.Drawing.Size(30, 23)
        Me.cmdRutaArchivoFuente.TabIndex = 2
        Me.cmdRutaArchivoFuente.Text = "..."
        Me.cmdRutaArchivoFuente.UseVisualStyleBackColor = True
        '
        'dgvEmbEncontrados
        '
        Me.dgvEmbEncontrados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmbEncontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmbEncontrados.Location = New System.Drawing.Point(15, 136)
        Me.dgvEmbEncontrados.Name = "dgvEmbEncontrados"
        Me.dgvEmbEncontrados.Size = New System.Drawing.Size(819, 368)
        Me.dgvEmbEncontrados.TabIndex = 3
        '
        'lblEmbEncontrados
        '
        Me.lblEmbEncontrados.AutoSize = True
        Me.lblEmbEncontrados.Location = New System.Drawing.Point(12, 120)
        Me.lblEmbEncontrados.Name = "lblEmbEncontrados"
        Me.lblEmbEncontrados.Size = New System.Drawing.Size(122, 13)
        Me.lblEmbEncontrados.TabIndex = 4
        Me.lblEmbEncontrados.Text = "Embarques encontrados"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(100, 510)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 47
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(15, 510)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 46
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'lblNombreHoja
        '
        Me.lblNombreHoja.AutoSize = True
        Me.lblNombreHoja.Location = New System.Drawing.Point(12, 67)
        Me.lblNombreHoja.Name = "lblNombreHoja"
        Me.lblNombreHoja.Size = New System.Drawing.Size(186, 13)
        Me.lblNombreHoja.TabIndex = 48
        Me.lblNombreHoja.Text = "Hojas disponibles en el archivo fuente"
        '
        'cmbNombreHoja
        '
        Me.cmbNombreHoja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNombreHoja.FormattingEnabled = True
        Me.cmbNombreHoja.Location = New System.Drawing.Point(15, 83)
        Me.cmbNombreHoja.Name = "cmbNombreHoja"
        Me.cmbNombreHoja.Size = New System.Drawing.Size(228, 21)
        Me.cmbNombreHoja.TabIndex = 49
        '
        'cmdLeerHoja
        '
        Me.cmdLeerHoja.Location = New System.Drawing.Point(267, 67)
        Me.cmdLeerHoja.Name = "cmdLeerHoja"
        Me.cmdLeerHoja.Size = New System.Drawing.Size(75, 37)
        Me.cmdLeerHoja.TabIndex = 50
        Me.cmdLeerHoja.Text = "Cargar Información"
        Me.cmdLeerHoja.UseVisualStyleBackColor = True
        '
        'frmCargadorMasivoEmb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 550)
        Me.Controls.Add(Me.cmdLeerHoja)
        Me.Controls.Add(Me.cmbNombreHoja)
        Me.Controls.Add(Me.lblNombreHoja)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.lblEmbEncontrados)
        Me.Controls.Add(Me.dgvEmbEncontrados)
        Me.Controls.Add(Me.cmdRutaArchivoFuente)
        Me.Controls.Add(Me.txtRutaArchivoFuente)
        Me.Controls.Add(Me.lblRutaArchivoFuente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargadorMasivoEmb"
        Me.Text = "Carga Masiva de Embarques"
        CType(Me.dgvEmbEncontrados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRutaArchivoFuente As System.Windows.Forms.Label
    Friend WithEvents txtRutaArchivoFuente As System.Windows.Forms.TextBox
    Friend WithEvents cmdRutaArchivoFuente As System.Windows.Forms.Button
    Friend WithEvents dgvEmbEncontrados As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmbEncontrados As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblNombreHoja As System.Windows.Forms.Label
    Friend WithEvents cmbNombreHoja As System.Windows.Forms.ComboBox
    Friend WithEvents cmdLeerHoja As System.Windows.Forms.Button
End Class
