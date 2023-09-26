Imports Genericas
Imports IfcDatos

Partial Public Class Proveedor
    Private msg As Mensaje
    Private iProv As iProveedor

    Private sProvId As String
    Private sNombre As String
    Private sCalle As String
    Private sNoext As String
    Private sNoint As String
    Private sColonia As String
    Private sRferenc As String
    Private sLcalidad As String
    Private sMnicipio As String
    Private sEstado As String
    Private sPais As String
    Private sCdgpstl As String
    Private sCntcto As String
    Private sTpoprvId As String
    Private sProvidan As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sCardCode As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property ProvId() As String
        Get
            Return sProvId
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return sNombre
        End Get
    End Property
    Public ReadOnly Property Calle() As String
        Get
            Return sCalle
        End Get
    End Property
    Public ReadOnly Property Noext() As String
        Get
            Return sNoext
        End Get
    End Property
    Public ReadOnly Property Noint() As String
        Get
            Return sNoint
        End Get
    End Property
    Public ReadOnly Property Colonia() As String
        Get
            Return sColonia
        End Get
    End Property
    Public ReadOnly Property Rferenc() As String
        Get
            Return sRferenc
        End Get
    End Property
    Public ReadOnly Property Lcalidad() As String
        Get
            Return sLcalidad
        End Get
    End Property
    Public ReadOnly Property Mnicipio() As String
        Get
            Return sMnicipio
        End Get
    End Property
    Public ReadOnly Property Estado() As String
        Get
            Return sEstado
        End Get
    End Property
    Public ReadOnly Property Pais() As String
        Get
            Return sPais
        End Get
    End Property
    Public ReadOnly Property Cdgpstl() As String
        Get
            Return sCdgpstl
        End Get
    End Property
    Public ReadOnly Property Cntcto() As String
        Get
            Return sCntcto
        End Get
    End Property
    Public ReadOnly Property TpoprvId() As String
        Get
            Return sTpoprvId
        End Get
    End Property
    Public ReadOnly Property Providan() As String
        Get
            Return sProvidan
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
    Public ReadOnly Property CardCode() As String
        Get
            Return sCardCode
        End Get
    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pProvid As String, ByVal pNombre As String, ByVal pCalle As String, _
                   ByVal pNoext As String, ByVal pNoint As String, ByVal pColonia As String, ByVal pRferenc As String, _
                   ByVal pLcalidad As String, ByVal pMnicipio As String, ByVal pEstado As String, ByVal pPais As String, _
                   ByVal pCdgpstl As String, ByVal pCntcto As String, ByVal pTpoprvid As String, ByVal pProvidan As String, _
                   ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, _
                   ByVal pUsrmod As String, ByVal pCardcode As String)
        msg = New Mensaje

        iprov = New iProveedor(pCliente)

        sProvId = pProvid
        sNombre = pNombre
        sCalle = pCalle
        sNoext = pNoext
        sNoint = pNoint
        sColonia = pColonia
        sRferenc = pRferenc
        sLcalidad = pLcalidad
        sMnicipio = pMnicipio
        sEstado = pEstado
        sPais = pPais
        sCdgpstl = pCdgpstl
        sCntcto = pCntcto
        sTpoprvId = pTpoprvid
        sProvidan = pProvidan
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sCardCode = pCardcode

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pProvId As String)
        msg = New Mensaje
        iProv = New iProveedor(pCliente)

        buscarProveedor(pProvId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iProv = New iProveedor(pCliente)

        reiniciar()
    End Sub

    Private Function buscarProveedor(ByVal pProvId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iProv.leer(pProvId)
            msg = iProv.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sProvId = gen3E.valorCampo(resultados, 0, "ProvId")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            sCalle = gen3E.valorCampo(resultados, 0, "Calle")
            sNoext = gen3E.valorCampo(resultados, 0, "Noext")
            sNoint = gen3E.valorCampo(resultados, 0, "Noint")
            sColonia = gen3E.valorCampo(resultados, 0, "Colonia")
            sRferenc = gen3E.valorCampo(resultados, 0, "Rferenc")
            sLcalidad = gen3E.valorCampo(resultados, 0, "Lcalidad")
            sMnicipio = gen3E.valorCampo(resultados, 0, "Mnicipio")
            sEstado = gen3E.valorCampo(resultados, 0, "Estado")
            sPais = gen3E.valorCampo(resultados, 0, "Pais")
            sCdgpstl = gen3E.valorCampo(resultados, 0, "Cdgpstl")
            sCntcto = gen3E.valorCampo(resultados, 0, "Cntcto")
            sTpoprvId = gen3E.valorCampo(resultados, 0, "TpoprvId")
            'sProvidan = gen3E.valorCampo(resultados, 0, "Providan")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            'sCardCode = gen3E.valorCampo(resultados, 0, "CardCode")


            msg.setInfo("Proveedor " + pProvId + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Proveedor desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sProvId = iProv.siguienteNo().ToString
            msg = iProv.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iProv.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iProv.escribir(sProvId, sNombre, sCalle, sNoext, sNoint, sColonia, sRferenc, _
                                 sLcalidad, sMnicipio, sEstado, sPais, sCdgpstl, sCntcto, sTpoprvId, _
                                 sProvidan, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sCardCode).clonar()

            If msg.EsError Then
                iProv.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iProv.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iProv.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Proveedor " + sProvId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function proveedorAnterior(ByVal pProvId As String) As String
        Dim prov As String = iProv.proveedorAnterior(pProvId)
        If iProv.Mensaje.EsError Then Throw New Exception(iProv.Mensaje.Descripcion)

        Return prov
    End Function

    Public Function proveedorSiguiente(ByVal pProvId As String) As String
        Dim prov As String = iProv.proveedorSiguiente(pProvId)
        If iProv.Mensaje.EsError Then Throw New Exception(iProv.Mensaje.Descripcion)

        Return prov
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iProv.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iProv.actualizar(sProvId, sNombre, sCalle, sNoext, sNoint, sColonia, sRferenc, _
                                 sLcalidad, sMnicipio, sEstado, sPais, sCdgpstl, sCntcto, sTpoprvId, _
                                 sProvidan, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sCardCode).clonar()

esError:
            If msg.EsError Then
                iProv.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iProv.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Proveedor " + sProvId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sProvId = iProv.siguienteNo()

        sNombre = ""
        sCalle = ""
        sNoext = ""
        sNoint = ""
        sColonia = ""
        sRferenc = ""
        sLcalidad = ""
        sMnicipio = ""
        sEstado = ""
        sPais = ""
        sCdgpstl = ""
        sCntcto = ""
        sTpoprvId = ""
        sProvidan = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sCardCode = ""

    End Sub

    Public Sub liberarObjetos()
        sProvId = ""
        sNombre = ""
        sCalle = ""
        sNoext = ""
        sNoint = ""
        sColonia = ""
        sRferenc = ""
        sLcalidad = ""
        sMnicipio = ""
        sEstado = ""
        sPais = ""
        sCdgpstl = ""
        sCntcto = ""
        sTpoprvId = ""
        sProvidan = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sCardCode = ""


        iProv = Nothing
    End Sub
End Class