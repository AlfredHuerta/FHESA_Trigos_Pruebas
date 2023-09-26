<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracion))
        Me.tbcConfiguracion = New System.Windows.Forms.TabControl()
        Me.tbpEmpresa = New System.Windows.Forms.TabPage()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
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
        Me.lblRazonSocial = New System.Windows.Forms.Label()
        Me.tbpAcceso = New System.Windows.Forms.TabPage()
        Me.cmdReportes = New System.Windows.Forms.Button()
        Me.txtReportes = New System.Windows.Forms.TextBox()
        Me.lblReportes = New System.Windows.Forms.Label()
        Me.cmdImagenes = New System.Windows.Forms.Button()
        Me.txtImagenes = New System.Windows.Forms.TextBox()
        Me.lblImagenes = New System.Windows.Forms.Label()
        Me.cmdAdjuntos = New System.Windows.Forms.Button()
        Me.txtAdjuntos = New System.Windows.Forms.TextBox()
        Me.lblAdjuntos = New System.Windows.Forms.Label()
        Me.tbpMiscelaneo = New System.Windows.Forms.TabPage()
        Me.txtAlRoja = New System.Windows.Forms.TextBox()
        Me.lblAlRoja = New System.Windows.Forms.Label()
        Me.txtAlAmarilla = New System.Windows.Forms.TextBox()
        Me.lblAlAmarilla = New System.Windows.Forms.Label()
        Me.lblEmbarques = New System.Windows.Forms.Label()
        Me.txtTnlmax = New System.Windows.Forms.TextBox()
        Me.lblTnlmax = New System.Windows.Forms.Label()
        Me.txtTnlmin = New System.Windows.Forms.TextBox()
        Me.lblTnlmin = New System.Windows.Forms.Label()
        Me.tbpConexion = New System.Windows.Forms.TabPage()
        Me.lblConfiguracionConexion = New System.Windows.Forms.Label()
        Me.txtUsuarioBd = New System.Windows.Forms.TextBox()
        Me.lblUsuarioBd = New System.Windows.Forms.Label()
        Me.txtBaseDatos = New System.Windows.Forms.TextBox()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.txtServidorBd = New System.Windows.Forms.TextBox()
        Me.lblServidorBd = New System.Windows.Forms.Label()
        Me.cmbConexion = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.tbcConfiguracion.SuspendLayout()
        Me.tbpEmpresa.SuspendLayout()
        Me.gpbDireccion.SuspendLayout()
        Me.tbpAcceso.SuspendLayout()
        Me.tbpMiscelaneo.SuspendLayout()
        Me.tbpConexion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcConfiguracion
        '
        Me.tbcConfiguracion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcConfiguracion.Controls.Add(Me.tbpEmpresa)
        Me.tbcConfiguracion.Controls.Add(Me.tbpAcceso)
        Me.tbcConfiguracion.Controls.Add(Me.tbpMiscelaneo)
        Me.tbcConfiguracion.Controls.Add(Me.tbpConexion)
        Me.tbcConfiguracion.Location = New System.Drawing.Point(12, 12)
        Me.tbcConfiguracion.Name = "tbcConfiguracion"
        Me.tbcConfiguracion.SelectedIndex = 0
        Me.tbcConfiguracion.Size = New System.Drawing.Size(738, 345)
        Me.tbcConfiguracion.TabIndex = 0
        '
        'tbpEmpresa
        '
        Me.tbpEmpresa.Controls.Add(Me.txtRazonSocial)
        Me.tbpEmpresa.Controls.Add(Me.gpbDireccion)
        Me.tbpEmpresa.Controls.Add(Me.lblRazonSocial)
        Me.tbpEmpresa.Location = New System.Drawing.Point(4, 22)
        Me.tbpEmpresa.Name = "tbpEmpresa"
        Me.tbpEmpresa.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpEmpresa.Size = New System.Drawing.Size(730, 319)
        Me.tbpEmpresa.TabIndex = 0
        Me.tbpEmpresa.Text = "Empresa"
        Me.tbpEmpresa.UseVisualStyleBackColor = True
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(18, 34)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(691, 20)
        Me.txtRazonSocial.TabIndex = 1
        '
        'gpbDireccion
        '
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
        Me.gpbDireccion.Location = New System.Drawing.Point(18, 77)
        Me.gpbDireccion.Name = "gpbDireccion"
        Me.gpbDireccion.Size = New System.Drawing.Size(691, 219)
        Me.gpbDireccion.TabIndex = 2
        Me.gpbDireccion.TabStop = False
        Me.gpbDireccion.Text = "Dirección"
        '
        'lblCodigoPosta
        '
        Me.lblCodigoPosta.AutoSize = True
        Me.lblCodigoPosta.Location = New System.Drawing.Point(507, 172)
        Me.lblCodigoPosta.Name = "lblCodigoPosta"
        Me.lblCodigoPosta.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoPosta.TabIndex = 19
        Me.lblCodigoPosta.Text = "Código Postal"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.Location = New System.Drawing.Point(510, 188)
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.Size = New System.Drawing.Size(168, 20)
        Me.txtCodigoPostal.TabIndex = 18
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(242, 188)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(252, 20)
        Me.txtPais.TabIndex = 17
        '
        'lblPais
        '
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
        Me.txtReferencia.Location = New System.Drawing.Point(355, 71)
        Me.txtReferencia.Multiline = True
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtReferencia.Size = New System.Drawing.Size(327, 98)
        Me.txtReferencia.TabIndex = 9
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(352, 55)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(59, 13)
        Me.lblReferencia.TabIndex = 8
        Me.lblReferencia.Text = "Referencia"
        '
        'txtColonia
        '
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
        Me.txtNoInt.Location = New System.Drawing.Point(521, 32)
        Me.txtNoInt.Name = "txtNoInt"
        Me.txtNoInt.Size = New System.Drawing.Size(157, 20)
        Me.txtNoInt.TabIndex = 5
        '
        'lblNoInt
        '
        Me.lblNoInt.AutoSize = True
        Me.lblNoInt.Location = New System.Drawing.Point(518, 16)
        Me.lblNoInt.Name = "lblNoInt"
        Me.lblNoInt.Size = New System.Drawing.Size(59, 13)
        Me.lblNoInt.TabIndex = 4
        Me.lblNoInt.Text = "No. Interior"
        '
        'txtNoExt
        '
        Me.txtNoExt.Location = New System.Drawing.Point(355, 32)
        Me.txtNoExt.Name = "txtNoExt"
        Me.txtNoExt.Size = New System.Drawing.Size(157, 20)
        Me.txtNoExt.TabIndex = 3
        '
        'lblNoExt
        '
        Me.lblNoExt.AutoSize = True
        Me.lblNoExt.Location = New System.Drawing.Point(352, 16)
        Me.lblNoExt.Name = "lblNoExt"
        Me.lblNoExt.Size = New System.Drawing.Size(62, 13)
        Me.lblNoExt.TabIndex = 2
        Me.lblNoExt.Text = "No. Exterior"
        '
        'txtCalle
        '
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
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(15, 18)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblRazonSocial.TabIndex = 0
        Me.lblRazonSocial.Text = "Razón Social"
        '
        'tbpAcceso
        '
        Me.tbpAcceso.Controls.Add(Me.cmdReportes)
        Me.tbpAcceso.Controls.Add(Me.txtReportes)
        Me.tbpAcceso.Controls.Add(Me.lblReportes)
        Me.tbpAcceso.Controls.Add(Me.cmdImagenes)
        Me.tbpAcceso.Controls.Add(Me.txtImagenes)
        Me.tbpAcceso.Controls.Add(Me.lblImagenes)
        Me.tbpAcceso.Controls.Add(Me.cmdAdjuntos)
        Me.tbpAcceso.Controls.Add(Me.txtAdjuntos)
        Me.tbpAcceso.Controls.Add(Me.lblAdjuntos)
        Me.tbpAcceso.Location = New System.Drawing.Point(4, 22)
        Me.tbpAcceso.Name = "tbpAcceso"
        Me.tbpAcceso.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAcceso.Size = New System.Drawing.Size(730, 319)
        Me.tbpAcceso.TabIndex = 1
        Me.tbpAcceso.Text = "Almacenamiento"
        Me.tbpAcceso.UseVisualStyleBackColor = True
        '
        'cmdReportes
        '
        Me.cmdReportes.Location = New System.Drawing.Point(662, 139)
        Me.cmdReportes.Name = "cmdReportes"
        Me.cmdReportes.Size = New System.Drawing.Size(21, 23)
        Me.cmdReportes.TabIndex = 8
        Me.cmdReportes.Text = "..."
        Me.cmdReportes.UseVisualStyleBackColor = True
        '
        'txtReportes
        '
        Me.txtReportes.Location = New System.Drawing.Point(20, 139)
        Me.txtReportes.Name = "txtReportes"
        Me.txtReportes.Size = New System.Drawing.Size(636, 20)
        Me.txtReportes.TabIndex = 7
        '
        'lblReportes
        '
        Me.lblReportes.AutoSize = True
        Me.lblReportes.Location = New System.Drawing.Point(17, 123)
        Me.lblReportes.Name = "lblReportes"
        Me.lblReportes.Size = New System.Drawing.Size(100, 13)
        Me.lblReportes.TabIndex = 6
        Me.lblReportes.Text = "Carpeta de reportes"
        '
        'cmdImagenes
        '
        Me.cmdImagenes.Location = New System.Drawing.Point(662, 85)
        Me.cmdImagenes.Name = "cmdImagenes"
        Me.cmdImagenes.Size = New System.Drawing.Size(21, 23)
        Me.cmdImagenes.TabIndex = 5
        Me.cmdImagenes.Text = "..."
        Me.cmdImagenes.UseVisualStyleBackColor = True
        '
        'txtImagenes
        '
        Me.txtImagenes.Location = New System.Drawing.Point(20, 85)
        Me.txtImagenes.Name = "txtImagenes"
        Me.txtImagenes.Size = New System.Drawing.Size(636, 20)
        Me.txtImagenes.TabIndex = 4
        '
        'lblImagenes
        '
        Me.lblImagenes.AutoSize = True
        Me.lblImagenes.Location = New System.Drawing.Point(17, 69)
        Me.lblImagenes.Name = "lblImagenes"
        Me.lblImagenes.Size = New System.Drawing.Size(107, 13)
        Me.lblImagenes.TabIndex = 3
        Me.lblImagenes.Text = "Carpeta de imágenes"
        '
        'cmdAdjuntos
        '
        Me.cmdAdjuntos.Location = New System.Drawing.Point(662, 37)
        Me.cmdAdjuntos.Name = "cmdAdjuntos"
        Me.cmdAdjuntos.Size = New System.Drawing.Size(21, 23)
        Me.cmdAdjuntos.TabIndex = 2
        Me.cmdAdjuntos.Text = "..."
        Me.cmdAdjuntos.UseVisualStyleBackColor = True
        '
        'txtAdjuntos
        '
        Me.txtAdjuntos.Location = New System.Drawing.Point(20, 37)
        Me.txtAdjuntos.Name = "txtAdjuntos"
        Me.txtAdjuntos.Size = New System.Drawing.Size(636, 20)
        Me.txtAdjuntos.TabIndex = 1
        '
        'lblAdjuntos
        '
        Me.lblAdjuntos.AutoSize = True
        Me.lblAdjuntos.Location = New System.Drawing.Point(17, 21)
        Me.lblAdjuntos.Name = "lblAdjuntos"
        Me.lblAdjuntos.Size = New System.Drawing.Size(145, 13)
        Me.lblAdjuntos.TabIndex = 0
        Me.lblAdjuntos.Text = "Carpeta de archivos adjuntos"
        '
        'tbpMiscelaneo
        '
        Me.tbpMiscelaneo.Controls.Add(Me.txtAlRoja)
        Me.tbpMiscelaneo.Controls.Add(Me.lblAlRoja)
        Me.tbpMiscelaneo.Controls.Add(Me.txtAlAmarilla)
        Me.tbpMiscelaneo.Controls.Add(Me.lblAlAmarilla)
        Me.tbpMiscelaneo.Controls.Add(Me.lblEmbarques)
        Me.tbpMiscelaneo.Controls.Add(Me.txtTnlmax)
        Me.tbpMiscelaneo.Controls.Add(Me.lblTnlmax)
        Me.tbpMiscelaneo.Controls.Add(Me.txtTnlmin)
        Me.tbpMiscelaneo.Controls.Add(Me.lblTnlmin)
        Me.tbpMiscelaneo.Location = New System.Drawing.Point(4, 22)
        Me.tbpMiscelaneo.Name = "tbpMiscelaneo"
        Me.tbpMiscelaneo.Size = New System.Drawing.Size(730, 319)
        Me.tbpMiscelaneo.TabIndex = 2
        Me.tbpMiscelaneo.Text = "Misceláneo"
        Me.tbpMiscelaneo.UseVisualStyleBackColor = True
        '
        'txtAlRoja
        '
        Me.txtAlRoja.Location = New System.Drawing.Point(268, 111)
        Me.txtAlRoja.Name = "txtAlRoja"
        Me.txtAlRoja.Size = New System.Drawing.Size(123, 20)
        Me.txtAlRoja.TabIndex = 9
        '
        'lblAlRoja
        '
        Me.lblAlRoja.AutoSize = True
        Me.lblAlRoja.Location = New System.Drawing.Point(265, 95)
        Me.lblAlRoja.Name = "lblAlRoja"
        Me.lblAlRoja.Size = New System.Drawing.Size(123, 13)
        Me.lblAlRoja.TabIndex = 8
        Me.lblAlRoja.Text = "Alerta Roja Dif. Recibido"
        '
        'txtAlAmarilla
        '
        Me.txtAlAmarilla.Location = New System.Drawing.Point(268, 57)
        Me.txtAlAmarilla.Name = "txtAlAmarilla"
        Me.txtAlAmarilla.Size = New System.Drawing.Size(123, 20)
        Me.txtAlAmarilla.TabIndex = 7
        '
        'lblAlAmarilla
        '
        Me.lblAlAmarilla.AutoSize = True
        Me.lblAlAmarilla.Location = New System.Drawing.Point(265, 41)
        Me.lblAlAmarilla.Name = "lblAlAmarilla"
        Me.lblAlAmarilla.Size = New System.Drawing.Size(137, 13)
        Me.lblAlAmarilla.TabIndex = 6
        Me.lblAlAmarilla.Text = "Alerta Amarilla Dif. Recibido"
        '
        'lblEmbarques
        '
        Me.lblEmbarques.AutoSize = True
        Me.lblEmbarques.Location = New System.Drawing.Point(36, 18)
        Me.lblEmbarques.Name = "lblEmbarques"
        Me.lblEmbarques.Size = New System.Drawing.Size(60, 13)
        Me.lblEmbarques.TabIndex = 5
        Me.lblEmbarques.Text = "Embarques"
        '
        'txtTnlmax
        '
        Me.txtTnlmax.Location = New System.Drawing.Point(73, 111)
        Me.txtTnlmax.Name = "txtTnlmax"
        Me.txtTnlmax.Size = New System.Drawing.Size(153, 20)
        Me.txtTnlmax.TabIndex = 4
        '
        'lblTnlmax
        '
        Me.lblTnlmax.AutoSize = True
        Me.lblTnlmax.Location = New System.Drawing.Point(70, 95)
        Me.lblTnlmax.Name = "lblTnlmax"
        Me.lblTnlmax.Size = New System.Drawing.Size(87, 13)
        Me.lblTnlmax.TabIndex = 3
        Me.lblTnlmax.Text = "Tonelaje Máximo"
        '
        'txtTnlmin
        '
        Me.txtTnlmin.Location = New System.Drawing.Point(73, 57)
        Me.txtTnlmin.Name = "txtTnlmin"
        Me.txtTnlmin.Size = New System.Drawing.Size(153, 20)
        Me.txtTnlmin.TabIndex = 2
        '
        'lblTnlmin
        '
        Me.lblTnlmin.AutoSize = True
        Me.lblTnlmin.Location = New System.Drawing.Point(70, 41)
        Me.lblTnlmin.Name = "lblTnlmin"
        Me.lblTnlmin.Size = New System.Drawing.Size(86, 13)
        Me.lblTnlmin.TabIndex = 1
        Me.lblTnlmin.Text = "Tonelaje Mínimo"
        '
        'tbpConexion
        '
        Me.tbpConexion.Controls.Add(Me.lblConfiguracionConexion)
        Me.tbpConexion.Controls.Add(Me.txtUsuarioBd)
        Me.tbpConexion.Controls.Add(Me.lblUsuarioBd)
        Me.tbpConexion.Controls.Add(Me.txtBaseDatos)
        Me.tbpConexion.Controls.Add(Me.lblBaseDatos)
        Me.tbpConexion.Controls.Add(Me.txtServidorBd)
        Me.tbpConexion.Controls.Add(Me.lblServidorBd)
        Me.tbpConexion.Controls.Add(Me.cmbConexion)
        Me.tbpConexion.Location = New System.Drawing.Point(4, 22)
        Me.tbpConexion.Name = "tbpConexion"
        Me.tbpConexion.Size = New System.Drawing.Size(730, 319)
        Me.tbpConexion.TabIndex = 3
        Me.tbpConexion.Text = "Conexión"
        Me.tbpConexion.UseVisualStyleBackColor = True
        '
        'lblConfiguracionConexion
        '
        Me.lblConfiguracionConexion.AutoSize = True
        Me.lblConfiguracionConexion.Location = New System.Drawing.Point(24, 23)
        Me.lblConfiguracionConexion.Name = "lblConfiguracionConexion"
        Me.lblConfiguracionConexion.Size = New System.Drawing.Size(134, 13)
        Me.lblConfiguracionConexion.TabIndex = 7
        Me.lblConfiguracionConexion.Text = "Configuración de Conexión"
        '
        'txtUsuarioBd
        '
        Me.txtUsuarioBd.Location = New System.Drawing.Point(105, 108)
        Me.txtUsuarioBd.Name = "txtUsuarioBd"
        Me.txtUsuarioBd.Size = New System.Drawing.Size(185, 20)
        Me.txtUsuarioBd.TabIndex = 6
        '
        'lblUsuarioBd
        '
        Me.lblUsuarioBd.AutoSize = True
        Me.lblUsuarioBd.Location = New System.Drawing.Point(24, 111)
        Me.lblUsuarioBd.Name = "lblUsuarioBd"
        Me.lblUsuarioBd.Size = New System.Drawing.Size(33, 13)
        Me.lblUsuarioBd.TabIndex = 5
        Me.lblUsuarioBd.Text = "Login"
        '
        'txtBaseDatos
        '
        Me.txtBaseDatos.Location = New System.Drawing.Point(105, 77)
        Me.txtBaseDatos.Name = "txtBaseDatos"
        Me.txtBaseDatos.Size = New System.Drawing.Size(185, 20)
        Me.txtBaseDatos.TabIndex = 4
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.AutoSize = True
        Me.lblBaseDatos.Location = New System.Drawing.Point(24, 80)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(77, 13)
        Me.lblBaseDatos.TabIndex = 3
        Me.lblBaseDatos.Text = "Base de Datos"
        '
        'txtServidorBd
        '
        Me.txtServidorBd.Location = New System.Drawing.Point(105, 44)
        Me.txtServidorBd.Name = "txtServidorBd"
        Me.txtServidorBd.Size = New System.Drawing.Size(185, 20)
        Me.txtServidorBd.TabIndex = 2
        '
        'lblServidorBd
        '
        Me.lblServidorBd.AutoSize = True
        Me.lblServidorBd.Location = New System.Drawing.Point(24, 47)
        Me.lblServidorBd.Name = "lblServidorBd"
        Me.lblServidorBd.Size = New System.Drawing.Size(65, 13)
        Me.lblServidorBd.TabIndex = 1
        Me.lblServidorBd.Text = "Servidor Bd."
        '
        'cmbConexion
        '
        Me.cmbConexion.Location = New System.Drawing.Point(150, 148)
        Me.cmbConexion.Name = "cmbConexion"
        Me.cmbConexion.Size = New System.Drawing.Size(140, 30)
        Me.cmbConexion.TabIndex = 0
        Me.cmbConexion.Text = "Reconfigurar Conexión..."
        Me.cmbConexion.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(97, 378)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 42
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(12, 378)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 41
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 415)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.tbcConfiguracion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmConfiguracion"
        Me.Text = "Configuración General"
        Me.tbcConfiguracion.ResumeLayout(False)
        Me.tbpEmpresa.ResumeLayout(False)
        Me.tbpEmpresa.PerformLayout()
        Me.gpbDireccion.ResumeLayout(False)
        Me.gpbDireccion.PerformLayout()
        Me.tbpAcceso.ResumeLayout(False)
        Me.tbpAcceso.PerformLayout()
        Me.tbpMiscelaneo.ResumeLayout(False)
        Me.tbpMiscelaneo.PerformLayout()
        Me.tbpConexion.ResumeLayout(False)
        Me.tbpConexion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcConfiguracion As System.Windows.Forms.TabControl
    Friend WithEvents tbpEmpresa As System.Windows.Forms.TabPage
    Friend WithEvents tbpAcceso As System.Windows.Forms.TabPage
    Friend WithEvents tbpMiscelaneo As System.Windows.Forms.TabPage
    Friend WithEvents gpbDireccion As System.Windows.Forms.GroupBox
    Friend WithEvents lblCodigoPosta As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
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
    Friend WithEvents txtNoInt As System.Windows.Forms.TextBox
    Friend WithEvents lblNoInt As System.Windows.Forms.Label
    Friend WithEvents txtNoExt As System.Windows.Forms.TextBox
    Friend WithEvents lblNoExt As System.Windows.Forms.Label
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblRazonSocial As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdReportes As System.Windows.Forms.Button
    Friend WithEvents txtReportes As System.Windows.Forms.TextBox
    Friend WithEvents lblReportes As System.Windows.Forms.Label
    Friend WithEvents cmdImagenes As System.Windows.Forms.Button
    Friend WithEvents txtImagenes As System.Windows.Forms.TextBox
    Friend WithEvents lblImagenes As System.Windows.Forms.Label
    Friend WithEvents cmdAdjuntos As System.Windows.Forms.Button
    Friend WithEvents txtAdjuntos As System.Windows.Forms.TextBox
    Friend WithEvents lblAdjuntos As System.Windows.Forms.Label
    Friend WithEvents txtAlRoja As System.Windows.Forms.TextBox
    Friend WithEvents lblAlRoja As System.Windows.Forms.Label
    Friend WithEvents txtAlAmarilla As System.Windows.Forms.TextBox
    Friend WithEvents lblAlAmarilla As System.Windows.Forms.Label
    Friend WithEvents lblEmbarques As System.Windows.Forms.Label
    Friend WithEvents txtTnlmax As System.Windows.Forms.TextBox
    Friend WithEvents lblTnlmax As System.Windows.Forms.Label
    Friend WithEvents txtTnlmin As System.Windows.Forms.TextBox
    Friend WithEvents lblTnlmin As System.Windows.Forms.Label
    Friend WithEvents tbpConexion As System.Windows.Forms.TabPage
    Friend WithEvents cmbConexion As System.Windows.Forms.Button
    Friend WithEvents txtServidorBd As System.Windows.Forms.TextBox
    Friend WithEvents lblServidorBd As System.Windows.Forms.Label
    Friend WithEvents lblConfiguracionConexion As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioBd As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuarioBd As System.Windows.Forms.Label
    Friend WithEvents txtBaseDatos As System.Windows.Forms.TextBox
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
End Class
