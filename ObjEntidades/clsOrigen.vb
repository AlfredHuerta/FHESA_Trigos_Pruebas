Imports Genericas
Imports IfcDatos

Partial Public Class Origen
    Private msg As Mensaje
    Private iOrig As iOrigen

    Private sOrigenId As String
    Private sNombre As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sOrgnidan As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property OrigenId() As String
        Get
            Return sOrigenId
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
    Public ReadOnly Property Orgnidan() As String
        Get
            Return sOrgnidan
        End Get
    End Property



    Public Sub New(ByVal pCliente As ClienteSql, ByVal pOrigenid As String, ByVal pNombre As String, ByVal pActivo As Integer, ByVal pFchcrea As String, _
                   ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, ByVal pOrgnidan As String)
        msg = New Mensaje

        iOrig = New iOrigen(pCliente)

        sOrigenId = pOrigenid
        sNombre = pNombre
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sOrgnidan = pOrgnidan


    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pOrigenid As String)
        msg = New Mensaje
        iOrig = New iOrigen(pCliente)

        buscarOrigen(pOrigenid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iOrig = New iOrigen(pCliente)

        reiniciar()
    End Sub

    Private Function buscarOrigen(ByVal pOrigenid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iOrig.leer(pOrigenid)
            msg = iOrig.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sOrigenId = gen3E.valorCampo(resultados, 0, "OrigenId")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            'sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            'sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            'sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            'sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sOrgnidan = gen3E.valorCampo(resultados, 0, "Orgnidan")


            msg.setInfo("Origen " + pOrigenid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Origen desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function



    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sOrigenId = iOrig.siguienteNo().ToString
            msg = iOrig.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iOrig.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iOrig.escribir(sOrigenId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sOrgnidan).clonar()

            If msg.EsError Then
                iOrig.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iOrig.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOrig.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Origen " + sOrigenId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function origenAnterior(ByVal pOrigenid As String) As String
        Dim orig As String = iOrig.origenAnterior(pOrigenid)
        If iOrig.Mensaje.EsError Then Throw New Exception(iOrig.Mensaje.Descripcion)

        Return orig
    End Function

    Public Function origenSiguiente(ByVal pOrigenid As String) As String
        Dim orig As String = iOrig.origenSiguiente(pOrigenid)
        If iOrig.Mensaje.EsError Then Throw New Exception(iOrig.Mensaje.Descripcion)

        Return orig
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iOrig.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iOrig.actualizar(sOrigenId, sNombre, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sOrgnidan).clonar()

esError:
            If msg.EsError Then
                iOrig.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iOrig.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Origen " + sOrigenId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub reiniciar()
        sOrigenId = iOrig.siguienteNo()

        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sOrgnidan = ""

    End Sub

    Public Sub liberarObjetos()
        sOrigenId = ""
        sNombre = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sOrgnidan = ""

        iOrig = Nothing
    End Sub
End Class