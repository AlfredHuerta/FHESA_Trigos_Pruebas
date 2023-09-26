Public Class ParametrosConexion
    Private msg As Mensaje

    Private sUsuariosSap As String
    Private sContraseniaSap As String
    Private sServLicencias As String
    Private sPuertoServLicencias As String
    Private iTipoServBd As Integer
    Private sIdentifAddon As String

    Private sServidorBd As String
    Private sBaseDeDatos As String
    Private sUsuarioBd As String
    Private sConstraseniaBd As String
    Private iTiempoEsperaBd As Integer

    Private sIdModulo As String
    Private sLicenciaModulo As String

    Public ReadOnly Property Mensaje() As Mensaje
        Get
            Return msg
        End Get
    End Property

    Public Property UsuarioSap() As String
        Get
            Return sUsuariosSap
        End Get
        Set(svalue As String)
            sUsuariosSap = svalue
        End Set
    End Property

    Public Property ContraseniaSap() As String
        Get
            Return sContraseniaSap
        End Get
        Set(svalue As String)
            sContraseniaSap = svalue
        End Set
    End Property

    Public Property ServLicencias() As String
        Get
            Return sServLicencias
        End Get
        Set(svalue As String)
            sServLicencias = svalue
        End Set
    End Property

    Public Property PuertoServLicencias() As String
        Get
            Return sPuertoServLicencias
        End Get
        Set(svalue As String)
            sPuertoServLicencias = svalue
        End Set
    End Property

    Public Property TipoServBd() As Integer
        Get
            Return iTipoServBd
        End Get
        Set(ivalue As Integer)
            iTipoServBd = ivalue
        End Set
    End Property

    Public Property IdentificadorAddon() As String
        Get
            Return sIdentifAddon
        End Get
        Set(svalue As String)
            sIdentifAddon = svalue
        End Set
    End Property

    Public Property ServidorBd() As String
        Get
            Return sServidorBd
        End Get
        Set(ByVal sValue As String)
            sServidorBd = sValue
        End Set
    End Property

    Public Property BaseDeDatos() As String
        Get
            Return sBaseDeDatos
        End Get
        Set(ByVal sValue As String)
            sBaseDeDatos = sValue
        End Set
    End Property

    Public Property UsuarioBd() As String
        Get
            Return sUsuarioBd
        End Get
        Set(ByVal sValue As String)
            sUsuarioBd = sValue
        End Set
    End Property

    Public Property ContraseniaBd() As String
        Get
            Return sConstraseniaBd
        End Get
        Set(ByVal sValue As String)
            sConstraseniaBd = sValue
        End Set
    End Property

    Public Property TiempoEsperaBd() As Integer
        Get
            Return iTiempoEsperaBd
        End Get
        Set(ivalue As Integer)
            iTiempoEsperaBd = ivalue
        End Set
    End Property

    Public ReadOnly Property IdModulo() As String
        Get
            Return sIdModulo
        End Get
    End Property

    Public ReadOnly Property LicenciaModulo() As String
        Get
            Return sLicenciaModulo
        End Get
    End Property
    Public Sub New(ByVal pServidorBd As String, ByVal pBaseDeDatos As String, ByVal pUsuarioBdName As String, ByVal pUsuarioBdPWD As String, _
                   ByVal pTimeOut As Integer, ByVal pUsuarioSap As String, ByVal pContraseniaSap As String, ByVal pServLicencias As String, _
                   ByVal pPuertoServLicencias As String, ByVal pTipoServBd As Integer, ByVal pAddonIdentifier As String, _
                   ByVal pIdModulo As String, ByVal pLicenciaModulo As String)
        msg = New Mensaje

        sServidorBd = pServidorBd
        sBaseDeDatos = pBaseDeDatos
        sUsuarioBd = pUsuarioBdName
        sConstraseniaBd = pUsuarioBdPWD
        iTiempoEsperaBd = pTimeOut

        sUsuariosSap = pUsuarioSap
        sContraseniaSap = pContraseniaSap
        sServLicencias = pServLicencias
        sPuertoServLicencias = pPuertoServLicencias
        iTipoServBd = pTipoServBd
        sIdentifAddon = pAddonIdentifier

        sIdModulo = pIdModulo
        sLicenciaModulo = pLicenciaModulo
    End Sub

    Public Function clonar() As ParametrosConexion
        Return New ParametrosConexion(sServidorBd, sBaseDeDatos, sUsuarioBd, sConstraseniaBd, iTiempoEsperaBd, sUsuariosSap, _
                                      sContraseniaSap, sServLicencias, sPuertoServLicencias, iTipoServBd, sIdentifAddon, _
                                      sIdModulo, sLicenciaModulo)
    End Function

    Public Function validarLicencia() As Mensaje
        Dim cripto As Criptografo = New Criptografo

        Try
            If sBaseDeDatos.Equals(cripto.Desencriptar(sLicenciaModulo, sIdModulo + sBaseDeDatos)) Then
                msg.setInfo("Ok, el módulo se encuentra correctamente activado en la sociedad " + sBaseDeDatos + ".")
            Else
                msg.setError("La licencia del módulo en la sociedad no es correcta. No se ejecutarán funciones con el módulo en la sociedad " + sBaseDeDatos + ".")
            End If
        Catch ex As Exception
            msg.setError("Ocurrió un error al validar la licencia del módulo en la sociedad actual: " + ex.Message)
        End Try

        Return msg
    End Function

End Class