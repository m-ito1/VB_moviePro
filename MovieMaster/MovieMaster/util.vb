Public Class util
    Public Sub forwardScreen(original As Form, target As Form)
        Dim inputViewer As New inputViewer
        target.Show()
        My.Application.ApplicationContext.MainForm = target
        original.Dispose()
    End Sub
End Class
