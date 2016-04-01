Imports System.Collections.ObjectModel
Imports System.Drawing

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

        'For index = 1 To count

        '    Dim theicon As BitmapSource
        '    theicon = SystemIcons.Question.ToImageSource
        '    Games.Add(New GameEntry() With {
        '            .GameIcon = theicon,
        '            .GameName = "Pocket Pool",
        '            .LastSync = index})
        'Next
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim newgame As New editor
        newgame.ShowDialog()
        If newgame.DialogResult.HasValue And newgame.DialogResult.Value Then
            'MessageBox.Show(newgame.exepath)
            Games.Add(New GameEntry() With {
        .GameIcon = newgame.imagesource,
        .GameName = newgame.szGameName,
        .LastSync = 0})
        End If
    End Sub

    Private Sub _Delete_Click(sender As Object, e As RoutedEventArgs)
        'Games = New ObservableCollection(Of GameEntry)()

        Dim selection As GameEntry = _GameList.SelectedItem
        'MessageBox.Show(selection.GameName)
        If _GameList.SelectedItems.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete " + selection.GameName + "?", "Really delete?", MessageBoxButton.YesNo) = vbYes Then
                Games.RemoveAt(_GameList.SelectedIndex)
                DataContext = Me
            End If
        End If

    End Sub
End Class
Public Class GameEntry
    Public Property GameIcon As ImageSource
    Public Property GameName As String
    Public Property LastSync As Integer
End Class
