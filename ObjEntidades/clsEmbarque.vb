Imports Genericas
Imports IfcDatos

Partial Public Class Embarque
    Private msg As Mensaje
    Private iEmb As iEmbarque

    Private sEmbId As String
    Private sOrdenId As String
    Private sReftrans As String
    Private sDstinoId As String
    Private sDstino As String
    Private sProvflet As String
    Private sPesoemb As String
    Private sFchemb As String
    Private sNoselloe As String
    Private sFchrec As String
    Private sPesore As String
    Private sDif As String
    Private sOprdorId As String
    Private sSilo As String
    Private sSellorec As String
    Private sFactfl As String
    Private sObgen As String
    Private sUsrcrea As String
    Private sUsrmod As String
    Private sFchcrea As String
    Private sFchmod As String
    Private sEstadoId As String
    Private sMonedaId As String
    Private sTarifa As String
    Private sRefcrgmas As String

    Private sLoteId As String
    Private sTrigoId As String
    Private sTrigo As String
    Private sProvTrigoId As String
    Private sProvTrigo As String
    Private sOrigenId As String
    Private sOrigen As String
    Private sOprdor As String
    Private sProvfletn As String


    Private ipt As InspeccionTrigo

    Private iptr As InspeccionTransporte
    Private lab As Laboratorio

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property EmbId() As String
        Get
            Return sEmbId
        End Get
    End Property
    Public ReadOnly Property OrdenId() As String
        Get
            Return sOrdenId
        End Get
    End Property
    Public ReadOnly Property Reftrans() As String
        Get
            Return sReftrans
        End Get
    End Property
    Public ReadOnly Property DstinoId() As String
        Get
            Return sDstinoId
        End Get
    End Property

    Public ReadOnly Property Dstino() As String
        Get
            Return sDstino
        End Get
    End Property

    Public ReadOnly Property Provflet() As String
        Get
            Return sProvflet
        End Get
    End Property
    Public ReadOnly Property Pesoemb() As String
        Get
            Return sPesoemb
        End Get
    End Property
    Public ReadOnly Property Fchemb() As String
        Get
            Return sFchemb
        End Get
    End Property
    Public ReadOnly Property Noselloe() As String
        Get
            Return sNoselloe
        End Get
    End Property
    Public ReadOnly Property Fchrec() As String
        Get
            Return sFchrec
        End Get
    End Property
    Public ReadOnly Property Pesore() As String
        Get
            Return sPesore
        End Get
    End Property
    Public ReadOnly Property Dif() As String
        Get
            Return sDif
        End Get
    End Property
    Public ReadOnly Property OprdorId() As String
        Get
            Return sOprdorId
        End Get
    End Property
    Public ReadOnly Property Silo() As String
        Get
            Return sSilo
        End Get
    End Property
    Public ReadOnly Property Sellorec() As String
        Get
            Return sSellorec
        End Get
    End Property
    Public ReadOnly Property Factfl() As String
        Get
            Return sFactfl
        End Get
    End Property
    Public ReadOnly Property Obgen() As String
        Get
            Return sObgen
        End Get
    End Property
    Public ReadOnly Property Usrcrea() As String
        Get
            Return sUsrcrea
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public ReadOnly Property Fchcrea() As String
        Get
            Return sFchcrea
        End Get
    End Property
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property EstadoId() As String
        Get
            Return sEstadoId
        End Get
    End Property
    Public ReadOnly Property MonedaId() As String
        Get
            Return sMonedaId
        End Get
    End Property
    Public ReadOnly Property Tarifa() As String
        Get
            Return sTarifa
        End Get
    End Property

    Public ReadOnly Property Refcrgmas() As String
        Get
            Return sRefcrgmas
        End Get
    End Property

    Public ReadOnly Property LoteId() As String
        Get
            Return sLoteId
        End Get
    End Property

    Public ReadOnly Property TrigoId() As String
        Get
            Return sTrigoId
        End Get
    End Property

    Public ReadOnly Property Trigo() As String
        Get
            Return sTrigo
        End Get
    End Property

    Public ReadOnly Property ProvTrigoId() As String
        Get
            Return sProvTrigoId
        End Get
    End Property

    Public ReadOnly Property ProvTrigo() As String
        Get
            Return sProvTrigo
        End Get
    End Property

    Public ReadOnly Property OrigenId() As String
        Get
            Return sOrigenId
        End Get
    End Property

    Public ReadOnly Property Origen() As String
        Get
            Return sOrigen
        End Get
    End Property

    Public ReadOnly Property Oprdor() As String
        Get
            Return sOprdor
        End Get
    End Property

    Public ReadOnly Property Provfletn() As String
        Get
            Return sProvfletn
        End Get
    End Property


    Public Property InspeccionTrigo() As InspeccionTrigo
        Get
            Return ipt
        End Get
        Set(ipt_value As InspeccionTrigo)
            ipt = ipt_value
        End Set
    End Property

    Public Property InspeccionTransporte() As InspeccionTransporte
        Get
            Return iptr
        End Get
        Set(iptr_value As InspeccionTransporte)
            iptr = iptr_value
        End Set
    End Property

    Public Property Laboratorio() As Laboratorio
        Get
            Return lab
        End Get
        Set(lab_value As Laboratorio)
            lab = lab_value
        End Set
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pEmbid As String, ByVal pOrdenid As String, ByVal pReftrans As String,
                   ByVal pDstinoid As String, ByVal pDstino As String,
                   ByVal pProvflet As String, ByVal pProvfletn As String,
                   ByVal pPesoemb As Decimal, ByVal pFchemb As String, ByVal pNoselloe As String, ByVal pFchrec As String,
                   ByVal pPesore As Decimal, ByVal pDif As Decimal, ByVal pOprdorid As String, ByVal pSilo As String, ByVal pSellorec As String,
                   ByVal pFactfl As String, ByVal pObgen As String, ByVal pUsrcrea As String, ByVal pUsrmod As String, ByVal pFchcrea As String,
                   ByVal pFchmod As String, ByVal pEstadoid As String, ByVal pMonedaId As String, ByVal pTarifa As Decimal,
                   ByVal pLoteId As String, ByVal pTrigoId As String, ByVal pTrigo As String, ByVal pProvTrigoId As String,
                   ByVal pProvTrigo As String, ByVal pOrigenId As String, ByVal pOrigen As String, ByVal pOprdor As String,
                   ByVal pRefcrgmas As String)
        msg = New Mensaje

        iEmb = New iEmbarque(pCliente)

        sEmbId = pEmbid
        sOrdenId = pOrdenid
        sReftrans = pReftrans
        sDstinoId = pDstinoid
        sDstino = pDstino
        sProvflet = pProvflet
        sProvfletn = pProvfletn
        sPesoemb = pPesoemb
        sFchemb = pFchemb
        sNoselloe = pNoselloe
        sFchrec = pFchrec
        sPesore = pPesore
        sDif = pDif
        sOprdorId = pOprdorid
        sSilo = pSilo
        sSellorec = pSellorec
        sFactfl = pFactfl
        sObgen = pObgen
        sUsrcrea = pUsrcrea
        sUsrmod = pUsrmod
        sFchcrea = pFchcrea
        sFchmod = pFchmod
        sEstadoId = pEstadoid
        sMonedaId = pMonedaId
        sTarifa = pTarifa
        sOrigenId = pOrigenId


        sLoteId = pLoteId
        sTrigoId = pTrigoId
        sTrigo = pTrigo
        sProvTrigoId = pProvTrigoId
        sProvTrigo = pProvTrigo


        sRefcrgmas = pRefcrgmas

        ipt = New InspeccionTrigo(pCliente)
        iptr = New InspeccionTransporte(pCliente)
        lab = New Laboratorio(pCliente)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pEmbid As String)
        msg = New Mensaje
        iEmb = New iEmbarque(pCliente)

        buscarEmbarque(pEmbid)

        ipt = New InspeccionTrigo(pCliente, pEmbid)
        iptr = New InspeccionTransporte(pCliente, pEmbid)
        lab = New Laboratorio(pCliente, pEmbid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iEmb = New iEmbarque(pCliente)

        ipt = New InspeccionTrigo(pCliente)
        iptr = New InspeccionTransporte(pCliente)
        lab = New Laboratorio(pCliente)

        reiniciar()
    End Sub



    Private Function buscarEmbarque(ByVal pEmbid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iEmb.leer(pEmbid)
            msg = iEmb.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
            sOrdenId = gen3E.valorCampo(resultados, 0, "OrdenId")
            sReftrans = gen3E.valorCampo(resultados, 0, "Reftrans")
            sDstinoId = gen3E.valorCampo(resultados, 0, "DstinoId")
            sDstino = gen3E.valorCampo(resultados, 0, "Dstino")
            sProvflet = gen3E.valorCampo(resultados, 0, "Provflet")
            sProvfletn = gen3E.valorCampo(resultados, 0, "Provfletn")
            sPesoemb = gen3E.valorCampo(resultados, 0, "Pesoemb")
            sFchemb = gen3E.valorCampo(resultados, 0, "Fchemb")
            sNoselloe = gen3E.valorCampo(resultados, 0, "Noselloe")
            sFchrec = gen3E.valorCampo(resultados, 0, "Fchrec")
            sPesore = gen3E.valorCampo(resultados, 0, "Pesore")
            sDif = gen3E.valorCampo(resultados, 0, "Dif")
            sOprdorId = gen3E.valorCampo(resultados, 0, "OprdorId")
            sSilo = gen3E.valorCampo(resultados, 0, "Silo")
            sSellorec = gen3E.valorCampo(resultados, 0, "Sellorec")
            sFactfl = gen3E.valorCampo(resultados, 0, "Factfl")
            sObgen = gen3E.valorCampo(resultados, 0, "Obgen")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            sEstadoId = gen3E.valorCampo(resultados, 0, "EstadoId")
            sMonedaId = gen3E.valorCampo(resultados, 0, "MonedaId")
            sTarifa = gen3E.valorCampo(resultados, 0, "Tarifa")
            sLoteId = gen3E.valorCampo(resultados, 0, "LoteId")
            sTrigoId = gen3E.valorCampo(resultados, 0, "TrigoId")
            sTrigo = gen3E.valorCampo(resultados, 0, "Trigo")
            sProvTrigoId = gen3E.valorCampo(resultados, 0, "ProvTrigoId")
            sProvTrigo = gen3E.valorCampo(resultados, 0, "ProvTrigo")
            sOrigenId = gen3E.valorCampo(resultados, 0, "OrigenId")
            sOrigen = gen3E.valorCampo(resultados, 0, "Origen")
            sOprdor = gen3E.valorCampo(resultados, 0, "Oprdor")
            sRefcrgmas = gen3E.valorCampo(resultados, 0, "Refcrgmas")

            msg.setInfo("Embarque " + pEmbid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Embarque desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sEmbId = iEmb.siguienteNo().ToString
            msg = iEmb.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iEmb.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iEmb.escribir(sEmbId, sOrdenId, sReftrans, sDstinoId, sProvflet, sPesoemb, sFchemb, sNoselloe, sFchrec, sPesore,
                                sDif, sOprdorId, sSilo, sSellorec, sFactfl, sObgen, sUsrcrea, sUsrmod, sFchcrea, sFchmod, sEstadoId,
                                sMonedaId, sTarifa, sRefcrgmas).clonar()

            If msg.EsError Then GoTo esError

            msg = ipt.guardar(sEmbId).clonar()
            If msg.EsError Then GoTo esError

            msg = iptr.guardar(sEmbId).clonar()
            If msg.EsError Then GoTo esError

            msg = lab.guardar(sEmbId).clonar()
esError:
            If msg.EsError Then
                iEmb.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iEmb.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Embarque " + sEmbId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function embarqueAnterior(ByVal pEmbId As String) As String
        Dim embarq As String = iEmb.embarqueAnterior(pEmbId)
        If iEmb.Mensaje.EsError Then Throw New Exception(iEmb.Mensaje.Descripcion)

        Return embarq
    End Function

    Public Function embarqueSiguiente(ByVal pEmbId As String) As String
        Dim embarq As String = iEmb.embarqueSiguiente(pEmbId)
        If iEmb.Mensaje.EsError Then Throw New Exception(iEmb.Mensaje.Descripcion)

        Return embarq
    End Function

    Public Function buscarCambios(ByVal pEmbId As String) As DataTable
        Dim resultados As DataTable = iEmb.buscarCambios(pEmbId)
        If iEmb.Mensaje.EsError Then Throw New Exception(iEmb.Mensaje.Descripcion)

        Return resultados
    End Function

    Public Function sinFacturaFlete() As DataTable
        Dim resultados As DataTable = iEmb.sinFacturaFlete()
        If iEmb.Mensaje.EsError Then Throw New Exception(iEmb.Mensaje.Descripcion)

        Return resultados
    End Function


    Public Sub setUsuarioModifica(ByVal pUsrmod As String)
        sUsrmod = pUsrmod
    End Sub

    Public Sub setFacturaFlete(ByVal pFactfl As String)
        sFactfl = pFactfl
    End Sub
    Public Sub setTarifa(ByVal pTarifa As Decimal)
        sTarifa = pTarifa
    End Sub

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iEmb.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iEmb.actualizar(sEmbId, sOrdenId, sReftrans, sDstinoId, sProvflet, sPesoemb, sFchemb, sNoselloe, sFchrec, sPesore,
                                sDif, sOprdorId, sSilo, sSellorec, sFactfl, sObgen, sUsrcrea, sUsrmod, sFchcrea, sFchmod, sEstadoId,
                                sMonedaId, sTarifa, sRefcrgmas).clonar()

            If msg.EsError Then GoTo esError

            If Not sUsrmod.Equals(ipt.Usrmod) Then ipt.setUsuarioModifica(sUsrmod)
            msg = ipt.actualizar().clonar()
            If msg.EsError Then GoTo esError

            If Not sUsrmod.Equals(iptr.Usrmod) Then iptr.setUsuarioModifica(sUsrmod)
            msg = iptr.actualizar().clonar()
            If msg.EsError Then GoTo esError

            If Not sUsrmod.Equals(lab.Usrmod) Then lab.setUsuarioModifica(sUsrmod)
            msg = lab.actualizar().clonar()

esError:
            If msg.EsError Then
                iEmb.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iEmb.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Embarque " + sEmbId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sEmbId = iEmb.siguienteNo()

        sOrdenId = ""
        sReftrans = ""
        sDstinoId = ""
        sProvflet = ""
        sPesoemb = "0"
        sFchemb = ""
        sNoselloe = ""
        sFchrec = ""
        sPesore = "0"
        sDif = "0"
        sOprdorId = ""
        sSilo = ""
        sSellorec = ""
        sFactfl = ""
        sObgen = ""
        sUsrcrea = ""
        sUsrmod = ""
        sFchcrea = ""
        sFchmod = ""
        sEstadoId = ""
        sMonedaId = ""
        sTarifa = "0"
        sRefcrgmas = ""


        ipt.reiniciar()
        iptr.reiniciar()
        lab.reiniciar()
    End Sub

    Public Sub liberarObjetos()
        sEmbId = ""
        sOrdenId = ""
        sReftrans = ""
        sDstinoId = ""
        sProvflet = ""
        sPesoemb = "0"
        sFchemb = ""
        sNoselloe = ""
        sFchrec = ""
        sPesore = "0"
        sDif = "0"
        sOprdorId = ""
        sSilo = ""
        sSellorec = ""
        sFactfl = ""
        sObgen = ""
        sUsrcrea = ""
        sUsrmod = ""
        sFchcrea = ""
        sFchmod = ""
        sEstadoId = ""
        sMonedaId = ""
        sTarifa = "0"
        sRefcrgmas = ""


        iEmb = Nothing

        ipt.liberarObjetos()
        ipt = Nothing

        iptr.liberarObjetos()
        iptr = Nothing

        lab.liberarObjetos()
        lab = Nothing
    End Sub
End Class

Partial Public Class InspeccionTrigo
    Private msg As Mensaje
    Private iIpt As iInspeccionTrigo

    Private bCondlimp As Boolean
    Private sOlor As String
    Private sColor As String
    Private sDanado As String
    Private sPlagas As String
    Private sOtros As String
    Private sEmbId As String
    Private sUsrmod As String
    Private sFchmod As String
    Private bConforme As Boolean
    Private sObserv As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property Condlimp() As Boolean
        Get
            Return bCondlimp
        End Get
    End Property
    Public ReadOnly Property Olor() As String
        Get
            Return sOlor
        End Get
    End Property
    Public ReadOnly Property Color() As String
        Get
            Return sColor
        End Get
    End Property
    Public ReadOnly Property Danado() As String
        Get
            Return sDanado
        End Get
    End Property
    Public ReadOnly Property Plagas() As String
        Get
            Return sPlagas
        End Get
    End Property
    Public ReadOnly Property Otros() As String
        Get
            Return sOtros
        End Get
    End Property
    Public ReadOnly Property EmbId() As String
        Get
            Return sEmbId
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property Conforme() As Boolean
        Get
            Return bConforme
        End Get
    End Property
    Public ReadOnly Property Observ() As String
        Get
            Return sObserv
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pEmbid As String)
        msg = New Mensaje
        iIpt = New iInspeccionTrigo(pCliente)

        buscarIpt(pEmbid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iIpt = New iInspeccionTrigo(pCliente)

        reiniciar()
    End Sub

    Public Function alimentar(ByVal pCondlimp As Integer, ByVal pOlor As String, ByVal pColor As String,
                              ByVal pDanado As String, ByVal pPlagas As String, ByVal pOtros As String,
                              ByVal pEmbid As String, ByVal pUsrmod As String, ByVal pFchmod As String,
                              ByVal pConforme As Boolean, ByVal pObserv As String) As Mensaje
        Try
            msg.reset()

            bCondlimp = pCondlimp
            sOlor = pOlor
            sColor = pColor
            sDanado = pDanado
            sPlagas = pPlagas
            sOtros = pOtros
            sEmbId = pEmbid
            sUsrmod = pUsrmod
            sFchmod = pFchmod
            bConforme = pConforme
            sObserv = pObserv

        Catch ex As Exception
            msg.setError("No fue posible alimentar la variables de Inspección Primaria al Trigo: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Function buscarIpt(ByVal pEmbid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iIpt.leer(pEmbid)
            msg = iIpt.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            bCondlimp = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Condlimp", "false"))
            sOlor = gen3E.valorCampo(resultados, 0, "Olor")
            sColor = gen3E.valorCampo(resultados, 0, "Color")
            sDanado = gen3E.valorCampo(resultados, 0, "Danado")
            sPlagas = gen3E.valorCampo(resultados, 0, "Plagas")
            sOtros = gen3E.valorCampo(resultados, 0, "Otros")
            sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            bConforme = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Conforme"))
            sObserv = gen3E.valorCampo(resultados, 0, "Observ")


            msg.setInfo("Inspección Primaria al Trigo " + pEmbid + " buscada y encontrada desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar la Inspección Primaria al Trigo desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Public Sub setUsuarioModifica(ByVal pUsrmod As String)
        sUsrmod = pUsrmod
    End Sub

    Public Function guardar(ByVal pEmbId As String) As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sEmbId = pEmbId
            msg = iIpt.escribir(bCondlimp, sOlor, sColor, sDanado, sPlagas, sOtros, sEmbId, sUsrmod,
                                sFchmod, bConforme, sObserv).clonar()


            If Not msg.EsError Then msg.setExclamacion("Inspección Primaria al Trigo " + sEmbId + " creada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iIpt.actualizar(bCondlimp, sOlor, sColor, sDanado, sPlagas, sOtros, sEmbId, sUsrmod,
                                sFchmod, bConforme, sObserv).clonar()


            If Not msg.EsError Then msg.setInfo("Inspección Primaria al Trigo " + sEmbId + " actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        bCondlimp = "0"
        sOlor = ""
        sColor = ""
        sDanado = ""
        sPlagas = ""
        sOtros = ""
        sEmbId = ""
        sUsrmod = ""
        sFchmod = ""
        bConforme = "0"
        sObserv = ""
    End Sub
    Public Sub liberarObjetos()
        bCondlimp = "0"
        sOlor = ""
        sColor = ""
        sDanado = ""
        sPlagas = ""
        sOtros = ""
        sEmbId = ""
        sUsrmod = ""
        sFchmod = ""
        bConforme = "0"
        sObserv = ""

        iIpt = Nothing
    End Sub
End Class

Partial Public Class InspeccionTransporte
    Private msg As Mensaje
    Private iIptr As iInspeccionTransporte

    Private bCondtra As Boolean
    Private sLibreba As String
    Private sLibregr As String
    Private sOtros As String
    Private sSellosc As String
    Private sServtra As String
    Private sEmbId As String
    Private sUsrmod As String
    Private sFchmod As String
    Private bConforme As Boolean
    Private sObserv As String


    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property Condtra() As Boolean
        Get
            Return bCondtra
        End Get
    End Property
    Public ReadOnly Property Libreba() As String
        Get
            Return sLibreba
        End Get
    End Property
    Public ReadOnly Property Libregr() As String
        Get
            Return sLibregr
        End Get
    End Property
    Public ReadOnly Property Otros() As String
        Get
            Return sOtros
        End Get
    End Property
    Public ReadOnly Property Sellosc() As String
        Get
            Return sSellosc
        End Get
    End Property
    Public ReadOnly Property Servtra() As String
        Get
            Return sServtra
        End Get
    End Property
    Public ReadOnly Property EmbId() As String
        Get
            Return sEmbId
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property Conforme() As Boolean
        Get
            Return bConforme
        End Get
    End Property
    Public ReadOnly Property Observ() As String
        Get
            Return sObserv
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pEmbid As String)
        msg = New Mensaje
        iIptr = New iInspeccionTransporte(pCliente)

        buscarIptr(pEmbid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iIptr = New iInspeccionTransporte(pCliente)

        reiniciar()
    End Sub

    Public Function alimentar(ByVal pCondtra As Integer, ByVal pLibreba As String, ByVal pLibregr As String,
                              ByVal pOtros As String, ByVal pSellosc As String, ByVal pServtra As String, ByVal pEmbid As String,
                              ByVal pUsrmod As String, ByVal pFchmod As String, ByVal pConforme As Boolean, ByVal pObserv As String) As Mensaje
        Try
            msg.reset()

            bCondtra = pCondtra
            sLibreba = pLibreba
            sLibregr = pLibregr
            sOtros = pOtros
            sSellosc = pSellosc
            sServtra = pServtra
            sEmbId = pEmbid
            sUsrmod = pUsrmod
            sFchmod = pFchmod
            bConforme = pConforme
            sObserv = pObserv
        Catch ex As Exception
            msg.setError("No fue posible alimentar la variables de Inspección Primaria al Transporte: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Function buscarIptr(ByVal pEmbid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iIptr.leer(pEmbid)
            msg = iIptr.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            bCondtra = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Condtra", "false"))
            sLibreba = gen3E.valorCampo(resultados, 0, "Libreba")
            sLibregr = gen3E.valorCampo(resultados, 0, "Libregr")
            sOtros = gen3E.valorCampo(resultados, 0, "Otros")
            sSellosc = gen3E.valorCampo(resultados, 0, "Sellosc")
            sServtra = gen3E.valorCampo(resultados, 0, "Servtra")
            sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            bConforme = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Conforme"))
            sObserv = gen3E.valorCampo(resultados, 0, "Observ")

            msg.setInfo("Inspección Primaria al Transporte " + pEmbid + " buscada y encontrada desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar la Inspección Primaria al Transporte desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Public Sub setUsuarioModifica(ByVal pUsrmod As String)
        sUsrmod = pUsrmod
    End Sub

    Public Function guardar(ByVal pEmbId As String) As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sEmbId = pEmbId

            msg = iIptr.escribir(bCondtra, sLibreba, sLibregr, sOtros, sSellosc, sServtra, sEmbId,
                                sUsrmod, sFchmod, bConforme, sObserv).clonar()


            If Not msg.EsError Then msg.setExclamacion("Inspección Primaria al Transporte " + sEmbId + " creada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Public Function actualizar() As Mensaje

        Try
            msg = iIptr.actualizar(bCondtra, sLibreba, sLibregr, sOtros, sSellosc, sServtra, sEmbId,
                                sUsrmod, sFchmod, bConforme, sObserv).clonar()


            If Not msg.EsError Then msg.setInfo("Inspección Primaria al Transporte " + sEmbId + " actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        bCondtra = "0"
        sLibreba = ""
        sLibregr = ""
        sOtros = ""
        sSellosc = ""
        sServtra = ""
        sEmbId = ""
        sUsrmod = ""
        sFchmod = ""
        bConforme = "0"
        sObserv = ""
    End Sub

    Public Sub liberarObjetos()
        bCondtra = "0"
        sLibreba = ""
        sLibregr = ""
        sOtros = ""
        sSellosc = ""
        sServtra = ""
        sEmbId = ""
        sUsrmod = ""
        sFchmod = ""
        bConforme = "0"
        sObserv = ""

        iIptr = Nothing
    End Sub
End Class

Partial Public Class Laboratorio
    Private msg As Mensaje
    Private iLab As iLaboratorio

    Private sEprot As String
    Private sEhum As String
    Private sEphl As String
    Private sEimp As String
    Private sRprot As String
    Private sRhum As String
    Private sRphl As String
    Private sRimp As String
    Private sOblab As String
    Private sEmbId As String
    Private sUsrmod As String
    Private sFchmod As String
    Private bLab As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property Eprot() As String
        Get
            Return sEprot
        End Get
    End Property
    Public ReadOnly Property Ehum() As String
        Get
            Return sEhum
        End Get
    End Property
    Public ReadOnly Property Ephl() As String
        Get
            Return sEphl
        End Get
    End Property
    Public ReadOnly Property Eimp() As String
        Get
            Return sEimp
        End Get
    End Property
    Public ReadOnly Property Rprot() As String
        Get
            Return sRprot
        End Get
    End Property
    Public ReadOnly Property Rhum() As String
        Get
            Return sRhum
        End Get
    End Property
    Public ReadOnly Property Rphl() As String
        Get
            Return sRphl
        End Get
    End Property
    Public ReadOnly Property Rimp() As String
        Get
            Return sRimp
        End Get
    End Property
    Public ReadOnly Property Oblab() As String
        Get
            Return sOblab
        End Get
    End Property
    Public ReadOnly Property EmbId() As String
        Get
            Return sEmbId
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public ReadOnly Property Fchmod() As String
        Get
            Return sFchmod
        End Get
    End Property
    Public ReadOnly Property Lab() As Boolean
        Get
            Return bLab
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pEmbid As String)
        msg = New Mensaje
        iLab = New iLaboratorio(pCliente)

        buscarLaboratorio(pEmbid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iLab = New iLaboratorio(pCliente)

        reiniciar()
    End Sub

    Public Function alimentar(ByVal pEprot As Decimal, ByVal pEhum As Decimal, ByVal pEphl As Decimal, ByVal pEimp As Decimal, _
                              ByVal pRprot As Decimal, ByVal pRhum As Decimal, ByVal pRphl As Decimal, ByVal pRimp As Decimal, _
                              ByVal pOblab As String, ByVal pEmbid As String, ByVal pUsrmod As String, ByVal pFchmod As String, _
                              ByVal pLab As Integer) As Mensaje
        Try
            msg.reset()

            sEprot = pEprot
            sEhum = pEhum
            sEphl = pEphl
            sEimp = pEimp
            sRprot = pRprot
            sRhum = pRhum
            sRphl = pRphl
            sRimp = pRimp
            sOblab = pOblab
            sEmbId = pEmbid
            sUsrmod = pUsrmod
            sFchmod = pFchmod
            bLab = pLab

        Catch ex As Exception
            msg.setError("No fue posible alimentar la variables de Laboratorio: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Function buscarLaboratorio(ByVal pEmbid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iLab.leer(pEmbid)
            msg = iLab.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sEprot = gen3E.valorCampo(resultados, 0, "Eprot")
            sEhum = gen3E.valorCampo(resultados, 0, "Ehum")
            sEphl = gen3E.valorCampo(resultados, 0, "Ephl")
            sEimp = gen3E.valorCampo(resultados, 0, "Eimp")
            sRprot = gen3E.valorCampo(resultados, 0, "Rprot")
            sRhum = gen3E.valorCampo(resultados, 0, "Rhum")
            sRphl = gen3E.valorCampo(resultados, 0, "Rphl")
            sRimp = gen3E.valorCampo(resultados, 0, "Rimp")
            sOblab = gen3E.valorCampo(resultados, 0, "Oblab")
            sEmbId = gen3E.valorCampo(resultados, 0, "EmbId")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            bLab = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Lab", "false"))

            msg.setInfo("Reporte de Laboratorio " + pEmbid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Reporte de Laboratorio desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Public Sub setUsuarioModifica(ByVal pUsrmod As String)
        sUsrmod = pUsrmod
    End Sub

    Public Function guardar(ByVal pEmbId As String) As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sEmbId = pEmbId

            msg = iLab.escribir(sEprot, sEhum, sEphl, sEimp, sRprot, sRhum, sRphl, sRimp, sOblab, _
                                sEmbId, sUsrmod, sFchmod, bLab).clonar()


            If Not msg.EsError Then msg.setExclamacion("Reporte de Laboratorio " + sEmbId + " creada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function


    Public Function actualizar() As Mensaje

        Try
            msg = iLab.actualizar(sEprot, sEhum, sEphl, sEimp, sRprot, sRhum, sRphl, sRimp, sOblab, _
                                sEmbId, sUsrmod, sFchmod, bLab).clonar()


            If Not msg.EsError Then msg.setInfo("Reporte de Laboratorio " + sEmbId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sEprot = "0"
        sEhum = "0"
        sEphl = "0"
        sEimp = "0"
        sRprot = "0"
        sRhum = "0"
        sRphl = "0"
        sRimp = "0"
        sOblab = ""
        sEmbId = ""
        sUsrmod = ""
        sFchmod = ""
        bLab = "0"
    End Sub

    Public Sub liberarObjetos()
        sEprot = "0"
        sEhum = "0"
        sEphl = "0"
        sEimp = "0"
        sRprot = "0"
        sRhum = "0"
        sRphl = "0"
        sRimp = "0"
        sOblab = ""
        sEmbId = ""
        sUsrmod = ""
        sFchmod = ""
        bLab = "0"

        iLab = Nothing
    End Sub
End Class