Imports System.Windows.Forms

Imports Genericas
Imports IfcDatos

Partial Public Class Perfil
    Private msg As Mensaje


    Private sPerfilId As String
    Private sNombre As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String

    Private iPerfe As iPerfilEncabezado
    Private pdet As PerfilDetalle

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property PerfilId() As String
        Get
            Return sPerfilId
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return sNombre
        End Get
    End Property
    Public ReadOnly Property Activo() As Boolean
        Get
            Return bActivo
        End Get
    End Property
    Public ReadOnly Property Fchcrea() As String
        Get
            Return sFchcrea
        End Get
    End Property
    Public ReadOnly Property Usrcrea() As String
        Get
            Return sUsrcrea
        End Get
    End Property
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property

    Public ReadOnly Property Detalle() As PerfilDetalle
        Get
            Return pdet
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pPerfilid As String, ByVal pNombre As String, ByVal pActivo As Integer, _
                   ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String)
        msg = New Mensaje

        iPerfe = New iPerfilEncabezado(pCliente)

        sPerfilId = pPerfilid
        sNombre = pNombre
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod

        pdet = New PerfilDetalle(pCliente)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pPerfilid As String)
        msg = New Mensaje
        iPerfe = New iPerfilEncabezado(pCliente)

        buscarPerfil(pPerfilid)

        pdet = New PerfilDetalle(pCliente, pPerfilid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iPerfe = New iPerfilEncabezado(pCliente)

        pdet = New PerfilDetalle(pCliente)

        reiniciar()
    End Sub

    Private Function buscarPerfil(ByVal pPerfilid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iPerfe.leer(pPerfilid)
            msg = iPerfe.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sPerfilId = gen3E.valorCampo(resultados, 0, "PerfilId")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")

            msg.setInfo("Perfil " + pPerfilid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Perfil desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sPerfilId = iPerfe.siguienteNo().ToString
            msg = iPerfe.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iPerfe.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iPerfe.escribir(sPerfilId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod).clonar()
            If msg.EsError Then GoTo esError

            msg = pdet.guardar(sPerfilId).clonar()

esError:
            If msg.EsError Then
                iPerfe.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iPerfe.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Perfil " + sPerfilId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function perfilAnterior(ByVal pPerfilId As String) As String
        Dim perf As String = iPerfe.perfilAnterior(pPerfilId)
        If iPerfe.Mensaje.EsError Then Throw New Exception(iPerfe.Mensaje.Descripcion)

        Return perf
    End Function

    Public Function perfilSiguiente(ByVal PerfilId As String) As String
        Dim perf As String = iPerfe.perfilSiguiente(PerfilId)
        If iPerfe.Mensaje.EsError Then Throw New Exception(iPerfe.Mensaje.Descripcion)

        Return perf
    End Function


    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iPerfe.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iPerfe.actualizar(sPerfilId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod).clonar()

            If msg.EsError Then GoTo esError


            msg = pdet.guardar(sPerfilId).clonar()
            If msg.EsError Then GoTo esError


esError:
            If msg.EsError Then
                iPerfe.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iPerfe.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Perfil " + sPerfilId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sPerfilId = iPerfe.siguienteNo()

        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""

        pdet.reiniciar(sPerfilId)
    End Sub

    Public Sub liberarObjetos()
        sPerfilId = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""

        iPerfe = Nothing

        pdet.liberarObjetos()
        pdet = Nothing

    End Sub
End Class

Partial Public Class PerfilDetalle
    Private msg As Mensaje
    Private iPerfd As iPerfilDetalle

    Private sPerfilId As String
    Private atms As AtomoPerfil

    Public ReadOnly Property Atomos() As AtomoPerfil
        Get
            Return atms
        End Get
    End Property


    Public Sub New(ByVal pCliente As ClienteSql, ByVal pPerfilid As String)
        msg = New Mensaje
        iPerfd = New iPerfilDetalle(pCliente)

        sPerfilId = pPerfilid

        buscarDetalles(pPerfilid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iPerfd = New iPerfilDetalle(pCliente)

        reiniciar("")
    End Sub

    Public Sub setAtomosPerfil(ByVal pAtomosPerfil As AtomoPerfil)
        atms = pAtomosPerfil
    End Sub

    Private Function buscarDetalles(ByVal pPerfilid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Dim sNmbMost As String
        Dim sOpcionId As String
        Dim sOpcnidp As String
        Dim sPrmsosap As String
        Dim bActivo As Boolean
        Dim bConsulta As Boolean
        Dim bMdfccion As Boolean
        Dim bCreacion As Boolean
        Dim bCnlacion As Boolean
        Dim bCierre As Boolean

        Dim atm As AtomoPerfil = Nothing

        Try
            resultados = iPerfd.leer(pPerfilid)
            msg = iPerfd.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E


            sNmbMost = gen3E.valorCampo(resultados, 0, "NmbMost")
            sOpcionId = gen3E.valorCampo(resultados, 0, "OpcionId")
            sOpcnidp = gen3E.valorCampo(resultados, 0, "Opcnidp")
            sPrmsosap = gen3E.valorCampo(resultados, 0, "Prmsosap")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            bConsulta = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Consulta", "false"))
            bMdfccion = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Mdfccion", "false"))
            bCreacion = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Creacion", "false"))
            bCnlacion = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Cnlacion", "false"))
            bCierre = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Cierre", "false"))

            atms = New AtomoPerfil(sNmbMost, sOpcionId, sOpcnidp, sPrmsosap, bActivo, bConsulta, _
                             bMdfccion, bCreacion, bCnlacion, bCierre)

            For itmCounter = 1 To resultados.Rows.Count - 1
                sNmbMost = gen3E.valorCampo(resultados, itmCounter, "NmbMost")
                sOpcionId = gen3E.valorCampo(resultados, itmCounter, "OpcionId")
                sOpcnidp = gen3E.valorCampo(resultados, itmCounter, "Opcnidp")
                sPrmsosap = gen3E.valorCampo(resultados, itmCounter, "Prmsosap")
                bActivo = Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Activo", "false"))
                bConsulta = Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Consulta", "false"))
                bMdfccion = Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Mdfccion", "false"))
                bCreacion = Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Creacion", "false"))
                bCnlacion = Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Cnlacion", "false"))
                bCierre = Boolean.Parse(gen3E.valorCampo(resultados, itmCounter, "Cierre", "false"))

                atm = obtenerNodop(atms, sOpcnidp)

                If Not atm Is Nothing Then
                    atm.aniadir(New AtomoPerfil(sNmbMost, sOpcionId, sOpcnidp, sPrmsosap, bActivo, bConsulta, _
                             bMdfccion, bCreacion, bCnlacion, bCierre))
                End If

            Next


            msg.setInfo("Detalle del Perfil " + pPerfilid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Detalle del Perfil desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Private Function obtenerNodop(ByVal pAtomoPadre As AtomoPerfil, ByVal pOpcnidp As Integer) As AtomoPerfil
        Dim atomo As AtomoPerfil = Nothing
        Dim itmCounter As Integer = 0

        If pAtomoPadre.OpcionId.Equals(pOpcnidp.ToString) Then
            atomo = pAtomoPadre
        ElseIf Not pAtomoPadre.Atomos Is Nothing Then
            For itmCounter = 0 To pAtomoPadre.Atomos.Count - 1
                atomo = obtenerNodop(pAtomoPadre.Atomos.Item(itmCounter), pOpcnidp)

                If Not atomo Is Nothing Then Exit For
            Next
        End If

        Return atomo
    End Function


    Public Function alimentarArbol(ByRef pArbol As TreeView) As Mensaje
        Dim trNode As TreeNode = Nothing

        Try
            msg.reset()

            pArbol.Nodes.Clear()

            agregarNodo(atms, trNode)

            pArbol.Nodes.Add(trNode)
            pArbol.ExpandAll()
            pArbol.Nodes(0).EnsureVisible()
        Catch ex As Exception
            msg.setError("No fue posible cargar el árbol de permisos: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Sub agregarNodo(ByVal pAtomoPadre As AtomoPerfil, ByRef pNodo As TreeNode)
        Dim atomo As AtomoPerfil = Nothing
        Dim nuevoNodo As TreeNode = Nothing
        Dim itmCounter As Integer = 0

        If pNodo Is Nothing Then
            pNodo = New TreeNode(pAtomoPadre.NmbMost)
            pNodo.Name = pNodo.Name + "_" + pAtomoPadre.OpcionId + "_" + pAtomoPadre.Opcnidp
            pNodo.ToolTipText = pAtomoPadre.NmbMost
            pNodo.Tag = pAtomoPadre

            nuevoNodo = pNodo
        Else
            nuevoNodo = pNodo.Nodes.Add(pAtomoPadre.NmbMost)
            nuevoNodo.Name = pNodo.Name + "_" + pAtomoPadre.OpcionId + "_" + pAtomoPadre.Opcnidp
            nuevoNodo.ToolTipText = pAtomoPadre.NmbMost
            nuevoNodo.Tag = pAtomoPadre
        End If

        If Not pAtomoPadre.Atomos Is Nothing Then
            For itmCounter = 0 To pAtomoPadre.Atomos.Count - 1
                agregarNodo(pAtomoPadre.Atomos.Item(itmCounter), nuevoNodo)
            Next
        End If

    End Sub


    Public Function guardar(ByVal pPerfilId As String) As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sPerfilId = pPerfilId

            actualizarAtomo(atms)
            procesarAtomo(atms)

            If Not msg.EsError Then msg.setExclamacion("Perfil detalle guardado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Private Function procesarAtomo(ByVal pAtomo As AtomoPerfil) As AtomoPerfil
        For Each Atomo As AtomoPerfil In pAtomo.Atomos
            If msg.EsError Then Exit For
            If actualizarAtomo(Atomo).EsError Then Exit For

            procesarAtomo(Atomo)
        Next

        Return Nothing
    End Function

    Private Function actualizarAtomo(ByVal pAtomo As AtomoPerfil) As Mensaje
        Try
            With pAtomo
                msg = iPerfd.escribir(sPerfilId, .OpcionId, .Activo, .Consulta, .Mdfccion, .Creacion, .Cnlacion, .Cierre).clonar()
            End With
        Catch ex As Exception
            msg.setError("No fue posible actualizar el atomo " + pAtomo.ToString + ": " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function obtenerAtomo(ByVal pOpcnid As String) As AtomoPerfil
        Dim atm As AtomoPerfil = obtenerNodo(atms, pOpcnid)

        If atm Is Nothing Then Throw New Exception("No se encontró el Átomo " + pOpcnid + ".")
        Return atm
    End Function


    Private Function obtenerNodo(ByVal pAtomoPerfil As AtomoPerfil, ByVal pOpcnid As String) As AtomoPerfil
        Dim atomo As AtomoPerfil = Nothing
        Dim itmCounter As Integer = 0

        If pAtomoPerfil.OpcionId.Equals(pOpcnid) Then
            atomo = pAtomoPerfil
        ElseIf Not pAtomoPerfil.Atomos Is Nothing Then
            For itmCounter = 0 To pAtomoPerfil.Atomos.Count - 1
                atomo = obtenerNodo(pAtomoPerfil.Atomos.Item(itmCounter), pOpcnid)

                If Not atomo Is Nothing Then Exit For
            Next
        End If

        Return atomo
    End Function


    Public Sub reiniciar(ByVal pPerfilId As String)
        sPerfilId = pPerfilId
        buscarDetalles(pPerfilId)
    End Sub
    Public Sub liberarObjetos()
        iPerfd = Nothing
        atms = Nothing
    End Sub
End Class

Partial Public Class AtomoPerfil
    Private sNmbMost As String
    Private sOpcionId As String
    Private sOpcnidp As String
    Private sPrmsosap As String
    Private bActivo As Boolean
    Private bConsulta As Boolean
    Private bMdfccion As Boolean
    Private bCreacion As Boolean
    Private bCnlacion As Boolean
    Private bCierre As Boolean

    Private atm As List(Of AtomoPerfil)

    Public ReadOnly Property NmbMost() As String
        Get
            Return sNmbMost
        End Get
    End Property
    Public ReadOnly Property OpcionId() As String
        Get
            Return sOpcionId
        End Get
    End Property
    Public ReadOnly Property Opcnidp() As String
        Get
            Return sOpcnidp
        End Get
    End Property
    Public ReadOnly Property Prmsosap() As String
        Get
            Return sPrmsosap
        End Get
    End Property
    Public ReadOnly Property Activo() As Boolean
        Get
            Return bActivo
        End Get
    End Property
    Public ReadOnly Property Consulta() As Boolean
        Get
            Return bConsulta
        End Get
    End Property
    Public ReadOnly Property Mdfccion() As Boolean
        Get
            Return bMdfccion
        End Get
    End Property
    Public ReadOnly Property Creacion() As Boolean
        Get
            Return bCreacion
        End Get
    End Property
    Public ReadOnly Property Cnlacion() As Boolean
        Get
            Return bCnlacion
        End Get
    End Property
    Public ReadOnly Property Cierre() As Boolean
        Get
            Return bCierre
        End Get
    End Property

    Public ReadOnly Property Atomos() As List(Of AtomoPerfil)
        Get
            Return atm
        End Get
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal pNmbMost As String, ByVal pOpcionid As Integer, ByVal pOpcnidp As Integer, ByVal pPrmsosap As Integer, _
                   ByVal pActivo As Integer, ByVal pConsulta As Integer, _
                    ByVal pMdfccion As Integer, ByVal pCreacion As Integer, ByVal pCnlacion As Integer, ByVal pCierre As Integer)
        sNmbMost = pNmbMost
        sOpcionId = pOpcionid
        sOpcnidp = pOpcnidp
        sPrmsosap = pPrmsosap
        bActivo = pActivo
        bConsulta = pConsulta
        bMdfccion = pMdfccion
        bCreacion = pCreacion
        bCnlacion = pCnlacion
        bCierre = pCierre

        atm = New List(Of AtomoPerfil)
    End Sub

    Public Sub aniadir(ByVal pAtomo As AtomoPerfil)
        If atm Is Nothing Then atm = New List(Of AtomoPerfil)

        atm.Add(patomo)
    End Sub

    Public Sub revalorar(ByVal pActivo As Boolean, ByVal pConsulta As Boolean, _
                         ByVal pMdfccion As Boolean, ByVal pCreacion As Boolean, _
                         ByVal pCnlacion As Boolean, ByVal pCierre As Boolean)
        bActivo = pActivo
        bConsulta = pConsulta
        bMdfccion = pMdfccion
        bCreacion = pCreacion
        bCnlacion = pCnlacion
        bCierre = pCierre
    End Sub

    Public Sub reiniciar()
        sNmbMost = ""
        sOpcionId = ""
        sOpcnidp = ""
        sPrmsosap = ""
        bActivo = "0"
        bConsulta = "0"
        bMdfccion = "0"
        bCreacion = "0"
        bCnlacion = "0"
        bCierre = "0"
    End Sub

    Public Overrides Function ToString() As String
        Return sNmbMost
    End Function

End Class