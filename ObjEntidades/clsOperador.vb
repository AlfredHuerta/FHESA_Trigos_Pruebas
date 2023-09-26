Imports Genericas
Imports IfcDatos

Partial Public Class Operador
    Private msg As Mensaje
    Private iOp As iOperador

    Private sOprdorId As String
    Private sNkname As String
    Private sNombre As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sUsridan As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property OprdorId() As String
        Get
            Return sOprdorId
        End Get
    End Property
    Public ReadOnly Property Nkname() As String
        Get
            Return sNkname
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
    Public ReadOnly Property Usridan() As String
        Get
            Return sUsridan
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pOprdorid As String, ByVal pNkname As String, ByVal pNombre As String, _
                   ByVal pActivo As Integer, ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, _
                   ByVal pUsrmod As String, ByVal pUsridan As String)
        msg = New Mensaje

        iOp = New iOperador(pCliente)

        sOprdorId = pOprdorid
        sNkname = pNkname
        sNombre = pNombre
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sUsridan = pUsridan

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pOprdorid As String)
        msg = New Mensaje
        iOp = New iOperador(pCliente)

        buscarOperador(pOprdorid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iOp = New iOperador(pCliente)

        reiniciar()
    End Sub

    Private Function buscarOperador(ByVal pOprdorid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iOp.leer(pOprdorid)
            msg = iOp.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sOprdorId = gen3E.valorCampo(resultados, 0, "OprdorId")
            sNkname = gen3E.valorCampo(resultados, 0, "Nkname")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sUsridan = gen3E.valorCampo(resultados, 0, "Usridan")


            msg.setInfo("Operador " + pOprdorid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Operador desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function


    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sOprdorId = iOp.siguienteNo().ToString
            msg = iOp.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iOp.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iOp.escribir(sOprdorId, sNkname, sNombre, bActivo, sFchcrea, Usrcrea, sFchmod, sUsrmod, _
                               sUsridan).clonar()

            If msg.EsError Then
                iOp.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iOp.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOp.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Operador " + sOprdorId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function operadorAnterior(ByVal pOpradorId As String) As String
        Dim op As String = iOp.operadorAnterior(pOpradorId)
        If iOp.Mensaje.EsError Then Throw New Exception(iOp.Mensaje.Descripcion)

        Return op
    End Function

    Public Function operadorSiguiente(ByVal pOpradorId As String) As String
        Dim op As String = iOp.operadorSiguiente(pOpradorId)
        If iOp.Mensaje.EsError Then Throw New Exception(iOp.Mensaje.Descripcion)

        Return op
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iOp.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iOp.actualizar(sOprdorId, sNkname, sNombre, bActivo, sFchcrea, Usrcrea, sFchmod, sUsrmod, _
                               sUsridan).clonar()

esError:
            If msg.EsError Then
                iOp.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOp.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Operador " + sOprdorId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sOprdorId = iOp.siguienteNo()

        sNkname = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sUsridan = ""

    End Sub

    Public Sub liberarObjetos()
        sOprdorId = ""
        sNkname = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sUsridan = ""

        iOp = Nothing
    End Sub
End Class
