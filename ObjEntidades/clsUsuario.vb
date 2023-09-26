Imports Genericas
Imports IfcDatos

Partial Public Class Usuario
    Private msg As Mensaje
    Private iUs As clsiUsuario

    Private sUsrId As String
    Private sNkname As String
    Private sNombre As String
    Private sApllidop As String
    Private sApllidom As String
    Private sCntrsnia As String
    Private sPerfilId As String
    Private sPuestoId As String
    Private sLtimoacc As String
    Private sCorreoe As String
    Private sCntrscoe As String
    Private sSmtpId As String
    Private bActivo As Boolean
    Private sFchcrea As String
    Private sUsrcrea As String
    Private sFchmod As String
    Private sUsrmod As String
    Private sUsridan As String
    Private sOprdorId As String

    Private Perf As Perfil
    Private bCierreSesion As Boolean

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property UsrId() As String
        Get
            Return sUsrId
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
    Public ReadOnly Property Apllidop() As String
        Get
            Return sApllidop
        End Get
    End Property
    Public ReadOnly Property Apllidom() As String
        Get
            Return sApllidom
        End Get
    End Property
    Public ReadOnly Property Cntrsnia() As String
        Get
            Return sCntrsnia
        End Get
    End Property
    Public ReadOnly Property PerfilId() As String
        Get
            Return sPerfilId
        End Get
    End Property
    Public ReadOnly Property PuestoId() As String
        Get
            Return sPuestoId
        End Get
    End Property
    Public ReadOnly Property Ltimoacc() As String
        Get
            Return sLtimoacc
        End Get
    End Property
    Public ReadOnly Property Correoe() As String
        Get
            Return sCorreoe
        End Get
    End Property
    Public ReadOnly Property Cntrscoe() As String
        Get
            Return sCntrscoe
        End Get
    End Property
    Public ReadOnly Property SmtpId() As String
        Get
            Return sSmtpId
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
    Public ReadOnly Property OprdorId() As String
        Get
            Return sOprdorId
        End Get
    End Property

    Public ReadOnly Property Perfil() As Perfil
        Get
            Return Perf
        End Get
    End Property

    Public ReadOnly Property CerrandoSesion() As Boolean
        Get
            Return bCierreSesion
        End Get
    End Property

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pUsrid As String, ByVal pNkname As String, ByVal pNombre As String, _
                   ByVal pApllidop As String, ByVal pApllidom As String, ByVal pCntrsnia As String, ByVal pPerfilid As String, _
                   ByVal pPuestoid As String, ByVal pLtimoacc As String, ByVal pCorreoe As String, _
                   ByVal pCntrscoe As String, ByVal pSmtpid As String, ByVal pActivo As Integer, _
                   ByVal pFchcrea As String, ByVal pUsrcrea As String, ByVal pFchmod As String, ByVal pUsrmod As String, _
                   ByVal pUsridan As String, ByVal pOprdorId As String)
        msg = New Mensaje

        iUs = New clsiUsuario(pCliente)

        sUsrId = pUsrid
        sNkname = pNkname
        sNombre = pNombre
        sApllidop = pApllidop
        sApllidom = pApllidom
        sCntrsnia = pCntrsnia
        sPerfilId = pPerfilid
        sPuestoId = pPuestoid
        sLtimoacc = pLtimoacc
        sCorreoe = pCorreoe
        sCntrscoe = pCntrscoe
        sSmtpId = pSmtpid
        bActivo = pActivo
        sFchcrea = pFchcrea
        sUsrcrea = pUsrcrea
        sFchmod = pFchmod
        sUsrmod = pUsrmod
        sUsridan = pUsridan
        sOprdorId = pOprdorId

    End Sub

    Public Sub New(ByVal pCliente As ClienteSql, ByVal pUsrid As String)
        msg = New Mensaje
        iUs = New clsiUsuario(pCliente)

        buscarUsuario(pUsrid)
    End Sub

    Public Sub New(ByVal pCliente As ClienteSql)
        msg = New Mensaje
        iUs = New clsiUsuario(pCliente)

        reiniciar()
    End Sub

    Private Function buscarUsuario(ByVal pUsrid As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing

        Dim itmCounter As Integer = 0

        Try
            resultados = iUs.leer(pUsrid)
            msg = iUs.Mensaje.clonar()
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E

            sUsrId = gen3E.valorCampo(resultados, 0, "UsrId")
            sNkname = gen3E.valorCampo(resultados, 0, "Nkname")
            sNombre = gen3E.valorCampo(resultados, 0, "Nombre")
            sApllidop = gen3E.valorCampo(resultados, 0, "Apllidop")
            sApllidom = gen3E.valorCampo(resultados, 0, "Apllidom")
            sCntrsnia = gen3E.valorCampo(resultados, 0, "Cntrsnia")
            sPerfilId = gen3E.valorCampo(resultados, 0, "PerfilId")
            sPuestoId = gen3E.valorCampo(resultados, 0, "PuestoId")
            sLtimoacc = gen3E.valorCampo(resultados, 0, "Ltimoacc")
            sCorreoe = gen3E.valorCampo(resultados, 0, "Correoe")
            sCntrscoe = gen3E.valorCampo(resultados, 0, "Cntrscoe")
            sSmtpId = gen3E.valorCampo(resultados, 0, "SmtpId")
            bActivo = Boolean.Parse(gen3E.valorCampo(resultados, 0, "Activo", "false"))
            sFchcrea = gen3E.valorCampo(resultados, 0, "Fchcrea")
            sUsrcrea = gen3E.valorCampo(resultados, 0, "Usrcrea")
            sFchmod = gen3E.valorCampo(resultados, 0, "Fchmod")
            sUsrmod = gen3E.valorCampo(resultados, 0, "Usrmod")
            sUsridan = gen3E.valorCampo(resultados, 0, "Usridan")
            sOprdorId = gen3E.valorCampo(resultados, 0, "OprdorId")


            msg.setInfo("Usuario " + pUsrid + " buscado y encontrado desde su origen de datos.")
        Catch ex As Exception
            msg.setError("No fue posible cargar el Usuario desde su origen de datos: " + ex.Message)
        End Try

finalize:
        If msg.EsError Then Throw New Exception(msg.Descripcion)
        Return msg
    End Function


    Public Function guardar() As Mensaje
        Dim itmCounter As Integer = 0
        Dim resultados As DataTable = Nothing

        Try
            sOprdorId = iUs.siguienteNo().ToString
            msg = iUs.Mensaje
            If msg.EsError Then GoTo finalize


            msg = iUs.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iUs.escribir(sUsrId, sNkname, sNombre, sApllidop, sApllidom, sCntrsnia, sPerfilId, sPuestoId, sLtimoacc, sCorreoe, _
                               sCntrscoe, sSmtpId, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sUsridan, sOprdorId).clonar()

            If msg.EsError Then
                iUs.cancelarTransaccion()
                GoTo finalize
            End If


esError:
            If msg.EsError Then
                iUs.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iUs.terminarTransaccion()

            If Not msg.EsError Then msg.setExclamacion("Usuario " + sUsrId + " creado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible guardar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function usuarioAnterior(ByVal pUsrid As String) As String
        Dim us As String = iUs.usuarioAnterior(pUsrid)
        If iUs.Mensaje.EsError Then Throw New Exception(iUs.Mensaje.Descripcion)

        Return us
    End Function

    Public Function usuarioSiguiente(ByVal pUsrid As String) As String
        Dim us As String = iUs.usuarioSiguiente(pUsrid)
        If iUs.Mensaje.EsError Then Throw New Exception(iUs.Mensaje.Descripcion)

        Return us
    End Function

    Public Function actualizar() As Mensaje
        Dim itmCounter As Integer = 0

        Try
            msg = iUs.iniciarTransaccion(IsolationLevel.Serializable)
            If msg.EsError Then GoTo finalize

            msg = iUs.actualizar(sUsrId, sNkname, sNombre, sApllidop, sApllidom, sCntrsnia, sPerfilId, sPuestoId, sLtimoacc, sCorreoe, _
                               sCntrscoe, sSmtpId, bActivo, sFchcrea, sUsrcrea, sFchmod, sUsrmod, sUsridan, sOprdorId).clonar()

esError:
            If msg.EsError Then
                iUs.cancelarTransaccion()
                GoTo finalize
            End If

            msg = iUs.terminarTransaccion()

            If Not msg.EsError Then msg.setInfo("Usuario " + sUsrId + " actualizado con éxito.")
        Catch ex As Exception
            msg.setError("No fue posible actualizar el documento: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function cargarPorSesion(ByVal pCliente As ClienteSql, _
                                    ByVal pNkname As String, ByVal pCntrsnia As String) As Mensaje
        Dim resultados As DataTable = Nothing
        Dim gen3E As Genericas3E = Nothing
        Dim cripto As Criptografo = Nothing
        Dim sesion As Sesion = Nothing

        Try
            msg.reset()

            resultados = iUs.buscarPorNikname(pNkname)
            msg = iUs.Mensaje.clonar
            If msg.EsError Then GoTo finalize

            gen3E = New Genericas3E
            cripto = New Criptografo

            sUsrId = gen3E.valorCampo(resultados, 0, "UsrId")
            sCntrsnia = cripto.Desencriptar(gen3E.valorCampo(resultados, 0, "Cntrsnia"), "tNlTrg")

            If Not pCntrsnia.Equals(sCntrsnia) Then
                msg.setError("La contraseña de usuario no es correcta.")
                GoTo finalize
            End If

            buscarUsuario(sUsrId)

            Perf = New Perfil(pCliente, sPerfilId)
            msg = Perf.Mensaje.clonar()

            If Not msg.EsError Then
                msg = iUs.registrarAcceso(sUsrId).clonar()

                sesion = New Sesion(pCliente, "0", sUsrId, "", "-1", 1)
                msg = sesion.guardar().clonar()

                sesion.liberarObjetos()

                If Not msg.EsError Then
                    msg.setInfo("Bienvenido, " + sNombre + " " + sApllidop + " " + sApllidom + " (Última conexión el " + sLtimoacc + ").")
                Else
                    msg.setAdvertencia(msg.Descripcion)
                End If
            End If

        Catch ex As Exception
            msg.setError("No fue posible recuperar el usuario: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function cambiarContrasenia(ByVal pContraseniaAnterior As String, _
                                        ByVal pNuevaContrasenia As String, ByVal pConfirmarContrasenia As String) As Mensaje
        Dim cripto As Criptografo = Nothing

        Try
            msg.reset()

            cripto = New Criptografo

            If Not cripto.Desencriptar(Cntrsnia, "tNlTrg").Equals(pContraseniaAnterior) Then
                msg.setError("La contraseña anterior es incorrecta.")
            ElseIf pNuevaContrasenia.Trim.Equals("") Then
                msg.setError("La nueva contraseña no puede estar vacía.")
            ElseIf Not pNuevaContrasenia.Equals(pConfirmarContrasenia) Then
                msg.setError("La nueva contraseña y su confirmación no coinciden.")
            Else
                sCntrsnia = cripto.Encriptar(pNuevaContrasenia, "tNlTrg")
                sFchcrea = Format(Date.Parse(sFchcrea), "yyyy-MM-ddTHH:mm:dd")
                sFchmod = Format(Date.Parse(sFchmod), "yyyy-MM-ddTHH:mm:dd")
                sLtimoacc = Format(Date.Parse(sLtimoacc), "yyyy-MM-ddTHH:mm:dd")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cambiar el valor de la contraseña: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Function validarContrasenia(ByVal pContrasenia As String) As Mensaje
        Dim cripto As Criptografo = Nothing

        Try
            msg.reset()

            cripto = New Criptografo

            If Not cripto.Desencriptar(Cntrsnia, "tNlTrg").Equals(pContrasenia) Then
                msg.setError("La contraseña es incorrecta.")
            End If
        Catch ex As Exception
            msg.setError("No fue posible cambiar el valor de la contraseña: " + ex.Message)
        End Try

finalize:
        Return msg
    End Function

    Public Sub abrirSesion()
        bCierreSesion = True
    End Sub

    Public Sub cerrarSesion()
        bCierreSesion = True
    End Sub
    Public Sub reiniciar()
        sUsrId = iUs.siguienteNo()

        sNkname = ""
        sNombre = ""
        sApllidop = ""
        sApllidom = ""
        sCntrsnia = ""
        sPerfilId = ""
        sPuestoId = ""
        sLtimoacc = ""
        sCorreoe = ""
        sCntrscoe = ""
        sSmtpId = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sUsridan = ""
        sOprdorId = ""
        bCierreSesion = False
    End Sub

    Public Sub liberarObjetos()
        sUsrId = ""
        sNkname = ""
        sNombre = ""
        sApllidop = ""
        sApllidom = ""
        sCntrsnia = ""
        sPerfilId = ""
        sPuestoId = ""
        sLtimoacc = ""
        sCorreoe = ""
        sCntrscoe = ""
        sSmtpId = ""
        bActivo = "0"
        sFchcrea = ""
        sUsrcrea = ""
        sFchmod = ""
        sUsrmod = ""
        sUsridan = ""
        sOprdorId = ""
        bCierreSesion = False

        iUs = Nothing
    End Sub
End Class
