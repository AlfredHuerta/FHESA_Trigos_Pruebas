Imports System.Reflection
Imports System.IO
Friend Class frmAcercade

    Private Sub frmAcercade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = "Versión: " + My.Application.Info.Version.ToString
        lblFechaCompilacion.Text = "Fecha de Compilación: " + File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToShortDateString

    End Sub

    Private Sub frmAcercade_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim r As New Rectangle(26, 0, 220, 165)
        e.Graphics.DrawImage(My.Resources.log_trig_003, r)
    End Sub
End Class