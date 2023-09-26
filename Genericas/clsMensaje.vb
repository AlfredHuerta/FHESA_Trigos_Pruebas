Imports Genericas.SysEnums
Public Class Mensaje

    Private mTipo As TiposMensaje
    Private sDescripcion As String
    Private bError As Boolean

    Private bErrorMandatorio As Boolean

    Public ReadOnly Property Tipo() As TiposMensaje
        Get
            Return mTipo
        End Get
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return sDescripcion
        End Get
    End Property

    Public ReadOnly Property EsError() As Boolean
        Get
            Return bError
        End Get
    End Property

    Public Sub New(Optional ByVal pDescripcion As String = "", _
                   Optional ByVal pTipo As TiposMensaje = TiposMensaje.mNinguno, _
                   Optional ByVal ErrorMandatorio As Boolean = False)
        mTipo = pTipo
        sDescripcion = pDescripcion

        If pTipo = SysEnums.TiposMensaje.mError Then
            bError = True
        Else
            bError = False
        End If


        bErrorMandatorio = ErrorMandatorio
    End Sub

    Public Sub reset()
        mTipo = TiposMensaje.mNinguno
        sDescripcion = ""
        bError = False
    End Sub

    Public Sub setExclamacion(ByVal pMensaje As String)
        mTipo = TiposMensaje.mExclamacion
        sDescripcion = pMensaje
        bError = False
    End Sub

    Public Sub setInfo(ByVal pMensaje As String)
        mTipo = TiposMensaje.mInformacion
        sDescripcion = pMensaje
        bError = False
    End Sub

    Public Sub setPregunta(ByVal pMensaje As String)
        mTipo = TiposMensaje.mPregunta
        sDescripcion = pMensaje
        bError = False
    End Sub

    Public Sub setAdvertencia(ByVal pMensaje As String)
        mTipo = TiposMensaje.mAdvertencia
        sDescripcion = pMensaje
        bError = bErrorMandatorio
    End Sub

    Public Sub setError(ByVal pMensaje As String)
        mTipo = TiposMensaje.mError
        sDescripcion = pMensaje
        bError = True
    End Sub

    Public Function clonar() As Mensaje
        Return New Mensaje(sDescripcion, mTipo, bErrorMandatorio)
    End Function
End Class
