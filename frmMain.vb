Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = wCap()

        'Labels Transparency
        lblTitle.BackColor = Color.Transparent

        Dim data As New clsData
        data.get_games()

        'Fill Games List
        fillGamesList()
    End Sub

    Private Sub fillGamesList()
        Dim data As New clsData
        Dim games As List(Of Dictionary(Of String, String)) = data.get_games

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
        Dim GameID As Integer = Nothing

        For Each itm As ListViewItem In lvGames.SelectedItems
            If itm.Selected Then
                GameID = itm.Text

                Dim data As New clsData
                Dim screens = data.get_screenshots(GameID)

                Dim imgPath As String
                screens(0).TryGetValue("dest", imgPath)
                picBack.Image = Image.FromFile(imgPath)
            End If
        Next

    End Sub

End Class
