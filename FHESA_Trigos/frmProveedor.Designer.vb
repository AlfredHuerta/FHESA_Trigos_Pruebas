<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedor))
        Me.lblProvId = New System.Windows.Forms.Label()
        Me.txtProvId = New System.Windows.Forms.TextBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.lblTipoProv = New System.Windows.Forms.Label()
        Me.cmbTipoProv = New System.Windows.Forms.ComboBox()
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.lblContacto = New System.Windows.Forms.Label()
        Me.gpbDireccion = New System.Windows.Forms.GroupBox()
        Me.lblCodigoPosta = New System.Windows.Forms.Label()
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.lblPais = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.txtLocalidad = New System.Windows.Forms.TextBox()
        Me.lblLocalidad = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.txtNoInt = New System.Windows.Forms.TextBox()
        Me.lblNoInt = New System.Windows.Forms.Label()
        Me.txtNoExt = New System.Windows.Forms.TextBox()
        Me.lblNoExt = New System.Windows.Forms.Label()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gpbDireccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblProvId
        '
        Me.lblProvId.AutoSize = True
        Me.lblProvId.Location = New System.Drawing.Point(12, 18)
        Me.lblProvId.Name = "lblProvId"
        Me.lblProvId.Size = New System.Drawing.Size(19, 13)
        Me.lblProvId.TabIndex = 0
        Me.lblProvId.Text = "Nº"
        '
        'txtProvId
        '
        Me.txtProvId.AcceptsReturn = True
        Me.txtProvId.Location = New System.Drawing.Point(46, 15)
        Me.txtProvId.Name = "txtProvId"
        Me.txtProvId.Size = New System.Drawing.Size(121, 20)
        Me.txtProvId.TabIndex = 1
        '
        'chkActivo
        '
        Me.chkActivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(650, 18)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(56, 17)
        Me.chkActivo.TabIndex = 2
        Me.chkActivo.Text = "Activo"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblTipoProv
        '
        Me.lblTipoProv.AutoSize = True
        Me.lblTipoProv.Location = New System.Drawing.Point(12, 44)
        Me.lblTipoProv.Name = "lblTipoProv"
        Me.lblTipoProv.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoProv.TabIndex = 3
        Me.lblTipoProv.Text = "Tipo"
        '
        'cmbTipoProv
        '
        Me.cmbTipoProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoProv.FormattingEnabled = True
        Me.cmbTipoProv.Location = New System.Drawing.Point(46, 41)
        Me.cmbTipoProv.Name = "cmbTipoProv"
        Me.cmbTipoProv.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoProv.TabIndex = 4
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(12, 77)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 5
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.AcceptsReturn = True
        Me.txtRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRazonSocial.Location = New System.Drawing.Point(15, 93)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(336, 20)
        Me.txtRazonSocial.TabIndex = 6
        '
        'txtContacto
        '
        Me.txtContacto.AcceptsReturn = True
        Me.txtContacto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContacto.Location = New System.Drawing.Point(370, 93)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(336, 20)
        Me.txtContacto.TabIndex = 7
        '
        'lblContacto
        '
        Me.lblContacto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContacto.AutoSize = True
        Me.lblContacto.Location = New System.Drawing.Point(367, 77)
        Me.lblContacto.Name = "lblContacto"
        Me.lblContacto.Size = New System.Drawing.Size(50, 13)
        Me.lblContacto.TabIndex = 8
        Me.lblContacto.Text = "Contacto"
        '
        'gpbDireccion
        '
        Me.gpbDireccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpbDireccion.Controls.Add(Me.lblCodigoPosta)
        Me.gpbDireccion.Controls.Add(Me.txtCodigoPostal)
        Me.gpbDireccion.Controls.Add(Me.txtPais)
        Me.gpbDireccion.Controls.Add(Me.lblPais)
        Me.gpbDireccion.Controls.Add(Me.txtEstado)
        Me.gpbDireccion.Controls.Add(Me.lblEstado)
        Me.gpbDireccion.Controls.Add(Me.txtMunicipio)
        Me.gpbDireccion.Controls.Add(Me.lblMunicipio)
        Me.gpbDireccion.Controls.Add(Me.txtLocalidad)
        Me.gpbDireccion.Controls.Add(Me.lblLocalidad)
        Me.gpbDireccion.Controls.Add(Me.txtReferencia)
        Me.gpbDireccion.Controls.Add(Me.lblReferencia)
        Me.gpbDireccion.Controls.Add(Me.txtColonia)
        Me.gpbDireccion.Controls.Add(Me.lblColonia)
        Me.gpbDireccion.Controls.Add(Me.txtNoInt)
        Me.gpbDireccion.Controls.Add(Me.lblNoInt)
        Me.gpbDireccion.Controls.Add(Me.txtNoExt)
        Me.gpbDireccion.Controls.Add(Me.lblNoExt)
        Me.gpbDireccion.Controls.Add(Me.txtCalle)
        Me.gpbDireccion.Controls.Add(Me.lblCalle)
        Me.gpbDireccion.Location = New System.Drawing.Point(15, 129)
        Me.gpbDireccion.Name = "gpbDireccion"
        Me.gpbDireccion.Size = New System.Drawing.Size(691, 219)
        Me.gpbDireccion.TabIndex = 9
        Me.gpbDireccion.TabStop = False
        Me.gpbDireccion.Text = "Dirección"
        '
        'lblCodigoPosta
        '
        Me.lblCodigoPosta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCodigoPosta.AutoSize = True
        Me.lblCodigoPosta.Location = New System.Drawing.Point(507, 172)
        Me.lblCodigoPosta.Name = "lblCodigoPosta"
        Me.lblCodigoPosta.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoPosta.TabIndex = 19
        Me.lblCodigoPosta.Text = "Código Postal"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigoPostal.Location = New System.Drawing.Point(510, 188)
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(168, 20)
        Me.txtCodigoPostal.TabIndex = 18
        '
        'txtPais
        '
        Me.txtPais.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPais.Location = New System.Drawing.Point(242, 188)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(252, 20)
        Me.txtPais.TabIndex = 17
        '
        'lblPais
        '
        Me.lblPais.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPais.AutoSize = True
        Me.lblPais.Location = New System.Drawing.Point(239, 172)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(29, 13)
        Me.lblPais.TabIndex = 16
        Me.lblPais.Text = "País"
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(11, 188)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(213, 20)
        Me.txtEstado.TabIndex = 15
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(8, 172)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 14
        Me.lblEstado.Text = "Estado"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMunicipio.Location = New System.Drawing.Point(9, 149)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Size = New System.Drawing.Size(327, 20)
        Me.txtMunicipio.TabIndex = 13
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.Location = New System.Drawing.Point(6, 133)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(52, 13)
        Me.lblMunicipio.TabIndex = 12
        Me.lblMunicipio.Text = "Municipio"
        '
        'txtLocalidad
        '
        Me.txtLocalidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocalidad.Location = New System.Drawing.Point(9, 110)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Size = New System.Drawing.Size(327, 20)
        Me.txtLocalidad.TabIndex = 11
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.Location = New System.Drawing.Point(6, 94)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lblLocalidad.TabIndex = 10
        Me.lblLocalidad.Text = "Localidad"
        '
        'txtReferencia
        '
        Me.txtReferencia.AcceptsReturn = True
        Me.txtReferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReferencia.Location = New System.Drawing.Point(355, 71)
        Me.txtReferencia.Multiline = True
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReferencia.Size = New System.Drawing.Size(327, 98)
        Me.txtReferencia.TabIndex = 9
        '
        'lblReferencia
        '
        Me.lblReferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(352, 55)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(59, 13)
        Me.lblReferencia.TabIndex = 8
        Me.lblReferencia.Text = "Referencia"
        '
        'txtColonia
        '
        Me.txtColonia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtColonia.Location = New System.Drawing.Point(9, 71)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(327, 20)
        Me.txtColonia.TabIndex = 7
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.Location = New System.Drawing.Point(6, 55)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(42, 13)
        Me.lblColonia.TabIndex = 6
        Me.lblColonia.Text = "Colonia"
        '
        'txtNoInt
        '
        Me.txtNoInt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoInt.Location = New System.Drawing.Point(521, 32)
        Me.txtNoInt.Name = "txtNoInt"
        Me.txtNoInt.Size = New System.Drawing.Size(157, 20)
        Me.txtNoInt.TabIndex = 5
        '
        'lblNoInt
        '
        Me.lblNoInt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoInt.AutoSize = True
        Me.lblNoInt.Location = New System.Drawing.Point(518, 16)
        Me.lblNoInt.Name = "lblNoInt"
        Me.lblNoInt.Size = New System.Drawing.Size(59, 13)
        Me.lblNoInt.TabIndex = 4
        Me.lblNoInt.Text = "No. Interior"
        '
        'txtNoExt
        '
        Me.txtNoExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNoExt.Location = New System.Drawing.Point(355, 32)
        Me.txtNoExt.Name = "txtNoExt"
        Me.txtNoExt.Size = New System.Drawing.Size(157, 20)
        Me.txtNoExt.TabIndex = 3
        '
        'lblNoExt
        '
        Me.lblNoExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNoExt.AutoSize = True
        Me.lblNoExt.Location = New System.Drawing.Point(352, 16)
        Me.lblNoExt.Name = "lblNoExt"
        Me.lblNoExt.Size = New System.Drawing.Size(62, 13)
        Me.lblNoExt.TabIndex = 2
        Me.lblNoExt.Text = "No. Exterior"
        '
        'txtCalle
        '
        Me.txtCalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCalle.Location = New System.Drawing.Point(9, 32)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(327, 20)
        Me.txtCalle.TabIndex = 1
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.Location = New System.Drawing.Point(6, 16)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(30, 13)
        Me.lblCalle.TabIndex = 0
        Me.lblCalle.Text = "Calle"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(100, 366)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 40
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(15, 366)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 39
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 402)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.gpbDireccion)
        Me.Controls.Add(Me.lblContacto)
        Me.Controls.Add(Me.txtContacto)
        Me.Controls.Add(Me.txtRazonSocial)
        Me.Controls.Add(Me.lblRazonSocial)
        Me.Controls.Add(Me.cmbTipoProv)
        Me.Controls.Add(Me.lblTipoProv)
        Me.Controls.Add(Me.chkActivo)
        Me.Controls.Add(Me.txtProvId)
        Me.Controls.Add(Me.lblProvId)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProveedor"
        Me.Text = "Proveedor"
        Me.gpbDireccion.ResumeLayout(False)
        Me.gpbDireccion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProvId As System.Windows.Forms.Label
    Friend WithEvents txtProvId As System.Windows.Forms.TextBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblTipoProv As System.Windows.Forms.Label
    Friend WithEvents cmbTipoProv As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents lblContacto As System.Windows.Forms.Label
    Friend WithEvents gpbDireccion As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoInt As System.Windows.Forms.TextBox
    Friend WithEvents lblNoInt As System.Windows.Forms.Label
    Friend WithEvents txtNoExt As System.Windows.Forms.TextBox
    Friend WithEvents lblNoExt As System.Windows.Forms.Label
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalidad As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblCodigoPosta As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
End Class
