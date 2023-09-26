Imports Genericas

Public Class frmPrincipal
    Private msg As Mensaje
    Private cliente As ClienteSql
    Private Cnfg As ObjEntidades.Configuracion
    Private Usuario As ObjEntidades.Usuario

    Private genW As GenericasWin
    Private frmVisor As frmVisorEventos
    Private infDoc As InformacionDocumento

    Private WithEvents mnuMostrarEvSistema As ToolStripMenuItem

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not cliente Is Nothing Then
            cliente.cerrarConexion()

            genW.publicar(infDoc, cliente.Mensaje)
            cliente = Nothing
        End If
    End Sub

    Private Sub frmPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.B Then
            bloquearPantalla()
        End If
    End Sub


    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim frmConexion As frmConexion = Nothing

        Try
            msg = New Mensaje
            Me.KeyPreview = True

            frmConexion = New frmConexion
            frmConexion.ShowDialog()

            msg = frmConexion.Mensaje
            cliente = frmConexion.ClienteSql
            tstBaseDatos.Text = cliente.ParametrosConexion.BaseDeDatos

            agregarContextuales()
            inhabilitarFunciones()

            infDoc = New InformacionDocumento(SysEnums.TiposDocumentos.dNinguno, cliente.ParametrosConexion.BaseDeDatos, _
                                              "", "", "", "")
            inicializarVisor()
            genW.publicar(infDoc, msg)

            If Not msg.EsError Then
                Cnfg = New ObjEntidades.Configuracion(cliente, "0")
                If Not Cnfg.Mensaje.EsError Then
                    genW.publicar(infDoc, _
                                  New Mensaje("Logística de Trigos v" + My.Application.Info.Version.ToString + " listo para usarse.", _
                                              SysEnums.TiposMensaje.mInformacion))

                    Dim frmIsesion As frmSesion = New frmSesion(cliente, genW, Cnfg)
                    frmIsesion.ShowDialog()
                    If Not frmIsesion.SesionIniciada Then End

                    Usuario = frmIsesion.Usuario
                    Me.Text = "Logística de Trigos - En la sesión de " + Usuario.Nombre + " " + Usuario.Apllidop + " " + Usuario.Apllidom
                    habilitarFunciones()
                Else
                    genW.publicar(infDoc, Cnfg.Mensaje)
                    Cnfg.liberarObjetos()
                End If

            End If
        Catch ex As Exception
            msg.setError("No fue posible inicializar la instancia principal: " + ex.Message)
        End Try
    End Sub

    Private Sub inicializarVisor()
        Dim gW As GenericasWin = New GenericasWin()


        frmVisor = New frmVisorEventos
        frmVisor.MdiParent = Me
        frmVisor.Show()
        frmVisor.Width = Me.Width - 40
        frmVisor.Location = New Point(0, Me.Size.Height - frmVisor.Size.Height - 100)
        frmVisor.Visible = MensajesDelSistemaToolStripMenuItem.Checked
        frmVisor.Text = "Visor de Eventos"
        frmVisor.chkGuardarLog.Text = "Guardar Log"

        If frmVisor.tbcVisor.TabPages("tbp" + cliente.ParametrosConexion.BaseDeDatos) Is Nothing Then
            gW.agregarPestaniaBaseDatos(frmVisor.tbcVisor, cliente.ParametrosConexion.BaseDeDatos, _
                                    "Visor de actividad " + cliente.ParametrosConexion.BaseDeDatos)
        End If

        genW = New GenericasWin(New PropiedadesPublicacion(frmVisor.tbcVisor, _
                                                             frmVisor.chkGuardarLog, tstEstado))
    End Sub

    Private Sub agregarContextuales()
        Dim strip As New ContextMenuStrip()

        mnuMostrarEvSistema = New ToolStripMenuItem()
        mnuMostrarEvSistema.Text = "Mostrar Visor Eventos"

        staBarraEstado.ContextMenuStrip = strip
        staBarraEstado.ContextMenuStrip.Items.Add(mnuMostrarEvSistema)
    End Sub

    Private Sub tsbLotes_Click(sender As Object, e As EventArgs) Handles tsbLotes.Click
        Dim frmLotes As frmLote = New frmLote(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmLotes.MdiParent = Me
        frmLotes.Show()

    End Sub

    Private Sub MensajesDelSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MensajesDelSistemaToolStripMenuItem.Click
        frmVisor.Visible = MensajesDelSistemaToolStripMenuItem.Checked
    End Sub

    Private Sub tsbPrimerR_Click(sender As Object, e As EventArgs) Handles tsbPrimerR.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteMoverRegistros Then
                frm.moverRegistro("1")
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para pasar al primer registro.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbRegistroU_Click(sender As Object, e As EventArgs) Handles tsbRegistroU.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteMoverRegistros Then
                frm.moverRegistro("4")
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para pasar al último registro.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbRegistroA_Click(sender As Object, e As EventArgs) Handles tsbRegistroA.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteMoverRegistros Then
                frm.moverRegistro("2")
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para pasar al registro anterior.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbRegistroS_Click(sender As Object, e As EventArgs) Handles tsbRegistroS.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteMoverRegistros Then
                frm.moverRegistro("3")
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para pasar al registro siguiente.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbNuevo_Click(sender As Object, e As EventArgs) Handles tsbNuevo.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteAlterarDocumentos Then
                frm.setCrear()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para crear documento.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbBuscar_Click(sender As Object, e As EventArgs) Handles tsbBuscar.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteAlterarDocumentos Then
                frm.setBuscar()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para buscar documento.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteAlterarEstado Then
                frm.cerrarAbrir()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para cerrar documento.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteAlterarEstado Then
                frm.cancelar()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para cancelar documento.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem.Click
        Dim frmProv As frmProveedor = New frmProveedor(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmProv.MdiParent = Me
        frmProv.Show()
    End Sub

    Private Sub TrigosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrigosToolStripMenuItem.Click
        Dim frmTrigo As frmTrigo = New frmTrigo(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmTrigo.MdiParent = Me
        frmTrigo.Show()
    End Sub

    Private Sub LotesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LotesToolStripMenuItem1.Click
        Dim frmLotes As frmLote = New frmLote(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmLotes.MdiParent = Me
        frmLotes.Show()
    End Sub


    Private Sub tsbOrdenes_Click(sender As Object, e As EventArgs) Handles tsbOrdenes.Click
        Dim frmOrd As frmOrden = New frmOrden(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmOrd.MdiParent = Me
        frmOrd.Show()
    End Sub

    Private Sub OrdenesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OrdenesToolStripMenuItem2.Click
        Dim frmOrd As frmOrden = New frmOrden(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmOrd.MdiParent = Me
        frmOrd.Show()
    End Sub

    Private Sub OrígenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrígenesToolStripMenuItem.Click
        Dim frmOrig As frmOrigen = New frmOrigen(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmOrig.MdiParent = Me
        frmOrig.Show()
    End Sub

    Private Sub tsbEmbarques_Click(sender As Object, e As EventArgs) Handles tsbEmbarques.Click
        Dim frmEmb As frmEmbarque = New frmEmbarque(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmEmb.MdiParent = Me
        frmEmb.Show()
    End Sub

    Private Sub EmbarquesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EmbarquesToolStripMenuItem2.Click
        Dim frmEmb As frmEmbarque = New frmEmbarque(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmEmb.MdiParent = Me
        frmEmb.Show()
    End Sub

    Private Sub DestinosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DestinosToolStripMenuItem.Click
        Dim frmDest As frmDestino = New frmDestino(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmDest.MdiParent = Me
        frmDest.Show()
    End Sub

    Private Sub OperadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperadoresToolStripMenuItem.Click
        Dim frmop As frmOperador = New frmOperador(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmop.MdiParent = Me
        frmop.Show()
    End Sub

    Private Sub tsbAjustes_Click(sender As Object, e As EventArgs) Handles tsbAjustes.Click
        Dim frmaj As frmAjuste = New frmAjuste(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmaj.MdiParent = Me
        frmaj.Show()
    End Sub

    Private Sub AjustesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AjustesToolStripMenuItem2.Click
        Dim frmaj As frmAjuste = New frmAjuste(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmaj.MdiParent = Me
        frmaj.Show()
    End Sub

    Private Sub tsbVentas_Click(sender As Object, e As EventArgs) Handles tsbVentas.Click
        Dim frmven As frmVenta = New frmVenta(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmven.MdiParent = Me
        frmven.Show()
    End Sub

    Private Sub VentasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem2.Click
        Dim frmven As frmVenta = New frmVenta(cliente, genW, SysEnums.Modos.mCrear, Cnfg, Usuario)
        frmven.MdiParent = Me
        frmven.Show()
    End Sub

    Private Sub ReporteDeTrigosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportesSToolStripMenuItem.Click
        Dim frmRdummy As frmReportes = New frmReportes(cliente, genW, Cnfg, Usuario)
        frmRdummy.MdiParent = Me
        frmRdummy.Show()
    End Sub

    Private Sub tsbHistorialCambios_Click(sender As Object, e As EventArgs) Handles tsbHistorialCambios.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteBuscarHistorial Then
                frm.buscarHistorial()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para buscar historial del documento.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub FacturaFletesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaFletesToolStripMenuItem.Click
        Dim frmSinFl As frmFacturaFlete = New frmFacturaFlete(cliente, genW, Cnfg, Usuario)
        frmSinFl.MdiParent = Me
        frmSinFl.Show()
    End Sub

    Private Sub PerfilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PerfilesToolStripMenuItem.Click
        Dim frmprfl As frmPerfil = New frmPerfil(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmprfl.MdiParent = Me
        frmprfl.Show()
    End Sub

    Private Sub OpcionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpcionesToolStripMenuItem.Click
        Dim frmConf As frmConfiguracion = New frmConfiguracion(cliente, genW, Cnfg, Usuario)
        frmConf.MdiParent = Me
        frmConf.Show()
    End Sub

    Private Sub CargaMasivaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargaMasivaToolStripMenuItem.Click
        Dim frmCargaM As frmCargadorMasivoEmb = New frmCargadorMasivoEmb(cliente, genW, Cnfg, Usuario)
        frmCargaM.MdiParent = Me
        frmCargaM.Show()
    End Sub

    Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteImprimir Then
                frm.imprimir()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para impresión de documentos.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub UsuariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem1.Click
        Dim frmusr As frmUsuario = New frmUsuario(cliente, genW, SysEnums.Modos.mCrear, Usuario)
        frmusr.MdiParent = Me
        frmusr.Show()
    End Sub

    Public Sub inhabilitarFunciones()
        HerramientasToolStripMenuItem.Enabled = False
        OpcionesToolStripMenuItem.Enabled = False
        AdministraciónToolStripMenuItem.Enabled = False
        PerfilesToolStripMenuItem.Enabled = False
        UsuariosToolStripMenuItem.Enabled = False
        UsuariosToolStripMenuItem1.Enabled = False
        CambioDeConstraseñaToolStripMenuItem.Enabled = False
        RegistrosToolStripMenuItem.Enabled = False
        MensajesDelSistemaToolStripMenuItem.Enabled = False
        staBarraEstado.ContextMenuStrip.Enabled = False
        ModificacionesToolStripMenuItem.Enabled = False
        CatálogosToolStripMenuItem.Enabled = False
        TrigosToolStripMenuItem.Enabled = False
        ProveedoresToolStripMenuItem.Enabled = False
        OrígenesToolStripMenuItem.Enabled = False
        DestinosToolStripMenuItem.Enabled = False
        OperadoresToolStripMenuItem.Enabled = False
        TransaccionesToolStripMenuItem.Enabled = False
        LotesToolStripMenuItem1.Enabled = False
        ÓrdenesToolStripMenuItem1.Enabled = False
        OrdenesToolStripMenuItem2.Enabled = False
        AcuerdoDeCompraDeTrigoToolStripMenuItem.Enabled = False
        EmbarquesToolStripMenuItem1.Enabled = False
        EmbarquesToolStripMenuItem2.Enabled = False
        FacturaFletesToolStripMenuItem.Enabled = False
        CargaMasivaToolStripMenuItem.Enabled = False
        AjustesToolStripMenuItem1.Enabled = False
        AjustesToolStripMenuItem2.Enabled = False
        VentasToolStripMenuItem2.Enabled = False
        ReportesToolStripMenuItem.Enabled = False
        ReportesSToolStripMenuItem.Enabled = False
        ConfiguraciónToolStripMenuItem.Enabled = False
        AyudaEnLíneaToolStripMenuItem.Enabled = False
        AcercaDeToolStripMenuItem.Enabled = False

        tspDocumentos.Enabled = False
        tsbLotes.Enabled = False
        tsbOrdenes.Enabled = False
        tsbEmbarques.Enabled = False
        tsbAjustes.Enabled = False
        tsbVentas.Enabled = False

        Me.Text = "Logística de Trigos"
    End Sub

    Public Sub habilitarFunciones()
        Try
            msg.reset()

            activarObjeto(HerramientasToolStripMenuItem, 1)
            activarObjeto(OpcionesToolStripMenuItem, 2)
            activarObjeto(AdministraciónToolStripMenuItem, 3)
            activarObjeto(PerfilesToolStripMenuItem, 4)
            activarObjeto(UsuariosToolStripMenuItem, 5)
            activarObjeto(UsuariosToolStripMenuItem1, 6)
            activarObjeto(CambioDeConstraseñaToolStripMenuItem, 7)
            activarObjeto(RegistrosToolStripMenuItem, 8)
            activarObjeto(MensajesDelSistemaToolStripMenuItem, 9)
            activarObjeto(staBarraEstado.ContextMenuStrip, 9)
            activarObjeto(ModificacionesToolStripMenuItem, 10)
            activarObjeto(CatálogosToolStripMenuItem, 15)
            activarObjeto(TrigosToolStripMenuItem, 16)
            activarObjeto(ProveedoresToolStripMenuItem, 46)
            activarObjeto(OrígenesToolStripMenuItem, 17)
            activarObjeto(DestinosToolStripMenuItem, 18)
            activarObjeto(OperadoresToolStripMenuItem, 20)
            activarObjeto(TransaccionesToolStripMenuItem, 21)
            activarObjeto(LotesToolStripMenuItem1, 47)
            activarObjeto(ÓrdenesToolStripMenuItem1, 22)
            activarObjeto(OrdenesToolStripMenuItem2, 23)
            activarObjeto(AcuerdoDeCompraDeTrigoToolStripMenuItem, 24)
            activarObjeto(EmbarquesToolStripMenuItem1, 25)
            activarObjeto(EmbarquesToolStripMenuItem2, 26)
            activarObjeto(FacturaFletesToolStripMenuItem, 27)
            activarObjeto(CargaMasivaToolStripMenuItem, 28)
            activarObjeto(AjustesToolStripMenuItem1, 29)
            activarObjeto(AjustesToolStripMenuItem2, 30)
            activarObjeto(VentasToolStripMenuItem2, 31)
            activarObjeto(ReportesToolStripMenuItem, 32)
            activarObjeto(ReportesSToolStripMenuItem, 32)
            ConfiguraciónToolStripMenuItem.Enabled = False
            AyudaEnLíneaToolStripMenuItem.Enabled = False
            AcercaDeToolStripMenuItem.Enabled = True

            activarObjeto(tspDocumentos, 21)
            activarObjeto(tsbLotes, 47)
            activarObjeto(tsbOrdenes, 23)
            activarObjeto(tsbEmbarques, 26)
            activarObjeto(tsbAjustes, 30)
            activarObjeto(tsbVentas, 31)

        Catch ex As Exception
            msg.setError("No fue posible configurar las funciones de acceso: " + ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub activarObjeto(ByVal pObjeto As Object, pOpcnid As String)
        Try
            Dim atm As ObjEntidades.AtomoPerfil = Usuario.Perfil.Detalle.obtenerAtomo(pOpcnid)

            pObjeto.Enabled = atm.Activo
            pObjeto.Tag = atm
        Catch ex As Exception
            msg.setError(ex.Message)
        End Try

        genW.publicar(infDoc, msg, True)
    End Sub

    Private Sub bloquearPantalla()
        Dim visorSistVisible As Boolean = False
        Dim frmbloqueador As frmBloqueadorPantalla = New frmBloqueadorPantalla(cliente, genW, Cnfg, Usuario)

        For Each ChildForm As Form In Me.MdiChildren
            If ChildForm.Name = "frmVisorEventos" Then visorSistVisible = ChildForm.Visible
            ChildForm.Visible = False
        Next

        frmbloqueador.ShowDialog()

        For Each ChildForm As Form In Me.MdiChildren
            If (ChildForm.Name.Equals("frmVisorEventos") And visorSistVisible) Or Not ChildForm.Name.Equals("frmVisorEventos") Then _
                ChildForm.Visible = True

        Next
    End Sub

    Private Sub CambioDeConstraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioDeConstraseñaToolStripMenuItem.Click
        Dim frmcambioContrasenia As frmCambioContrasenia = New frmCambioContrasenia(cliente, genW, Cnfg, Usuario)
        frmcambioContrasenia.MdiParent = Me
        frmcambioContrasenia.Show()
    End Sub

    Private Sub BloquearPantallaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BloquearPantallaToolStripMenuItem.Click
        bloquearPantalla()
    End Sub

    Private Sub ModificacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificacionesToolStripMenuItem.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteBuscarHistorial Then
                frm.buscarHistorial()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para buscar historial del documento.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub AcuerdoDeCompraDeTrigoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcuerdoDeCompraDeTrigoToolStripMenuItem.Click
        Dim frm As Object = Nothing

        frm = Me.ActiveMdiChild

        If Not frm Is Nothing Then
            If frm.PermiteImprimir Then
                frm.imprimir()
                Exit Sub
            End If
        End If

        msg.setAdvertencia("No hay una entidad activa para impresión de documentos.")
        genW.publicar(infDoc, msg)
    End Sub

    Private Sub CascadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadaToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub MosaicoVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MosaicoVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub MosaicoHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MosaicoHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub OrganizarÍconosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrganizarÍconosToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub


    Private Sub CerrarTodasLasVentanasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarTodasLasVentanasToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub CambioDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambioDeUsuarioToolStripMenuItem.Click
        cambiarUsuario()
    End Sub

    Private Function cambiarUsuario() As Mensaje
        Try
            msg.reset()

            msg.setPregunta("Todos los cambios sobre documentos abiertos no se guardarán. ¿Seguro que desea continuar cerrando la sesión?")
            genW.publicar(infDoc, msg)

            If genW.mensajePantalla(msg, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                msg.setInfo(msg.Descripcion + ": Sí")
                genW.publicar(infDoc, msg)

                Usuario.CerrarSesion()

                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next

                msg.setInfo("Sesión del usuario" + Usuario.Nombre + " " + Usuario.Apllidop + " " + Usuario.Apllidom + " cerrada con éxito.")
                genW.publicar(infDoc, msg)

                inhabilitarFunciones()

                Dim frmIsesion As frmSesion = New frmSesion(cliente, genW, Cnfg)
                frmIsesion.ShowDialog()
                If Not frmIsesion.SesionIniciada Then End

                Usuario = frmIsesion.Usuario
                Me.Text = "Logística de Trigos - En la sesión de " + Usuario.Nombre + " " + Usuario.Apllidop + " " + Usuario.Apllidom
                habilitarFunciones()
            End If
        Catch ex As Exception
            msg.setError("No fue posible cerrar la sesión: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

        End
    End Sub


    Private Sub tstEstado_MouseUp(sender As Object, e As MouseEventArgs) Handles tstEstado.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            staBarraEstado.ContextMenuStrip.Show(staBarraEstado, e.Location)
        End If
    End Sub

    Private Sub mnuMostrarEvSistema_Click(sender As Object, e As EventArgs) Handles mnuMostrarEvSistema.Click
        frmVisor.Visible = Not frmVisor.Visible
    End Sub

    Private Sub frmPrincipal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub



    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        Dim frmAcerca As frmAcercade = New frmAcercade
        frmAcerca.MdiParent = Me
        frmAcerca.Show()
    End Sub

    Private Sub CatálogosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CatálogosToolStripMenuItem.Click

    End Sub

End Class
