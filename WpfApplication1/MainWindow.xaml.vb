Imports System.Collections.ObjectModel

Class MainWindow
    Public Property Games As ObservableCollection(Of GameEntry)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitGamesCollection(10)
        DataContext = Me
    End Sub


    Private Sub InitGamesCollection(count As Integer)
        Games = New ObservableCollection(Of GameEntry)()

        For index = 1 To count
            Games.Add(New GameEntry() With {
                    .GameIcon = "Icon",
                    .GameName = "Pocket Pool",
                    .LastSync = index})
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim newgame As New editor
        newgame.ShowDialog()
        If newgame.DialogResult.HasValue And newgame.DialogResult.Value Then
            'MessageBox.Show("pass")
        Else
            'MessageBox.Show("fail")
        End If
    End Sub
End Class
Public Class GameEntry
    Public Property GameIcon As String
    Public Property GameName As String
    Public Property LastSync As Integer
End Class
