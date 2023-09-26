Public Class frmVisorEventos
    Public ReadOnly Property PermiteMoverRegistros() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarDocumentos() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteAlterarEstado() As Boolean
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property PermiteImprimir() As Boolean
        Get
            Return False
        End Get
    End Property


    Public ReadOnly Property PermiteBuscarHistorial() As Boolean
        Get
            Return False
        End Get
    End Property

    Private Sub frmVisorEventos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.WindowState = FormWindowState.Normal
        Me.Visible = False
        e.Cancel = True
    End Sub

    Private Sub frmVisorEventos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub
End Class