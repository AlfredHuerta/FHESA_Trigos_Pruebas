<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLote))
        Me.lblNoLote = New System.Windows.Forms.Label()
        Me.txtLoteId = New System.Windows.Forms.TextBox()
        Me.dtpFechaLote = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaLote = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.gpbGeneral = New System.Windows.Forms.GroupBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblOtros = New System.Windows.Forms.Label()
        Me.txtOtros = New System.Windows.Forms.TextBox()
        Me.lblfllnnum = New System.Windows.Forms.Label()
        Me.txtfllnnum = New System.Windows.Forms.TextBox()
        Me.lblErgot = New System.Windows.Forms.Label()
        Me.txtErgot = New System.Windows.Forms.TextBox()
        Me.lblVomitoxina = New System.Windows.Forms.Label()
        Me.txtVomitoxina = New System.Windows.Forms.TextBox()
        Me.lblDockage = New System.Windows.Forms.Label()
        Me.txtDockage = New System.Windows.Forms.TextBox()
        Me.lblImpureza = New System.Windows.Forms.Label()
        Me.txtImpureza = New System.Windows.Forms.TextBox()
        Me.lblPesohtl = New System.Windows.Forms.Label()
        Me.txtPesohtl = New System.Windows.Forms.TextBox()
        Me.lblHumedad = New System.Windows.Forms.Label()
        Me.txtHumedad = New System.Windows.Forms.TextBox()
        Me.lblGrado = New System.Windows.Forms.Label()
        Me.txtGrado = New System.Windows.Forms.TextBox()
        Me.lblProteina = New System.Windows.Forms.Label()
        Me.txtProteina = New System.Windows.Forms.TextBox()
        Me.cmdTrigo = New System.Windows.Forms.Button()
        Me.txtTrigo = New System.Windows.Forms.TextBox()
        Me.lblTrigo = New System.Windows.Forms.Label()
        Me.txtTrigoId = New System.Windows.Forms.TextBox()
        Me.cmdprov = New System.Windows.Forms.Button()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.txtProvId = New System.Windows.Forms.TextBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.gpbGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNoLote
        '
        Me.lblNoLote.AutoSize = True
        Me.lblNoLote.Location = New System.Drawing.Point(34, 15)
        Me.lblNoLote.Name = "lblNoLote"
        Me.lblNoLote.Size = New System.Drawing.Size(19, 13)
        Me.lblNoLote.TabIndex = 0
        Me.lblNoLote.Text = "Nº"
        '
        'txtLoteId
        '
        Me.txtLoteId.AcceptsReturn = True
        Me.txtLoteId.Location = New System.Drawing.Point(59, 12)
        Me.txtLoteId.Multiline = True
        Me.txtLoteId.Name = "txtLoteId"
        Me.txtLoteId.Size = New System.Drawing.Size(109, 20)
        Me.txtLoteId.TabIndex = 1
        '
        'dtpFechaLote
        '
        Me.dtpFechaLote.Checked = False
        Me.dtpFechaLote.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaLote.Location = New System.Drawing.Point(59, 38)
        Me.dtpFechaLote.Name = "dtpFechaLote"
        Me.dtpFechaLote.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaLote.TabIndex = 3
        '
        'lblFechaLote
        '
        Me.lblFechaLote.AutoSize = True
        Me.lblFechaLote.Location = New System.Drawing.Point(16, 44)
        Me.lblFechaLote.Name = "lblFechaLote"
        Me.lblFechaLote.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaLote.TabIndex = 2
        Me.lblFechaLote.Text = "Fecha"
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(562, 31)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(109, 21)
        Me.cmbEstado.TabIndex = 5
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(559, 15)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 4
        Me.lblEstado.Text = "Estado"
        '
        'gpbGeneral
        '
        Me.gpbGeneral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbGeneral.Controls.Add(Me.lblObservaciones)
        Me.gpbGeneral.Controls.Add(Me.txtObservaciones)
        Me.gpbGeneral.Controls.Add(Me.lblOtros)
        Me.gpbGeneral.Controls.Add(Me.txtOtros)
        Me.gpbGeneral.Controls.Add(Me.lblfllnnum)
        Me.gpbGeneral.Controls.Add(Me.txtfllnnum)
        Me.gpbGeneral.Controls.Add(Me.lblErgot)
        Me.gpbGeneral.Controls.Add(Me.txtErgot)
        Me.gpbGeneral.Controls.Add(Me.lblVomitoxina)
        Me.gpbGeneral.Controls.Add(Me.txtVomitoxina)
        Me.gpbGeneral.Controls.Add(Me.lblDockage)
        Me.gpbGeneral.Controls.Add(Me.txtDockage)
        Me.gpbGeneral.Controls.Add(Me.lblImpureza)
        Me.gpbGeneral.Controls.Add(Me.txtImpureza)
        Me.gpbGeneral.Controls.Add(Me.lblPesohtl)
        Me.gpbGeneral.Controls.Add(Me.txtPesohtl)
        Me.gpbGeneral.Controls.Add(Me.lblHumedad)
        Me.gpbGeneral.Controls.Add(Me.txtHumedad)
        Me.gpbGeneral.Controls.Add(Me.lblGrado)
        Me.gpbGeneral.Controls.Add(Me.txtGrado)
        Me.gpbGeneral.Controls.Add(Me.lblProteina)
        Me.gpbGeneral.Controls.Add(Me.txtProteina)
        Me.gpbGeneral.Controls.Add(Me.cmdTrigo)
        Me.gpbGeneral.Controls.Add(Me.txtTrigo)
        Me.gpbGeneral.Controls.Add(Me.lblTrigo)
        Me.gpbGeneral.Controls.Add(Me.txtTrigoId)
        Me.gpbGeneral.Controls.Add(Me.cmdprov)
        Me.gpbGeneral.Controls.Add(Me.txtProveedor)
        Me.gpbGeneral.Controls.Add(Me.lblProveedor)
        Me.gpbGeneral.Controls.Add(Me.txtProvId)
        Me.gpbGeneral.Location = New System.Drawing.Point(19, 80)
        Me.gpbGeneral.Name = "gpbGeneral"
        Me.gpbGeneral.Size = New System.Drawing.Size(652, 297)
        Me.gpbGeneral.TabIndex = 6
        Me.gpbGeneral.TabStop = False
        Me.gpbGeneral.Text = "General"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(15, 183)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(78, 13)
        Me.lblObservaciones.TabIndex = 35
        Me.lblObservaciones.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.Location = New System.Drawing.Point(18, 199)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(612, 92)
        Me.txtObservaciones.TabIndex = 36
        '
        'lblOtros
        '
        Me.lblOtros.AutoSize = True
        Me.lblOtros.Location = New System.Drawing.Point(172, 138)
        Me.lblOtros.Name = "lblOtros"
        Me.lblOtros.Size = New System.Drawing.Size(32, 13)
        Me.lblOtros.TabIndex = 32
        Me.lblOtros.Text = "Otros"
        '
        'txtOtros
        '
        Me.txtOtros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOtros.Location = New System.Drawing.Point(175, 154)
        Me.txtOtros.Name = "txtOtros"
        Me.txtOtros.Size = New System.Drawing.Size(455, 20)
        Me.txtOtros.TabIndex = 34
        '
        'lblfllnnum
        '
        Me.lblfllnnum.AutoSize = True
        Me.lblfllnnum.Location = New System.Drawing.Point(13, 138)
        Me.lblfllnnum.Name = "lblfllnnum"
        Me.lblfllnnum.Size = New System.Drawing.Size(77, 13)
        Me.lblfllnnum.TabIndex = 31
        Me.lblfllnnum.Text = "Falling Number"
        '
        'txtfllnnum
        '
        Me.txtfllnnum.Location = New System.Drawing.Point(16, 154)
        Me.txtfllnnum.Name = "txtfllnnum"
        Me.txtfllnnum.Size = New System.Drawing.Size(142, 20)
        Me.txtfllnnum.TabIndex = 33
        '
        'lblErgot
        '
        Me.lblErgot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErgot.AutoSize = True
        Me.lblErgot.Location = New System.Drawing.Point(485, 99)
        Me.lblErgot.Name = "lblErgot"
        Me.lblErgot.Size = New System.Drawing.Size(32, 13)
        Me.lblErgot.TabIndex = 26
        Me.lblErgot.Text = "Ergot"
        '
        'txtErgot
        '
        Me.txtErgot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErgot.Location = New System.Drawing.Point(488, 115)
        Me.txtErgot.Name = "txtErgot"
        Me.txtErgot.Size = New System.Drawing.Size(142, 20)
        Me.txtErgot.TabIndex = 30
        '
        'lblVomitoxina
        '
        Me.lblVomitoxina.AutoSize = True
        Me.lblVomitoxina.Location = New System.Drawing.Point(327, 99)
        Me.lblVomitoxina.Name = "lblVomitoxina"
        Me.lblVomitoxina.Size = New System.Drawing.Size(58, 13)
        Me.lblVomitoxina.TabIndex = 25
        Me.lblVomitoxina.Text = "Vomitoxina"
        '
        'txtVomitoxina
        '
        Me.txtVomitoxina.Location = New System.Drawing.Point(330, 115)
        Me.txtVomitoxina.Name = "txtVomitoxina"
        Me.txtVomitoxina.Size = New System.Drawing.Size(142, 20)
        Me.txtVomitoxina.TabIndex = 29
        '
        'lblDockage
        '
        Me.lblDockage.AutoSize = True
        Me.lblDockage.Location = New System.Drawing.Point(172, 99)
        Me.lblDockage.Name = "lblDockage"
        Me.lblDockage.Size = New System.Drawing.Size(51, 13)
        Me.lblDockage.TabIndex = 24
        Me.lblDockage.Text = "Dockage"
        '
        'txtDockage
        '
        Me.txtDockage.Location = New System.Drawing.Point(175, 115)
        Me.txtDockage.Name = "txtDockage"
        Me.txtDockage.Size = New System.Drawing.Size(142, 20)
        Me.txtDockage.TabIndex = 28
        '
        'lblImpureza
        '
        Me.lblImpureza.AutoSize = True
        Me.lblImpureza.Location = New System.Drawing.Point(15, 99)
        Me.lblImpureza.Name = "lblImpureza"
        Me.lblImpureza.Size = New System.Drawing.Size(50, 13)
        Me.lblImpureza.TabIndex = 23
        Me.lblImpureza.Text = "Impureza"
        '
        'txtImpureza
        '
        Me.txtImpureza.Location = New System.Drawing.Point(18, 115)
        Me.txtImpureza.Name = "txtImpureza"
        Me.txtImpureza.Size = New System.Drawing.Size(142, 20)
        Me.txtImpureza.TabIndex = 27
        '
        'lblPesohtl
        '
        Me.lblPesohtl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPesohtl.AutoSize = True
        Me.lblPesohtl.Location = New System.Drawing.Point(485, 60)
        Me.lblPesohtl.Name = "lblPesohtl"
        Me.lblPesohtl.Size = New System.Drawing.Size(79, 13)
        Me.lblPesohtl.TabIndex = 18
        Me.lblPesohtl.Text = "Peso Hectolitro"
        '
        'txtPesohtl
        '
        Me.txtPesohtl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPesohtl.Location = New System.Drawing.Point(488, 76)
        Me.txtPesohtl.Name = "txtPesohtl"
        Me.txtPesohtl.Size = New System.Drawing.Size(142, 20)
        Me.txtPesohtl.TabIndex = 22
        '
        'lblHumedad
        '
        Me.lblHumedad.AutoSize = True
        Me.lblHumedad.Location = New System.Drawing.Point(327, 60)
        Me.lblHumedad.Name = "lblHumedad"
        Me.lblHumedad.Size = New System.Drawing.Size(53, 13)
        Me.lblHumedad.TabIndex = 17
        Me.lblHumedad.Text = "Humedad"
        '
        'txtHumedad
        '
        Me.txtHumedad.Location = New System.Drawing.Point(330, 76)
        Me.txtHumedad.Name = "txtHumedad"
        Me.txtHumedad.Size = New System.Drawing.Size(142, 20)
        Me.txtHumedad.TabIndex = 21
        '
        'lblGrado
        '
        Me.lblGrado.AutoSize = True
        Me.lblGrado.Location = New System.Drawing.Point(172, 60)
        Me.lblGrado.Name = "lblGrado"
        Me.lblGrado.Size = New System.Drawing.Size(36, 13)
        Me.lblGrado.TabIndex = 16
        Me.lblGrado.Text = "Grado"
        '
        'txtGrado
        '
        Me.txtGrado.Location = New System.Drawing.Point(175, 76)
        Me.txtGrado.Name = "txtGrado"
        Me.txtGrado.Size = New System.Drawing.Size(142, 20)
        Me.txtGrado.TabIndex = 20
        '
        'lblProteina
        '
        Me.lblProteina.AutoSize = True
        Me.lblProteina.Location = New System.Drawing.Point(15, 60)
        Me.lblProteina.Name = "lblProteina"
        Me.lblProteina.Size = New System.Drawing.Size(48, 13)
        Me.lblProteina.TabIndex = 15
        Me.lblProteina.Text = "Proteína"
        '
        'txtProteina
        '
        Me.txtProteina.Location = New System.Drawing.Point(18, 76)
        Me.txtProteina.Name = "txtProteina"
        Me.txtProteina.Size = New System.Drawing.Size(142, 20)
        Me.txtProteina.TabIndex = 19
        '
        'cmdTrigo
        '
        Me.cmdTrigo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdTrigo.FlatAppearance.BorderSize = 0
        Me.cmdTrigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTrigo.Location = New System.Drawing.Point(330, 29)
        Me.cmdTrigo.Name = "cmdTrigo"
        Me.cmdTrigo.Size = New System.Drawing.Size(23, 23)
        Me.cmdTrigo.TabIndex = 11
        Me.cmdTrigo.Text = ">>"
        Me.cmdTrigo.UseVisualStyleBackColor = True
        '
        'txtTrigo
        '
        Me.txtTrigo.AcceptsTab = True
        Me.txtTrigo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTrigo.Location = New System.Drawing.Point(359, 32)
        Me.txtTrigo.Multiline = True
        Me.txtTrigo.Name = "txtTrigo"
        Me.txtTrigo.Size = New System.Drawing.Size(271, 20)
        Me.txtTrigo.TabIndex = 14
        '
        'lblTrigo
        '
        Me.lblTrigo.AutoSize = True
        Me.lblTrigo.Location = New System.Drawing.Point(357, 16)
        Me.lblTrigo.Name = "lblTrigo"
        Me.lblTrigo.Size = New System.Drawing.Size(31, 13)
        Me.lblTrigo.TabIndex = 10
        Me.lblTrigo.Text = "Trigo"
        '
        'txtTrigoId
        '
        Me.txtTrigoId.AcceptsReturn = True
        Me.txtTrigoId.AcceptsTab = True
        Me.txtTrigoId.Location = New System.Drawing.Point(359, 32)
        Me.txtTrigoId.Multiline = True
        Me.txtTrigoId.Name = "txtTrigoId"
        Me.txtTrigoId.Size = New System.Drawing.Size(100, 20)
        Me.txtTrigoId.TabIndex = 12
        Me.txtTrigoId.Visible = False
        '
        'cmdprov
        '
        Me.cmdprov.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.cmdprov.FlatAppearance.BorderSize = 0
        Me.cmdprov.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdprov.Location = New System.Drawing.Point(18, 29)
        Me.cmdprov.Name = "cmdprov"
        Me.cmdprov.Size = New System.Drawing.Size(23, 23)
        Me.cmdprov.TabIndex = 8
        Me.cmdprov.Text = ">>"
        Me.cmdprov.UseVisualStyleBackColor = True
        '
        'txtProveedor
        '
        Me.txtProveedor.AcceptsTab = True
        Me.txtProveedor.Location = New System.Drawing.Point(47, 31)
        Me.txtProveedor.Multiline = True
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(270, 20)
        Me.txtProveedor.TabIndex = 13
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(48, 16)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lblProveedor.TabIndex = 7
        Me.lblProveedor.Text = "Proveedor"
        '
        'txtProvId
        '
        Me.txtProvId.AcceptsReturn = True
        Me.txtProvId.AcceptsTab = True
        Me.txtProvId.Location = New System.Drawing.Point(47, 32)
        Me.txtProvId.Multiline = True
        Me.txtProvId.Name = "txtProvId"
        Me.txtProvId.Size = New System.Drawing.Size(100, 20)
        Me.txtProvId.TabIndex = 9
        Me.txtProvId.Visible = False
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(19, 392)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 37
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(104, 392)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 38
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 443)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbGeneral)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.lblFechaLote)
        Me.Controls.Add(Me.dtpFechaLote)
        Me.Controls.Add(Me.txtLoteId)
        Me.Controls.Add(Me.lblNoLote)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLote"
        Me.Text = "Lotes"
        Me.gpbGeneral.ResumeLayout(False)
        Me.gpbGeneral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNoLote As System.Windows.Forms.Label
    Friend WithEvents txtLoteId As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaLote As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaLote As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents gpbGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents cmdprov As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents txtProvId As System.Windows.Forms.TextBox
    Friend WithEvents cmdTrigo As System.Windows.Forms.Button
    Friend WithEvents txtTrigo As System.Windows.Forms.TextBox
    Friend WithEvents lblTrigo As System.Windows.Forms.Label
    Friend WithEvents txtTrigoId As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblOtros As System.Windows.Forms.Label
    Friend WithEvents txtOtros As System.Windows.Forms.TextBox
    Friend WithEvents lblfllnnum As System.Windows.Forms.Label
    Friend WithEvents txtfllnnum As System.Windows.Forms.TextBox
    Friend WithEvents lblErgot As System.Windows.Forms.Label
    Friend WithEvents txtErgot As System.Windows.Forms.TextBox
    Friend WithEvents lblVomitoxina As System.Windows.Forms.Label
    Friend WithEvents txtVomitoxina As System.Windows.Forms.TextBox
    Friend WithEvents lblDockage As System.Windows.Forms.Label
    Friend WithEvents txtDockage As System.Windows.Forms.TextBox
    Friend WithEvents lblImpureza As System.Windows.Forms.Label
    Friend WithEvents txtImpureza As System.Windows.Forms.TextBox
    Friend WithEvents lblPesohtl As System.Windows.Forms.Label
    Friend WithEvents txtPesohtl As System.Windows.Forms.TextBox
    Friend WithEvents lblHumedad As System.Windows.Forms.Label
    Friend WithEvents txtHumedad As System.Windows.Forms.TextBox
    Friend WithEvents lblGrado As System.Windows.Forms.Label
    Friend WithEvents txtGrado As System.Windows.Forms.TextBox
    Friend WithEvents lblProteina As System.Windows.Forms.Label
    Friend WithEvents txtProteina As System.Windows.Forms.TextBox
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
