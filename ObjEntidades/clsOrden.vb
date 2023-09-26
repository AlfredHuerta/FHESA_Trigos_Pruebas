Imports System.IO

Imports Genericas
Imports IfcDatos

Public Class Orden
    Private msg As Mensaje
    Private iOrd As iOrden
    Private iAdj As iAdjuntoOrden

    Private sOrdenId As String
    Private sCtrtoId As String
    Private sLoteId As String
    Private sOrigenId As String
    Private sNmborigen As String
    Private sTnladas As String
    Private sTlrancia As String
    Private sPeremb As String
    Private sIncoterm As String
    Private sRitmo As String
    Private sMoneda As String
    Private sRefftro As String
    Private sBase As String
    Private sMesfutu As String
    Private sPrcionto As String
    Private sObsrv As String
    Private sLaycan As String
    Private sPtocarga As String
    Private sPtodscg As String
    Private sNorcg As String
    Private sNordscg As String
    Private sLaytime As String
    Private sCondpgo As String
    Private sTasadmra As String
    Private sUsrmod As String
    Private sUsrcrea As String
    Private sFchcrea As String
    Private sFchmod As String
    Private sEstadoId As String
    Private sProvId As String
    Private sNmbprvfl As String
    Private sFchord As String
    Private sRspnsble As String
    Private sRitmod As String

    Private lAdj As List(Of AdjuntoOrden)

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property OrdenId() As String
        Get
            Return sOrdenId
        End Get
    End Property
    Public ReadOnly Property CtrtoId() As String
        Get
            Return sCtrtoId
        End Get
    End Property
    Public ReadOnly Property LoteId() As String
        Get
            Return sLoteId
        End Get
    End Property

    Public ReadOnly Property Nmborigen() As String
        Get
            Return sNmborigen
        End Get
    End Property

    Public ReadOnly Property OrigenId() As String
        Get
            Return sOrigenId
        End Get
    End Property
    Public ReadOnly Property Tnladas() As String
        Get
            Return sTnladas
        End Get
    End Property
    Public ReadOnly Property Tlrancia() As String
        Get
            Return sTlrancia
        End Get
    End Property
    Public ReadOnly Property Peremb() As String
        Get
            Return sPeremb
        End Get
    End Property
    Public ReadOnly Property Incoterm() As String
        Get
            Return sIncoterm
        End Get
    End Property
    Public ReadOnly Property Ritmo() As String
        Get
            Return sRitmo
        End Get
    End Property
    Public ReadOnly Property Moneda() As String
        Get
            Return sMoneda
        End Get
    End Property
    Public ReadOnly Property Refftro() As String
        Get
            Return sRefftro
        End Get
    End Property
    Public ReadOnly Property Base() As String
        Get
            Return sBase
        End Get
    End Property
    Public ReadOnly Property Mesfutu() As String
        Get
            Return sMesfutu
        End Get
    End Property
    Public ReadOnly Property Prcionto() As String
        Get
            Return sPrcionto
        End Get
    End Property
    Public ReadOnly Property Obsrv() As String
        Get
            Return sObsrv
        End Get
    End Property
    Public ReadOnly Property Laycan() As String
        Get
            Return sLaycan
        End Get
    End Property
    Public ReadOnly Property Ptocarga() As String
        Get
            Return sPtocarga
        End Get
    End Property
    Public ReadOnly Property Ptodscg() As String
        Get
            Return sPtodscg
        End Get
    End Property
    Public ReadOnly Property Norcg() As String
        Get
            Return sNorcg
        End Get
    End Property
    Public ReadOnly Property Nordscg() As String
        Get
            Return sNordscg
        End Get
    End Property
    Public ReadOnly Property Laytime() As String
        Get
            Return sLaytime
        End Get
    End Property
    Public ReadOnly Property Condpgo() As String
        Get
            Return sCondpgo
        End Get
    End Property
    Public ReadOnly Property Tasadmra() As String
        Get
            Return sTasadmra
        End Get
    End Property
    Public ReadOnly Property Usrmod() As String
        Get
            Return sUsrmod
        End Get
    End Property
    Public ReadOnly Property Usrcrea() As String
        Get
            Return sUsrcrea
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
    Public ReadOnly Property ProvId() As String
        Get
            Return sProvId
        End Get
    End Property
    Public ReadOnly Property Nmbprvfl() As String
        Get
            Return sNmbprvfl
        End Get
    End Property

    Public ReadOnly Property Fchord() As String
        Get
            Return sFchord
        End Get
    End Property
    Public ReadOnly Property Rspnsble() As String
        Get
            Return sRspnsble
        End Get
    End Property

    Public ReadOnly Property Ritmod() As String
        Get
            Return sRitmod
        End Get
    End Property

    Public ReadOnly Property AdjuntosOrden() As List(Of AdjuntoOrden)
        Get
            Return lAdj
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pOrdenid As String, ByVal pCtrtoid As String, ByVal pLoteid As String,
                   ByVal pOrigenid As String, ByVal pNmborigen As String,
                   ByVal pTnladas As Decimal, ByVal pTlrancia As String, ByVal pPeremb As String,
                   ByVal pIncoterm As String, ByVal pRitmo As String, ByVal pMoneda As String, ByVal pRefftro As String,
                   ByVal pBase As Decimal, ByVal pMesfutu As Decimal, ByVal pPrcionto As Decimal, ByVal pObsrv As String,
                   ByVal pLaycan As String, ByVal pPtocarga As String, ByVal pPtodscg As String, ByVal pNorcg As String,
                   ByVal pNordscg As String, ByVal pLaytime As String, ByVal pCondpgo As String, ByVal pTasadmra As String,
                   ByVal pUsrmod As String, ByVal pUsrcrea As String, ByVal pFchcrea As String, ByVal pFchmod As String,
                   ByVal pEstadoid As String, ByVal pProvid As String, ByVal pNmbprvfl As String,
                   ByVal pFchord As String, ByVal pRspnsble As String, ByVal pRitmod As String)
        msg = New Mensaje

        iOrd = New iOrden(pCliente)
        iAdj = New iAdjuntoOrden(pCliente)

        sOrdenId = pOrdenid
        sCtrtoId = pCtrtoid
        sLoteId = pLoteid
        sOrigenId = pOrigenid
        sNmborigen = pNmborigen
        sTnladas = pTnladas
        sTlrancia = pTlrancia
        sPeremb = pPeremb
        sIncoterm = pIncoterm
        sRitmo = pRitmo
        sMoneda = pMoneda
        sRefftro = pRefftro
        sBase = pBase
        sMesfutu = pMesfutu
        sPrcionto = pPrcionto
        sObsrv = pObsrv
        sLaycan = pLaycan
        sPtocarga = pPtocarga
        sPtodscg = pPtodscg
        sNorcg = pNorcg
        sNordscg = pNordscg
        sLaytime = pLaytime
        sCondpgo = pCondpgo
        sTasadmra = pTasadmra
        sUsrmod = pUsrmod
        sUsrcrea = pUsrcrea
        sFchcrea = pFchcrea
        sFchmod = pFchmod
        sEstadoId = pEstadoid
        sProvId = pProvid
        sNmbprvfl = pNmbprvfl
        sFchord = pFchord
        sRspnsble = pRspnsble
        sRitmod = pRitmod

        buscarArdjuntosOrden()

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pOrdenId As String)
        msg = New Mensaje
        iOrd = New iOrden(pCliente)
        iAdj = New iAdjuntoOrden(pCliente)

        buscarOrden(pOrdenId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iOrd = New iOrden(pCliente)
        iAdj = New iAdjuntoOrden(pCliente)
        lAdj = New List(Of AdjuntoOrden)

        reiniciar()
    End Sub

    Private Function buscarOrden(ByVal pOrdenId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iOrd.leer(pOrdenId)
            msg = iOrd.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sOrdenId = gen3E.valorCampo(resultados, 0, "OrdenId")
            sCtrtoId = gen3E.valorCampo(resultados, 0, "CtrtoId")
            sLoteId = gen3E.valorCampo(resultados, 0, "LoteId")
            sOrigenId = gen3E.valorCampo(resultados, 0, "OrigenId")
            sNmborigen = gen3E.valorCampo(resultados, 0, "Nmborigen")
            sTnladas = gen3E.valorCampo(resultados, 0, "Tnladas")
            sTlrancia = gen3E.valorCampo(resultados, 0, "Tlrancia")
            sPeremb = gen3E.valorCampo(resultados, 0, "Peremb")
            sIncoterm = gen3E.valorCampo(resultados, 0, "Incoterm")
            sRitmo = gen3E.valorCampo(resultados, 0, "Ritmo")
            sMoneda = gen3E.valorCampo(resultados, 0, "Moneda")
            sRefftro = gen3E.valorCampo(resultados, 0, "Refftro")
            sBase = gen3E.valorCampo(resultados, 0, "Base")
            sMesfutu = gen3E.valorCampo(resultados, 0, "Mesfutu")
            sPrcionto = gen3E.valorCampo(resultados, 0, "Prcionto")
            sObsrv = gen3E.valorCampo(resultados, 0, "Obsrv")
            sLaycan = gen3E.valorCampo(resultados, 0, "Laycan")
            sPtocarga = gen3E.valorCampo(resultados, 0, "Ptocarga")
            sPtodscg = gen3E.valorCampo(resultados, 0, "Ptodscg")
            sNorcg = gen3E.valorCampo(resultados, 0, "Norcg")
            sNordscg = gen3E.valorCampo(resultados, 0, "Nordscg")
            sLaytime = gen3E.valorCampo(resultados, 0, "Laytime")
            sCondpgo = gen3E.valorCampo(resultados, 0, "Condpgo")
            sTasadmra = gen3E.valorCampo(resultados, 0, "Tasadmra")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            sEstadoId = gen3E.valorCampo(resultados, 0, "EstadoId")
            sProvId = gen3E.valorCampo(resultados, 0, "ProvId")
            sNmbprvfl = gen3E.valorCampo(resultados, 0, "Nmbprvfl")
            sFchord = gen3E.valorCampo(resultados, 0, "Fchord")
            sRspnsble = gen3E.valorCampo(resultados, 0, "Rspnsble")
            sRitmod = gen3E.valorCampo(resultados, 0, "Ritmod")

            If buscarArdjuntosOrden().EsError Then GoTo finalize

            msg.setInfo("Orden " + pOrdenId + " buscada y encontrada desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar la Orden desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function

    Private Function buscarArdjuntosOrden() As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0
        Dim adj As AdjuntoOrden = Nothing

        Try
            resultados = iAdj.leer(sOrdenId)
            msg = iOrd.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E
            lAdj = New List(Of AdjuntoOrden)

            For itmCounter = 0 To resultados.Rows.Count - 1
                adj = New AdjuntoOrden(gen3E.valorCampo(resultados, itmCounter, "OrdenId"), _
                                       gen3E.valorCampo(resultados, itmCounter, "instId"), _
                                       gen3E.valorCampo(resultados, itmCounter, "Ruta"), _
                                       gen3E.valorCampo(resultados, itmCounter, "Ruta"), _
                                       gen3E.valorCampo(resultados, itmCounter, "Coments"), _
                                       gen3E.valorCampo(resultados, itmCounter, "extnsion"))

                lAdj.Add(adj)
            Next

        Catch ex As Exception
            msg.setError("No fue posible cargar los archivos adjuntos de la orden: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function setAdjuntos(ByVal pAdjuntos As List(Of AdjuntoOrden)) As Mensaje
        lAdj.Clear()

        Try
            msg.reset()

            lAdj = New List(Of AdjuntoOrden)

            For Each Adjunto As AdjuntoOrden In pAdjuntos
                lAdj.Add(Adjunto.clonar())
            Next
        Catch ex As Exception
            msg.setError("No fue posible procesar los archivos adjuntos: " + ex.Message)
        End Try

        Return msg
    End Function

    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sOrdenId = iOrd.siguienteNo().ToString
            msg = iOrd.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iOrd.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iOrd.escribir(sOrdenId, sCtrtoId, sLoteId, sOrigenId, sTnladas, sTlrancia, sPeremb, sIncoterm, sRitmo, sMoneda,
                                 sRefftro, sBase, sMesfutu, sPrcionto, sObsrv, sLaycan, sPtocarga, sPtodscg, sNorcg, sNordscg,
                                 sLaytime, sCondpgo, sTasadmra, sUsrmod, sUsrcrea, sFchcrea, sFchmod, sEstadoId, sProvId, sFchord,
                                 sRspnsble, sRitmod).clonar()

            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iAdj.removerAdjuntos(sOrdenId).clonar()
            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            For Each Adjunto As AdjuntoOrden In lAdj
                msg = Adjunto.almacenarAdjunto(sOrdenId).clonar()
                If msg.EsError Then
                    iOrd.cancelarTransaccion()
                    GoTo finalize
                End If

                msg = iAdj.escribir(Adjunto.OrdenId, Adjunto.instId, Adjunto.Ruta, Adjunto.Coments, Adjunto.extnsion).clonar()
                If msg.EsError Then
                    iOrd.cancelarTransaccion()
                    GoTo finalize
                End If
            Next

            msg = iOrd.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Orden " + sOrdenId + " creada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function ordenAnterior(ByVal pOrdenId As String) As String
        Dim orden As String = iOrd.ordenAnterior(pOrdenId)
        If iOrd.Mensaje.EsError Then Throw New Exception(iOrd.Mensaje.Descripcion)

        Return orden
    End Function

    Public Function ordenSiguiente(ByVal pOrdenId As String) As String
        Dim lote As String = iOrd.ordenSiguiente(pOrdenId)
        If iOrd.Mensaje.EsError Then Throw New Exception(iOrd.Mensaje.Descripcion)

        Return lote
    End Function

    Public Function buscarCambios(ByVal pOrdenId As String) As DataTable
        Dim resultados As DataTable = iOrd.buscarCambios(pOrdenId)
        If iOrd.Mensaje.EsError Then Throw New Exception(iOrd.Mensaje.Descripcion)

        Return resultados
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iOrd.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iOrd.actualizar(sOrdenId, sCtrtoId, sLoteId, sOrigenId, sTnladas, sTlrancia, sPeremb, sIncoterm, sRitmo, sMoneda,
                                 sRefftro, sBase, sMesfutu, sPrcionto, sObsrv, sLaycan, sPtocarga, sPtodscg, sNorcg, sNordscg,
                                 sLaytime, sCondpgo, sTasadmra, sUsrmod, sUsrcrea, sFchcrea, sFchmod, sEstadoId, sProvId, sFchord,
                                 sRspnsble, sRitmod).clonar()
            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iAdj.removerAdjuntos(sOrdenId).clonar()
            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            For Each Adjunto As AdjuntoOrden In lAdj
                Adjunto.almacenarAdjunto(sOrdenId)
                msg = Adjunto.almacenarAdjunto(sOrdenId).clonar()
                If msg.EsError Then
                    iOrd.cancelarTransaccion()
                    GoTo finalize
                End If

                msg = iAdj.escribir(Adjunto.OrdenId, Adjunto.instId, Adjunto.Ruta, Adjunto.Coments, Adjunto.extnsion).clonar()
                If msg.EsError Then
                    iOrd.cancelarTransaccion()
                    GoTo finalize
                End If
            Next

            msg = iOrd.actualizarEmbarques(sOrdenId, sEstadoId).clonar()
            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOrd.actualizarVentas(sOrdenId, sEstadoId).clonar()
            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOrd.actualizarAjustes(sOrdenId, sEstadoId).clonar()
            If msg.EsError Then
                iOrd.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOrd.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Orden " + sOrdenId + " actualizada con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function



    Public Sub reiniciar()
        sOrdenId = iOrd.siguienteNo()
        msg = iOrd.Mensaje

        sCtrtoId = ""
        sLoteId = ""
        sOrigenId = ""
        sTnladas = "0"
        sTlrancia = ""
        sPeremb = ""
        sIncoterm = ""
        sRitmo = ""
        sMoneda = ""
        sRefftro = ""
        sBase = "0"
        sMesfutu = "0"
        sPrcionto = "0"
        sObsrv = ""
        sLaycan = ""
        sPtocarga = ""
        sPtodscg = ""
        sNorcg = ""
        sNordscg = ""
        sLaytime = ""
        sCondpgo = ""
        sTasadmra = ""
        sUsrmod = ""
        sUsrcrea = ""
        sFchcrea = ""
        sFchmod = ""
        sEstadoId = ""
        sProvId = ""
        sFchord = ""
        sRspnsble = ""
        sRitmod = ""


        AdjuntosOrden.Clear()
        lAdj = New List(Of AdjuntoOrden)
    End Sub

    Public Sub liberarObjetos()
        sOrdenId = ""
        sCtrtoId = ""
        sLoteId = ""
        sOrigenId = ""
        sTnladas = "0"
        sTlrancia = ""
        sPeremb = ""
        sIncoterm = ""
        sRitmo = ""
        sMoneda = ""
        sRefftro = ""
        sBase = "0"
        sMesfutu = "0"
        sPrcionto = "0"
        sObsrv = ""
        sLaycan = ""
        sPtocarga = ""
        sPtodscg = ""
        sNorcg = ""
        sNordscg = ""
        sLaytime = ""
        sCondpgo = ""
        sTasadmra = ""
        sUsrmod = ""
        sUsrcrea = ""
        sFchcrea = ""
        sFchmod = ""
        sEstadoId = ""
        sProvId = ""
        sFchord = ""
        sRspnsble = ""
        sRitmod = ""
        iOrd = Nothing
        iAdj = Nothing
    End Sub
End Class
Public Class AdjuntoOrden
    Private sOrdenId As String
    Private sArchOrigen As String
    Private sRuta As String
    Private sComents As String
    Private sextnsion As String
    Private sinstId As String

    Public ReadOnly Property OrdenId() As String
        Get
            Return sOrdenId
        End Get
    End Property

    Public ReadOnly Property ArchivoOrigen() As String
        Get
            Return sArchOrigen
        End Get
    End Property

    Public ReadOnly Property Ruta() As String
        Get
            Return sRuta
        End Get
    End Property
    Public ReadOnly Property Coments() As String
        Get
            Return sComents
        End Get
    End Property
    Public ReadOnly Property extnsion() As String
        Get
            Return sextnsion
        End Get
    End Property
    Public ReadOnly Property instId() As String
        Get
            Return sinstId
        End Get
    End Property


    Public Sub New(ByVal pOrdenid As String, ByVal pinstid As Integer, ByVal pArchOrigen As String, _
                   ByVal pRuta As String, ByVal pComents As String, ByVal pExtnsion As String)
        sOrdenId = pOrdenid
        sArchOrigen = pArchOrigen
        sRuta = pRuta

        If pComents Is Nothing Then
            sComents = ""
        Else
            sComents = pComents
        End If

        sextnsion = pExtnsion
        sinstId = pinstid
    End Sub

    Public Function almacenarAdjunto(ByVal pOrdenId As String) As Mensaje
        Dim msg As Mensaje = Nothing

        Try
            msg = New Mensaje()

            If Not File.Exists(sArchOrigen) Then
                Throw New Exception("El archivo origen " + sArchOrigen + " no es válido.")
            Else
                If Not sRuta.Equals(sArchOrigen) Then
                    recalcularDestino(pOrdenId)

                    If Not Directory.Exists(Path.GetDirectoryName(sRuta)) Then
                        Directory.CreateDirectory(Path.GetDirectoryName(sRuta))
                    End If

                    File.Copy(sArchOrigen, sRuta, True)
                End If
            End If

            msg.setInfo("Archivo adjunto " + sArchOrigen + " almacenado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible almacenar el archivo adjunto: " + ex.Message)
        End Try

        Return msg
    End Function

    Private Sub recalcularDestino(ByVal pOrdenId As String)
        If Path.GetDirectoryName(sRuta).Contains("\" + pOrdenId) Then
            sRuta = Path.GetDirectoryName(sRuta) + "\" + Path.GetFileName(sRuta)
        Else
            sRuta = Path.GetDirectoryName(sRuta) + "\" + pOrdenId + "\" + Path.GetFileName(sRuta)
        End If
    End Sub

    Public Sub liberarObjetos()
        sOrdenId = ""
        sRuta = ""
        sComents = ""
        sextnsion = ""
        sinstId = ""
    End Sub

    Public Function clonar() As AdjuntoOrden
        Return New AdjuntoOrden(sOrdenId, sinstId, sArchOrigen, sRuta, sComents, sextnsion)
    End Function
End Class