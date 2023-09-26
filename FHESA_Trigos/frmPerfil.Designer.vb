<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfil))
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.txtPerfilId = New System.Windows.Forms.TextBox()
        Me.lblPerfilId = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.gpbDetallePerfil = New System.Windows.Forms.GroupBox()
        Me.lblOpcEfectivas = New System.Windows.Forms.Label()
        Me.chkOpcCancelar = New System.Windows.Forms.CheckBox()
        Me.chkOpcCerrar = New System.Windows.Forms.CheckBox()
        Me.chkOpcCrear = New System.Windows.Forms.CheckBox()
        Me.chkOpcModif = New System.Windows.Forms.CheckBox()
        Me.chkOpcConsultar = New System.Windows.Forms.CheckBox()
        Me.chkOpcActiva = New System.Windows.Forms.CheckBox()
        Me.trvDetalle = New System.Windows.Forms.TreeView()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gpbDetallePerfil.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkActivo
        '
        Me.chkActivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(459, 20)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 2
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'txtPerfilId
        '
        Me.txtPerfilId.AcceptsReturn = True
        Me.txtPerfilId.Location = New System.Drawing.Point(61, 21)
        Me.txtPerfilId.Multiline = True
        Me.txtPerfilId.Name = "txtPerfilId"
        Me.txtPerfilId.Size = New System.Drawing.Size(100, 20)
        Me.txtPerfilId.TabIndex = 1
        '
        'lblPerfilId
        '
        Me.lblPerfilId.AutoSize = True
        Me.lblPerfilId.Location = New System.Drawing.Point(26, 24)
        Me.lblPerfilId.Name = "lblPerfilId"
        Me.lblPerfilId.Size = New System.Drawing.Size(19, 13)
        Me.lblPerfilId.TabIndex = 0
        Me.lblPerfilId.Text = "Nº"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(26, 74)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(360, 20)
        Me.txtNombre.TabIndex = 4
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(26, 58)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre"
        '
        'gpbDetallePerfil
        '
        Me.gpbDetallePerfil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbDetallePerfil.Controls.Add(Me.lblOpcEfectivas)
        Me.gpbDetallePerfil.Controls.Add(Me.chkOpcCancelar)
        Me.gpbDetallePerfil.Controls.Add(Me.chkOpcCerrar)
        Me.gpbDetallePerfil.Controls.Add(Me.chkOpcCrear)
        Me.gpbDetallePerfil.Controls.Add(Me.chkOpcModif)
        Me.gpbDetallePerfil.Controls.Add(Me.chkOpcConsultar)
        Me.gpbDetallePerfil.Controls.Add(Me.chkOpcActiva)
        Me.gpbDetallePerfil.Controls.Add(Me.trvDetalle)
        Me.gpbDetallePerfil.Location = New System.Drawing.Point(29, 112)
        Me.gpbDetallePerfil.Name = "gpbDetallePerfil"
        Me.gpbDetallePerfil.Size = New System.Drawing.Size(486, 333)
        Me.gpbDetallePerfil.TabIndex = 5
        Me.gpbDetallePerfil.TabStop = False
        Me.gpbDetallePerfil.Text = "Detalle"
        '
        'lblOpcEfectivas
        '
        Me.lblOpcEfectivas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOpcEfectivas.AutoSize = True
        Me.lblOpcEfectivas.Location = New System.Drawing.Point(353, 64)
        Me.lblOpcEfectivas.Name = "lblOpcEfectivas"
        Me.lblOpcEfectivas.Size = New System.Drawing.Size(113, 13)
        Me.lblOpcEfectivas.TabIndex = 7
        Me.lblOpcEfectivas.Text = "Funciones Disponibles"
        '
        'chkOpcCancelar
        '
        Me.chkOpcCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcCancelar.AutoSize = True
        Me.chkOpcCancelar.Location = New System.Drawing.Point(373, 162)
        Me.chkOpcCancelar.Name = "chkOpcCancelar"
        Me.chkOpcCancelar.Size = New System.Drawing.Size(68, 17)
        Me.chkOpcCancelar.TabIndex = 10
        Me.chkOpcCancelar.Text = "Cancelar"
        Me.chkOpcCancelar.UseVisualStyleBackColor = True
        '
        'chkOpcCerrar
        '
        Me.chkOpcCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcCerrar.AutoSize = True
        Me.chkOpcCerrar.Location = New System.Drawing.Point(373, 139)
        Me.chkOpcCerrar.Name = "chkOpcCerrar"
        Me.chkOpcCerrar.Size = New System.Drawing.Size(54, 17)
        Me.chkOpcCerrar.TabIndex = 9
        Me.chkOpcCerrar.Text = "Cerrar"
        Me.chkOpcCerrar.UseVisualStyleBackColor = True
        '
        'chkOpcCrear
        '
        Me.chkOpcCrear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcCrear.AutoSize = True
        Me.chkOpcCrear.Location = New System.Drawing.Point(373, 80)
        Me.chkOpcCrear.Name = "chkOpcCrear"
        Me.chkOpcCrear.Size = New System.Drawing.Size(51, 17)
        Me.chkOpcCrear.TabIndex = 7
        Me.chkOpcCrear.Text = "Crear"
        Me.chkOpcCrear.UseVisualStyleBackColor = True
        '
        'chkOpcModif
        '
        Me.chkOpcModif.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcModif.AutoSize = True
        Me.chkOpcModif.Location = New System.Drawing.Point(373, 116)
        Me.chkOpcModif.Name = "chkOpcModif"
        Me.chkOpcModif.Size = New System.Drawing.Size(69, 17)
        Me.chkOpcModif.TabIndex = 8
        Me.chkOpcModif.Text = "Modificar"
        Me.chkOpcModif.UseVisualStyleBackColor = True
        '
        'chkOpcConsultar
        '
        Me.chkOpcConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcConsultar.AutoSize = True
        Me.chkOpcConsultar.Location = New System.Drawing.Point(373, 200)
        Me.chkOpcConsultar.Name = "chkOpcConsultar"
        Me.chkOpcConsultar.Size = New System.Drawing.Size(70, 17)
        Me.chkOpcConsultar.TabIndex = 11
        Me.chkOpcConsultar.Text = "Consultar"
        Me.chkOpcConsultar.UseVisualStyleBackColor = True
        '
        'chkOpcActiva
        '
        Me.chkOpcActiva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkOpcActiva.AutoSize = True
        Me.chkOpcActiva.Location = New System.Drawing.Point(356, 19)
        Me.chkOpcActiva.Name = "chkOpcActiva"
        Me.chkOpcActiva.Size = New System.Drawing.Size(56, 17)
        Me.chkOpcActiva.TabIndex = 7
        Me.chkOpcActiva.Text = "Activo"
        Me.chkOpcActiva.UseVisualStyleBackColor = True
        '
        'trvDetalle
        '
        Me.trvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvDetalle.Location = New System.Drawing.Point(23, 19)
        Me.trvDetalle.Name = "trvDetalle"
        Me.trvDetalle.Size = New System.Drawing.Size(302, 296)
        Me.trvDetalle.TabIndex = 6
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(114, 451)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(29, 451)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 12
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 486)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbDetallePerfil)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtPerfilId)
        Me.Controls.Add(Me.lblPerfilId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerfil"
        Me.Text = "Perfil"
        Me.gpbDetallePerfil.ResumeLayout(false)
        Me.gpbDetallePerfil.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents txtPerfilId As System.Windows.Forms.TextBox
    Friend WithEvents lblPerfilId As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents gpbDetallePerfil As System.Windows.Forms.GroupBox
    Friend WithEvents lblOpcEfectivas As System.Windows.Forms.Label
    Friend WithEvents chkOpcCancelar As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpcCerrar As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpcCrear As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpcModif As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpcConsultar As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpcActiva As System.Windows.Forms.CheckBox
    Friend WithEvents trvDetalle As System.Windows.Forms.TreeView
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
End Class
