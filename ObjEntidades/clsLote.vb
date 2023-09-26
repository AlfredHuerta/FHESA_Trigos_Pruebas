Imports Genericas
Imports IfcDatos

Partial Public Class Lote
    Private msg As Mensaje
    Private iLote As iLote

    Private sLoteId As String
    Private sProvId As String
    Private sProveedor As String
    Private sTrigoId As String
    Private sTrigo As String
    Private sProteina As String
    Private sGrado As String
    Private sHumedad As String
    Private sPesohtl As String
    Private sImpureza As String
    Private sDockage As String
    Private sVomitoxn As String
    Private sErgot As String
    Private sFllngnum As String
    Private sObsrv As String
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sEstadoId As String
    Private sFchlote As String
    Private sOtros As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property LoteId() As String
        Get
            Return sLoteId
        End Get
    End Property
    Public ReadOnly Property ProvId() As String
        Get
            Return sProvId
        End Get
    End Property

    Public ReadOnly Property Proveedor() As String
        Get
            Return sProveedor
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

    Public ReadOnly Property Proteina() As String
        Get
            Return sProteina
        End Get
    End Property
    Public ReadOnly Property Grado() As String
        Get
            Return sGrado
        End Get
    End Property
    Public ReadOnly Property Humedad() As String
        Get
            Return sHumedad
        End Get
    End Property
    Public ReadOnly Property Pesohtl() As String
        Get
            Return sPesohtl
        End Get
    End Property
    Public ReadOnly Property Impureza() As String
        Get
            Return sImpureza
        End Get
    End Property
    Public ReadOnly Property Dockage() As String
        Get
            Return sDockage
        End Get
    End Property
    Public ReadOnly Property Vomitoxn() As String
        Get
            Return sVomitoxn
        End Get
    End Property
    Public ReadOnly Property Ergot() As String
        Get
            Return sErgot
        End Get
    End Property
    Public ReadOnly Property Fllngnum() As String
        Get
            Return sFllngnum
        End Get
    End Property
    Public ReadOnly Property Obsrv() As String
        Get
            Return sObsrv
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
    Public ReadOnly Property EstadoId() As String
        Get
            Return sEstadoId
        End Get
    End Property
    Public ReadOnly Property Fchlote() As String
        Get
            Return sFchlote
        End Get
    End Property
    Public ReadOnly Property Otros() As String
        Get
            Return sOtros
        End Get
    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pLoteid As String, ByVal pProvid As String, ByVal pProveedor As String, _
                   ByVal pTrigoid As String, ByVal pTrigo As String, _
                   ByVal pProteina As Decimal, ByVal pGrado As Integer, ByVal pHumedad As Decimal, ByVal pPesohtl As Decimal, _
                   ByVal pImpureza As Decimal, ByVal pDockage As String, ByVal pVomitoxn As String, ByVal pErgot As String, _
                   ByVal pFllngnum As String, ByVal pObsrv As String, ByVal pFchcrea As String, ByVal pUsrcrea As String, _
                   ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pEstadoid As String, ByVal pFchlote As String, _
                   ByVal pOtros As String)
        msg = New Mensaje

        iLote = New iLote(pCliente)

        sLoteId = pLoteid
        sProvId = pProvid
        sProveedor = pProveedor
        sTrigoId = pTrigoid
        sTrigo = pTrigo
        sProteina = pProteina
        sGrado = pGrado
        sHumedad = pHumedad
        sPesohtl = pPesohtl
        sImpureza = pImpureza
        sDockage = pDockage
        sVomitoxn = pVomitoxn
        sErgot = pErgot
        sFllngnum = pFllngnum
        sObsrv = pObsrv
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sEstadoId = pEstadoid
        sFchlote = pFchlote
        sOtros = pOtros

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pLoteid As String)
        msg = New Mensaje
        iLote = New iLote(pCliente)

        buscarLote(pLoteid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iLote = New iLote(pCliente)

        reiniciar()
    End Sub

    Private Function buscarLote(ByVal pLoteid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iLote.leer(pLoteid)
            msg = iLote.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sLoteId = gen3E.valorCampo(resultados, 0, "LoteId")
            sProvId = gen3E.valorCampo(resultados, 0, "ProvId")
            sProveedor = gen3E.valorCampo(resultados, 0, "Proveedor")
            sTrigoId = gen3E.valorCampo(resultados, 0, "TrigoId")
            sTrigo = gen3E.valorCampo(resultados, 0, "Trigo")
            sProteina = gen3E.valorCampo(resultados, 0, "Proteina")
            sGrado = gen3E.valorCampo(resultados, 0, "Grado")
            sHumedad = gen3E.valorCampo(resultados, 0, "Humedad")
            sPesohtl = gen3E.valorCampo(resultados, 0, "Pesohtl")
            sImpureza = gen3E.valorCampo(resultados, 0, "Impureza")
            sDockage = gen3E.valorCampo(resultados, 0, "Dockage")
            sVomitoxn = gen3E.valorCampo(resultados, 0, "Vomitoxn")
            sErgot = gen3E.valorCampo(resultados, 0, "Ergot")
            sFllngnum = gen3E.valorCampo(resultados, 0, "Fllngnum")
            sObsrv = gen3E.valorCampo(resultados, 0, "Obsrv")
            sEstadoId = gen3E.valorCampo(resultados, 0, "EstadoId")
            sFchlote = gen3E.valorCampo(resultados, 0, "Fchlote")
            sOtros = gen3E.valorCampo(resultados, 0, "Otros")


            msg.setInfo("Lote " + pLoteid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Lote desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sLoteId = iLote.siguienteNo().ToString
            msg = iLote.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iLote.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iLote.escribir(sLoteId, sProvId, sTrigoId, sProteina, sGrado, sHumedad, sPesohtl, _
                                 sImpureza, sDockage, sVomitoxn, sErgot, sFllngnum, sObsrv, sFchcrea, sUsrcrea, _
                                 sFchmod, sUsrmod, sEstadoId, sFchlote, sOtros).clonar()

            If msg.EsError Then
                iLote.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iLote.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iLote.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Lote " + sLoteId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function loteAnterior(ByVal pLoteid As String) As String
        Dim lote As String = iLote.loteAnterior(pLoteid)
        If iLote.Mensaje.EsError Then Throw New Exception(iLote.Mensaje.Descripcion)

        Return lote
    End Function

    Public Function loteSiguiente(ByVal pLoteid As String) As String
        Dim lote As String = iLote.loteSiguiente(pLoteid)
        If iLote.Mensaje.EsError Then Throw New Exception(iLote.Mensaje.Descripcion)

        Return lote
    End Function

    Public Function buscarCambios(ByVal pLoteId As String) As DataTable
        Dim resultados As DataTable = iLote.buscarCambios(pLoteId)
        If iLote.Mensaje.EsError Then Throw New Exception(iLote.Mensaje.Descripcion)

        Return resultados
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iLote.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iLote.actualizar(sLoteId, sProvId, sTrigoId, sProteina, sGrado, sHumedad, sPesohtl, _
                                 sImpureza, sDockage, sVomitoxn, sErgot, sFllngnum, sObsrv, sFchcrea, sUsrcrea, _
                                 sFchmod, sUsrmod, sEstadoId, sFchlote, sOtros).clonar()

esError:
            If msg.EsError Then
                iLote.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iLote.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Lote " + sLoteId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sLoteId = iLote.siguienteNo()

        sProvId = ""
        sTrigoId = ""
        sProteina = ""
        sGrado = ""
        sHumedad = ""
        sPesohtl = "0"
        sImpureza = "0"
        sDockage = ""
        sVomitoxn = ""
        sErgot = ""
        sFllngnum = ""
        sObsrv = ""
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sEstadoId = "A"
        sFchlote = ""
        sOtros = ""
    End Sub

    Public Sub liberarObjetos()
        sLoteId = ""
        sProvId = ""
        sTrigoId = ""
        sProteina = ""
        sGrado = ""
        sHumedad = ""
        sPesohtl = "0"
        sImpureza = "0"
        sDockage = ""
        sVomitoxn = ""
        sErgot = ""
        sFllngnum = ""
        sObsrv = ""
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sEstadoId = "A"
        sFchlote = ""
        sOtros = ""

        iLote = Nothing
    End Sub
End Class