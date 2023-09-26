Imports Genericas
Imports IfcDatos

Partial Public Class Trigo
    Private msg As Mensaje
    Private iTrig As iTrigo

    Private sTrigoId As String
    Private sNombre As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sItemCode As String
    Private sTrgoidan As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property TrigoId() As String
        Get
            Return sTrigoId
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
    Public ReadOnly Property ItemCode() As String
        Get
            Return sItemCode
        End Get
    End Property
    Public ReadOnly Property Trgoidan() As String
        Get
            Return sTrgoidan
        End Get
    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pTrigoid As String, ByVal pNombre As String, _
                   ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, _
                   ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pItemcode As String, _
                   ByVal pTrgoidan As String)
        msg = New Mensaje

        iTrig = New iTrigo(pCliente)

        sTrigoId = pTrigoid
        sNombre = pNombre
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sItemCode = pItemcode
        sTrgoidan = pTrgoidan


    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pTrigoId As String)
        msg = New Mensaje
        iTrig = New iTrigo(pCliente)

        buscarTrigo(pTrigoId)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iTrig = New iTrigo(pCliente)

        reiniciar()
    End Sub

    Private Function buscarTrigo(ByVal pTrigoId As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iTrig.leer(pTrigoId)
            msg = iTrig.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sTrigoId = gen3E.valorCampo(resultados, 0, "TrigoId")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sItemCode = gen3E.valorCampo(resultados, 0, "ItemCode")
            sTrgoidan = gen3E.valorCampo(resultados, 0, "Trgoidan")


            msg.setInfo("Trigo " + pTrigoId + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Trigo desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sTrigoId = iTrig.siguienteNo().ToString
            msg = iTrig.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iTrig.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iTrig.escribir(sTrigoId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sItemCode,
                                 sTrgoidan).clonar()

            If msg.EsError Then
                iTrig.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iTrig.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iTrig.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Trigo " + sTrigoId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function trigoAnterior(ByVal pTrigoId As String) As String
        Dim trig As String = iTrig.trigoAnterior(pTrigoId)
        If iTrig.Mensaje.EsError Then Throw New Exception(iTrig.Mensaje.Descripcion)

        Return trig
    End Function

    Public Function trigoSiguiente(ByVal pTrigoId As String) As String
        Dim trig As String = iTrig.trigoSiguiente(pTrigoId)
        If iTrig.Mensaje.EsError Then Throw New Exception(iTrig.Mensaje.Descripcion)

        Return trig
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iTrig.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iTrig.actualizar(sTrigoId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sItemCode,
                                 sTrgoidan).clonar()

esError:
            If msg.EsError Then
                iTrig.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iTrig.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Trigo " + sTrigoId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sTrigoId = iTrig.siguienteNo()

        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sItemCode = ""
        sTrgoidan = ""

    End Sub

    Public Sub liberarObjetos()
        sTrigoId = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sItemCode = ""
        sTrgoidan = ""

        iTrig = Nothing
    End Sub
End Class