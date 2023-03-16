Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.WebRequestMethods
Imports Newtonsoft.Json.Linq

Public Class clsAPI
    Public Function get_games() As List(Of Dictionary(Of String, String))
        Dim value As New List(Of Dictionary(Of String, String))()
        Dim url As String = "https://rmarchiv.de/api/client/games"
        Dim data As String = get_from_api(url)

        Dim array As JArray = JArray.Parse(data)
        For Each item As JObject In array
            Dim id As String = If(item("id") Is Nothing, "", item("id").ToString())
            Dim title As String = If(item("title") Is Nothing, "", item("title").ToString())
            Dim subtitle As String = If(item("subtitle") Is Nothing, "", item("subtitle").ToString())

            value.Add(New Dictionary(Of String, String)() From {
                      {"id", id},
                      {"title", title},
                      {"subtitle", subtitle}
                     })
        Next

        Return value
    End Function

    Public Function get_screens(ByVal GameID As Integer) As List(Of Dictionary(Of String, String))
        Dim value As New List(Of Dictionary(Of String, String))()
        Dim url As String = "https://rmarchiv.de/api/client/screenshots/" & GameID
        Dim data As String = get_from_api(url)

        Dim array As JArray = JArray.Parse(data)
        For Each item As JObject In array
            Dim id As String = item("id")
            Dim sid As String = item("screenshot_id")
            Dim filename As String = item("filename")

            value.Add(New Dictionary(Of String, String)() From {
                {"id", id},
                {"sid", sid},
                {"filename", filename}
                      })
        Next

        Return value
    End Function

    Private Function get_from_api(ByVal url As String) As String
        Dim httpClient As New HttpClient()
        Dim request As New HttpRequestMessage(HttpMethod.Get, url)
        Dim response = httpClient.Send(request)
        Dim reader As New StreamReader(response.Content.ReadAsStream)
        Dim rawresp = reader.ReadToEnd

        Return rawresp
    End Function
End Class
