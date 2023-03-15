Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class clsAPI
    Public Function get_games() As List(Of Dictionary(Of String, String))
        Dim value As New List(Of Dictionary(Of String, String))()

        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader

        request = DirectCast(WebRequest.Create("https://rmarchiv.de/api/client/games"), HttpWebRequest)

        response = DirectCast(request.GetResponse(), HttpWebResponse)
        reader = New StreamReader(response.GetResponseStream())

        Dim rawresp As String
        rawresp = reader.ReadToEnd()

        Dim array As JArray = JArray.Parse(rawresp)
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
End Class
