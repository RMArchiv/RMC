Imports System.Data.SQLite
Imports System.Environment
Public Class clsData
    Public Function get_games() As List(Of Dictionary(Of String, String))
        Dim api As New clsAPI
        Dim games As List(Of Dictionary(Of String, String)) = api.get_games

        Return games
    End Function

    Public Function get_screenshots(ByVal GameID As String) As List(Of Dictionary(Of String, String))
        Dim api As New clsAPI
        Dim screens As List(Of Dictionary(Of String, String)) = api.get_screens(GameID)

        For Each item In screens
            Dim sid As String = Nothing
            item.TryGetValue("sid", sid)

            'https://rmarchiv.de/games/2766/screenshot/show/1/1
            Dim url As String = "https://rmarchiv.de/games/" & GameID & "/screenshot/show/" & sid & "/1"
            Dim dest As String = GetFolderPath(SpecialFolder.ApplicationData) & "\" & Application.ProductName & "\screens\" & GameID & "\" & sid & ".png"

            item.Add("dest", dest)

            If Not IsNothing(url) Then
                If fileExists(dest) = False Then
                    My.Computer.Network.DownloadFile(url, dest, "", "", False, 500, True)
                End If
            End If

        Next

        Return screens
    End Function

    Private Function fileExists(ByVal path As String) As Boolean
        Return My.Computer.FileSystem.FileExists(path)
    End Function
End Class
