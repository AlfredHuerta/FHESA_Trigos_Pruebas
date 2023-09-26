Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO


Imports Genericas.SysEnums

Public Class GenericasWin
    Private msg As Mensaje

    Private publica As PropiedadesPublicacion

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Sub New()
        msg = New Mensaje
    End Sub

    Public Sub New(ByVal pPropiedadesPublicacion As PropiedadesPublicacion)
        msg = New Mensaje
        publica = pPropiedadesPublicacion
    End Sub


    Public Function agregarPestaniaBaseDatos(ByVal pControlTab As TabControl, ByVal pNombreBase As String, ByVal pComentarios As String) As Mensaje
        Dim pNombrePestania As String = pNombreBase.Replace(" ", "")
        Try
            msg.reset()

            With pControlTab
                .TabPages.Add("tbp" + pNombrePestania, pNombreBase)
                .SelectTab(.TabCount - 1)
                .SelectedTab.ToolTipText = pComentarios

                .ShowToolTips = True

                If agregarDvgVisor(.SelectedTab, pNombrePestania).EsError Then GoTo finalize

            End With

            msg.setInfo("Pestaña " + pNombrePestania + " añadida correctamente.")
        Catch ex As Exception
            msg.setError("No fue posible añadir la nueva pestaña: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function agregarDvgVisor(ByVal pTabPage As TabPage, ByVal pNombrePestania As String) As Mensaje
        Dim dgvVisor As DataGridView

        Try
            dgvVisor = New DataGridView()

            dgvVisor.Name = "dgvVisor_" + pNombrePestania
            dgvVisor.Top = 10
            dgvVisor.Left = 10
            dgvVisor.Width = 1100
            dgvVisor.Height = 90
            dgvVisor.Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right

            dgvVisor.AllowUserToAddRows = True
            dgvVisor.AllowUserToResizeRows = False
            dgvVisor.AllowUserToOrderColumns = True
            dgvVisor.AllowUserToResizeColumns = True
            dgvVisor.ScrollBars = ScrollBars.Both
            dgvVisor.EditMode = DataGridViewEditMode.EditProgrammatically

            dgvConfigInicial(dgvVisor)

            pTabPage.Controls.Add(dgvVisor)
        Catch ex As Exception
            msg.setError("No fue posible añadir el nuevo objeto " + pNombrePestania + ": " + ex.Message)
        End Try

        Return msg
    End Function

    Private Sub dgvConfigInicial(ByVal pdvg As DataGridView)
        Dim colimg As DataGridViewImageColumn = Nothing
        Dim coltxt As DataGridViewTextBoxColumn = Nothing

        Try
            pdvg.Columns.Clear()
            pdvg.Rows.Clear()

            colimg = New DataGridViewImageColumn
            colimg.DataPropertyName = "colTipo"
            colimg.Name = "colTipo"
            colimg.HeaderText = "Tipo"
            colimg.Image = My.Resources.desconocido
            colimg.SortMode = DataGridViewColumnSortMode.NotSortable
            colimg.ValueType = GetType(Image)
            colimg.Width = 40
            pdvg.Columns.Add(colimg)

            coltxt = New DataGridViewTextBoxColumn
            coltxt.Name = "colDocNum"
            coltxt.HeaderText = "No. Documento"
            coltxt.ValueType = GetType(String)
            coltxt.Width = 150

            pdvg.Columns.Add(coltxt)

            coltxt = New DataGridViewTextBoxColumn
            coltxt.Name = "colMsg"
            coltxt.HeaderText = "Mensaje"
            coltxt.ValueType = GetType(String)
            coltxt.Width = 950

            pdvg.Columns.Add(coltxt)

            coltxt = New DataGridViewTextBoxColumn
            coltxt.Name = "colHora"
            coltxt.HeaderText = "Hora"
            coltxt.ValueType = GetType(String)
            coltxt.Width = 100
            coltxt.Resizable = DataGridViewTriState.False

            pdvg.Columns.Add(coltxt)
        Catch ex As Exception
            msg.setError("No fue posible configurar el nuevo objeto: " + ex.Message)
        End Try

        If msg.EsError Then Throw New Exception(msg.Descripcion)
    End Sub

    Public Function mensajePantalla(ByVal pMensaje As Mensaje, Optional ByVal pTipoAdicional As MsgBoxStyle = -1, _
                                    Optional ByVal pSoloSiError As Boolean = False) As MsgBoxResult
        Dim tipoMsg As MsgBoxStyle = Nothing
        Dim resultado As MsgBoxResult = MsgBoxResult.Abort
        Try
            msg.reset()

            If Not pMensaje.EsError And pSoloSiError Then GoTo finalize

            Select Case pMensaje.Tipo
                Case TiposMensaje.mInformacion
                    tipoMsg = MsgBoxStyle.Information
                Case TiposMensaje.mPregunta
                    tipoMsg = MsgBoxStyle.Question
                Case TiposMensaje.mAdvertencia
                    tipoMsg = MsgBoxStyle.Exclamation
                Case TiposMensaje.mError
                    tipoMsg = MsgBoxStyle.Critical
                Case Else
                    tipoMsg = MsgBoxStyle.SystemModal
            End Select

            If pTipoAdicional <> -1 Then tipoMsg += pTipoAdicional

            resultado = MsgBox(pMensaje.Descripcion, tipoMsg)

            msg.setInfo("Mensaje desplegado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible publicar el mensaje en pantalla: " + ex.Message)
        End Try

finalize:
        Return resultado
    End Function

    Public Function continuarSinGuardar(ByVal pInfDoc As InformacionDocumento, _
                                         ByVal pModificado As Boolean) As Boolean
        Dim continuar As Boolean = True
        Dim msgCont As Mensaje = New Mensaje

        If pModificado Then
            msgCont.setPregunta("Hay cambios sin guardar en el documento actual (" + pInfDoc.NumDocumento + "). ¿Desea continuar sin guardar cambios?")

            publicar(pInfDoc, msgCont)
            If mensajePantalla(msgCont, MsgBoxStyle.YesNo) = MsgBoxResult.No Then continuar = False

            msgCont.setInfo("Hay cambios sin guardar en el documento actual (" + pInfDoc.NumDocumento + "). ¿Desea continuar sin guardar cambios?: " + continuar.ToString)

            publicar(pInfDoc, msgCont)
        End If

        Return continuar
    End Function

    Public Function initControles(ByRef pForma As Form) As Mensaje
        Try
            msg.reset()

            For Each Control As Control In pForma.Controls
                Select Case Control.GetType()
                    Case GetType(TabControl)
                        For Each tabp As TabPage In TryCast(Control, TabControl).TabPages
                            For Each tbpcont As Control In tabp.Controls
                                Select Case tbpcont.GetType()
                                    Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                                        Control.Enabled = False
                                End Select
                            Next
                        Next
                    Case Else
                        Control.Enabled = False
                End Select
            Next
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles de la forma: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function initControlesCrear(ByRef pForma As Form) As Mensaje
        Try
            msg.reset()

            For Each ctrl As Control In pForma.Controls
                ctrl.Enabled = True

                Select Case ctrl.GetType()
                    Case GetType(TextBox)
                        ctrl.Text = ""
                    Case GetType(GroupBox)
                        For Each gpbcont As Control In ctrl.Controls
                            gpbcont.Enabled = True

                            Select Case gpbcont.GetType()
                                Case GetType(TextBox)
                                    gpbcont.Text = ""
                            End Select
                        Next
                    Case GetType(TabControl)
                        For Each tabp As TabPage In TryCast(ctrl, TabControl).TabPages
                            For Each tbpcont As Control In tabp.Controls
                                tbpcont.Enabled = True

                                Select Case tbpcont.GetType()
                                    Case GetType(TextBox)
                                        tbpcont.Text = ""
                                    Case GetType(CheckBox)
                                        TryCast(tbpcont, CheckBox).Checked = False
                                    Case GetType(DataGridView)
                                        TryCast(tbpcont, DataGridView).Rows.Clear()
                                        TryCast(tbpcont, DataGridView).Rows.Add()
                                        TryCast(tbpcont, DataGridView).Enabled = True
                                End Select
                            Next
                        Next
                End Select
            Next
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles para creación: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function initControlesConsultar(ByRef pForma As Form) As Mensaje
        Try
            msg.reset()

            For Each ctrl As Control In pForma.Controls
                ctrl.Enabled = True
                Select Case ctrl.GetType()
                    Case GetType(GroupBox)
                        For Each Control As Control In ctrl.Controls
                            Control.Enabled = True
                        Next
                    Case GetType(TabControl)
                        For Each tabp As TabPage In TryCast(ctrl, TabControl).TabPages
                            For Each tbpcont As Control In tabp.Controls
                                Select Case tbpcont.GetType()
                                    Case GetType(TextBox), GetType(CheckBox), GetType(ComboBox)
                                        tbpcont.Enabled = True
                                    Case GetType(DataGridView)
                                        TryCast(tbpcont, DataGridView).Enabled = True
                                End Select

                            Next
                        Next
                End Select
            Next
        Catch ex As Exception
            msg.setError("No fue posible iniciarlizar los controles para consulta: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function initControlesBuscar(ByRef pForma As Form) As Mensaje
        Try
            msg.reset()

            For Each Control As Control In pForma.Controls
                Select Case Control.GetType()
                    Case GetType(GroupBox)
                        For Each ctrl As Control In Control.Controls
                            Select Case ctrl.GetType()
                                Case GetType(Label)
                                Case GetType(TextBox)
                                    ctrl.Text = ""
                                    ctrl.Enabled = False
                                Case Else
                                    ctrl.Enabled = False
                            End Select
                        Next
                    Case GetType(TextBox)
                        Control.Text = ""
                        Control.Enabled = False
                    Case GetType(TabControl)
                        For Each tabp As TabPage In TryCast(Control, TabControl).TabPages
                            For Each tbpcont As Control In tabp.Controls
                                Select Case tbpcont.GetType()
                                    Case GetType(TextBox)
                                        tbpcont.Text = ""
                                        tbpcont.Enabled = False
                                    Case GetType(CheckBox)
                                        tbpcont.Enabled = False
                                    Case GetType(ComboBox)
                                        tbpcont.Enabled = False
                                    Case GetType(DataGridView)
                                        TryCast(tbpcont, DataGridView).Rows.Clear()
                                        TryCast(tbpcont, DataGridView).Rows.Add()
                                        TryCast(tbpcont, DataGridView).Enabled = False
                                End Select
                            Next
                        Next
                    Case GetType(Button), GetType(Label)
                        Continue For
                    Case Else
                        Control.Enabled = False
                End Select
            Next
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles para modificación: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function initControlesHistorial(ByRef pForma As Form) As Mensaje
        Try
            msg.reset()

            For Each Control As Control In pForma.Controls
                Select Case Control.GetType()
                    Case GetType(GroupBox)
                        Control.Enabled = True

                        For Each ctrl As Control In Control.Controls
                            Select Case ctrl.GetType()
                                Case GetType(Label)
                                    ctrl.Enabled = True
                                Case GetType(TextBox)
                                    ctrl.Enabled = False
                                Case Else
                                    ctrl.Enabled = False
                            End Select
                        Next
                    Case GetType(TextBox)
                        Control.Enabled = False
                    Case GetType(TabControl)
                        Control.Enabled = True

                        For Each tabp As TabPage In TryCast(Control, TabControl).TabPages
                            For Each tbpcont As Control In tabp.Controls
                                Select Case tbpcont.GetType()
                                    Case GetType(TextBox)
                                        tbpcont.Enabled = False
                                    Case GetType(CheckBox)
                                        tbpcont.Enabled = False
                                    Case GetType(Label)
                                        tbpcont.Enabled = True
                                    Case GetType(DataGridView)
                                        TryCast(tbpcont, DataGridView).Rows.Clear()
                                        TryCast(tbpcont, DataGridView).Rows.Add()
                                        TryCast(tbpcont, DataGridView).Enabled = False
                                    Case GetType(DateTimePicker)
                                        tbpcont.Enabled = False
                                    Case GetType(CheckedListBox)
                                        tbpcont.Enabled = False
                                    Case GetType(ComboBox)
                                        tbpcont.Enabled = False
                                End Select
                            Next
                        Next
                    Case GetType(Label)
                        Control.Enabled = True
                    Case Else
                        Control.Enabled = False
                End Select
            Next
        Catch ex As Exception
            msg.setError("No fue posible inicializar los controles para presentación de Historial: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function publicar(ByVal pInfoDoc As InformacionDocumento, ByVal pMensaje As Mensaje, _
                             Optional ByVal pSoloSiError As Boolean = False) As Mensaje
        Dim icono As Bitmap = Nothing
        Dim dgvPublica As DataGridView = Nothing

        Dim nombreBase As String = pInfoDoc.BaseDeDatos.Replace(" ", "")

        Try
            If pSoloSiError And Not pMensaje.EsError Then GoTo finalize

            Select Case pMensaje.Tipo
                Case TiposMensaje.mExclamacion
                    icono = My.Resources.infoimportante
                    publica.Estado.ForeColor = Color.Green
                Case TiposMensaje.mInformacion
                    icono = My.Resources.info
                    publica.Estado.ForeColor = Color.DarkBlue
                Case TiposMensaje.mPregunta
                    icono = My.Resources.pregunta
                    publica.Estado.ForeColor = Color.Gold
                Case TiposMensaje.mAdvertencia
                    icono = My.Resources.advert
                    publica.Estado.ForeColor = Color.OrangeRed
                Case TiposMensaje.mError
                    icono = My.Resources._error
                    publica.Estado.ForeColor = Color.Red
                Case Else
                    icono = My.Resources.desconocido
            End Select

            dgvPublica = publica.VisorBases.TabPages("tbp" + nombreBase).Controls("dgvVisor_" + nombreBase)

            publica.Estado.Text = Now.ToLongTimeString + ": " + pMensaje.Descripcion

            With dgvPublica
                If .RowCount > 50 Then .Rows.RemoveAt(1)
                .Rows.Add()

                .Rows(.RowCount - 1).Cells(0).Value = My.Resources.desconocido
                .Rows(.RowCount - 2).Cells(0).Value = icono
                .Rows(.RowCount - 2).Cells(1).Value = pInfoDoc.Tipo.ToString + " - " + pInfoDoc.NumDocumento
                .Rows(.RowCount - 2).Cells(2).Value = pMensaje.Descripcion
                .Rows(.RowCount - 2).Cells(3).Value = Now.ToLongTimeString

                .Refresh()

                .FirstDisplayedScrollingRowIndex = .RowCount - 1
            End With

            If publica.GuardarRegistro.Checked Then registrarArchivo(nombreBase, pMensaje.Descripcion)
        Catch ex As Exception
            msg.setError("No fue posible publicar el mensaje: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function registrarArchivo(ByVal pBaseDatos As String, _
                                     ByVal strText As String, Optional ByVal bAppend As Boolean = True) As Mensaje
        Dim Sw1 As StreamWriter
        Dim Sr1 As StreamReader
        Dim ruta As String = My.Application.Info.DirectoryPath + "\LogEventos\"

        Try
            msg.reset()

            If Not Directory.Exists(ruta) Then Directory.CreateDirectory(ruta)
            ruta += "\" + Now.Date.ToString("yyyyMMdd") + ".txt"

            Sw1 = New StreamWriter(ruta, bAppend)

            Sw1.WriteLine(Now.ToLongTimeString + ": " + strText)

            Sw1.Flush()
            Sw1.Close()
            'Solo no aplica para el documento que lleve a cabo el 
            'registro de errores
            If bAppend = False Then _
                Sr1 = New StreamReader(File.Open(ruta, FileMode.OpenOrCreate, _
                    FileAccess.ReadWrite))

        Catch ex As Exception
            msg.setError("No fue posible aplicar registro en archivo Log: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function llenarListaDesdeEnum(ByVal pTipo As Type, ByRef pLista As ComboBox) As Mensaje
        Dim nombres() As String = Nothing
        Dim valores As Array = Nothing

        Dim itmCounter As Integer = 0
        Try
            msg.reset()

            nombres = System.Enum.GetNames(pTipo)
            valores = System.Enum.GetValues(pTipo)


            pLista.Items.Clear()
            For itmCounter = 0 To nombres.GetUpperBound(0)
                If pTipo.AssemblyQualifiedName.Contains("SysEnums+ComplementosCFDi") Then
                    pLista.Items.Add(New SubItem(nombres(itmCounter).Substring(1, nombres(itmCounter).Length - 1).Replace("_", " "), _
                                                 CInt(valores(itmCounter))))
                Else
                    pLista.Items.Add(New SubItem(nombres(itmCounter), CInt(valores(itmCounter))))
                End If

            Next
        Catch ex As Exception
            msg.setError("No fue posible recuperar el listado de referencias de comprobantes: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function llenarListadoDesdeTabla(ByVal pTabla As DataTable, ByVal pColDescripcion As String, ByVal pColItemData As String, _
                                            ByRef pLista As ComboBox) As Mensaje
        Dim gen3E As Genericas3E = Nothing
        Dim lColumnasDesc As String() = Nothing

        Dim desc As String = ""
        Try
            msg.reset()

            pLista.Items.Clear()
            gen3E = New Genericas3E

            lColumnasDesc = pColDescripcion.Split("|")

            For itmCounter = 0 To pTabla.Rows.Count - 1
                For Each colDescripcion As String In lColumnasDesc
                    desc += gen3E.valorCampo(pTabla, itmCounter, colDescripcion) + "-"
                Next

                If desc.Trim.Length > 1 Then desc = desc.Substring(0, desc.Trim.Length - 1)

                pLista.Items.Add(New SubItem(desc, gen3E.valorCampo(pTabla, itmCounter, pColItemData)))
                desc = ""
            Next
        Catch ex As Exception
            msg.setError("No fue posible llenar el listado desde Tabla: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function llenarListadoDesdeTabla(ByVal pTabla As DataTable, ByVal pColDescripcion As String, ByVal pColItemData As String, _
                                        ByRef pLista As CheckedListBox) As Mensaje
        Dim gen3E As Genericas3E = Nothing
        Dim lColumnasDesc As String() = Nothing

        Dim desc As String = ""
        Try
            msg.reset()

            pLista.Items.Clear()
            gen3E = New Genericas3E

            lColumnasDesc = pColDescripcion.Split("|")

            For itmCounter = 0 To pTabla.Rows.Count - 1
                For Each colDescripcion As String In lColumnasDesc
                    desc += gen3E.valorCampo(pTabla, itmCounter, colDescripcion) + "-"
                Next

                If desc.Trim.Length > 1 Then desc = desc.Substring(0, desc.Trim.Length - 1)

                pLista.Items.Add(New SubItem(desc, gen3E.valorCampo(pTabla, itmCounter, pColItemData)))

                desc = ""
            Next
        Catch ex As Exception
            msg.setError("No fue posible llenar el listado desde Tabla: " + ex.Message)
        End Try

        Return msg
    End Function


    Public Function seleccionarItem(ByRef pLista As ComboBox, ByVal pValor As String) As Mensaje
        Dim itmCounter As Integer = 0

        Try
            For itmCounter = 0 To pLista.Items.Count - 1
                If pLista.Items(itmCounter).ItemData = pValor Then
                    pLista.SelectedIndex = itmCounter
                    msg.setInfo("Item seleccionado con éxito")

                    GoTo finalize
                End If
            Next

        Catch ex As Exception
            msg.setError("No fue posible seleccionar el Item del listado: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function



    Public Function obtenerArchivo(ByVal pFiltro As String) As String
        Dim abrir As OpenFileDialog = New OpenFileDialog
        Dim arch As String = ""
        Try

            If pFiltro.Trim.Length.Equals(0) Then pFiltro = "Todos los Archivos (*.*)|*.*"
            With abrir
                .Title = "Ubicación de Archivo"
                .Filter = pFiltro
                .Multiselect = False

                If .ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
                    arch = .FileName
                    msg.setInfo("Archivo " + arch + " seleccionado con éxito.")
                Else
                    msg.setInfo("No se ha seleccionado ningún archivo.")
                End If
            End With
        Catch ex As Exception
            msg.setError("No fue posible abrir el CFDi: " + ex.Message)
        End Try

        Return arch
    End Function

    Public Function obtenerCarpeta() As String
        Dim seleccionaDir As FolderBrowserDialog = New FolderBrowserDialog
        Dim dir As String = ""

        Try

            If seleccionaDir.ShowDialog() = Windows.Forms.DialogResult.OK And _
                seleccionaDir.SelectedPath.Trim.Length > 0 Then
                dir = seleccionaDir.SelectedPath + "\"
                msg.setInfo("Carpeta " + dir + " seleccionada con éxito.")
            Else
                dir = ""
                msg.setInfo("No se ha seleccionado ninguna carpeta.")
            End If


        Catch ex As Exception
            msg.setError("No fue posible abrir la ruta de CFDis: " + ex.Message)
        End Try

        Return dir
    End Function
End Class
