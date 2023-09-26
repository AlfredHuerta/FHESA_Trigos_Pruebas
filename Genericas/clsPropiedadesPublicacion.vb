Imports System.Windows.Forms
Public Class PropiedadesPublicacion
    Private chkGuardarReg As CheckBox
    Private tstEstado As ToolStripStatusLabel
    Private tbcVisor As TabControl

    Public ReadOnly Property VisorBases() As TabControl
        Get
            Return tbcVisor
        End Get
    End Property

    Public ReadOnly Property GuardarRegistro() As CheckBox
        Get
            Return chkGuardarReg
        End Get
    End Property

    Public ReadOnly Property Estado() As ToolStripStatusLabel
        Get
            Return tstEstado
        End Get
    End Property

    Public Sub New(ByVal ptbcVisor As TabControl, ByVal pchkGuardarReg As CheckBox, _
                   ByVal pEtBarraEstado As ToolStripStatusLabel)
        tbcVisor = ptbcVisor
        chkGuardarReg = pchkGuardarReg
        tstEstado = pEtBarraEstado
    End Sub

    Public Sub reset()

    End Sub
End Class
