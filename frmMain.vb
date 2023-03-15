Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = wCap()

        'Fill Games List
        fillGamesList()
    End Sub

    Private Sub fillGamesList()
        Dim api As New clsAPI
        Dim games As List(Of Dictionary(Of String, String)) = api.get_games
        With lvGames
            .View = View.Details
            .GridLines = True
            .Columns.Clear()
            .Columns.Add("Id", 0)
            .Columns.Add("Titel", 120)
            .Columns.Add("Untertitel", 120)
            .Items.Clear()
        End With


        For Each game In games
            Dim id As String = Nothing
            Dim title As String = Nothing
            Dim subtitle As String = Nothing

            game.TryGetValue("id", id)
            game.TryGetValue("title", title)
            game.TryGetValue("subtitle", subtitle)

            Dim lvi As New ListViewItem
            lvi.Text = id
            lvi.SubItems.Add(title)
            lvi.SubItems.Add(subtitle)

            lvGames.Items.Add(lvi)
        Next

    End Sub

    Private Sub lvGames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvGames.SelectedIndexChanged
        Try
            MessageBox.Show("ID ist: " & lvGames.SelectedItems(0).Text)
        Catch ex As Exception

        End Try

    End Sub
End Class
