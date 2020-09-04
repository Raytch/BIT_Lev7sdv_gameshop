using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace UWP_customerApp
{
    public static class ServiceClient
    {
        // USED WHEN GENRE-SELECT FORM LOADS TO POPULATE THE DROPDOWN
        internal async static Task<List<string>> GetGenreNamesAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<string>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetGenreNames/"));
        }
        //// USED WHEN CLICK OK IN GENRE SELECT FORM
        internal async static Task<clsGenre> GetGenreAsync(string GenreName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsGenre>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetGenre?GenreName=" + GenreName));
        }

        internal async static Task<List<clsAllGames>> GetGenreGamesAsync(string GenreGenreName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllGames>>
                    (await lcHttpClient.GetStringAsync(
                        "http://localhost:60064/api/shop/GetGenreGames?GenreGenreName=" + GenreGenreName));
        }

        //    internal async static Task<string> InsertGameAsync(clsAllGames prGame)
        //    {
        //        return await InsertOrUpdateAsync(prGame, "http://localhost:60064/api/shop/PostGame", "POST");
        //    }

        //    internal async static Task<string> UpdateGameAsync(clsAllGames prGame)
        //    {
        //        return await InsertOrUpdateAsync(prGame, "http://localhost:60064/api/shop/PutGame", "PUT");
        //    }

        //    private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        //    {
        //        using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
        //        using (lcReqMessage.Content =
        //            new StringContent(JsonConvert.SerializeObject(prItem), /*Encoding.Default*/ Encoding.ASCII, "application/json"))
        //        using (HttpClient lcHttpClient = new HttpClient())
        //        {
        //            HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
        //            return await lcRespMessage.Content.ReadAsStringAsync();
        //        }
        //    }

        //    internal async static Task<string> DeleteGameAsync(clsAllGames prGame)
        //    {
        //        using (HttpClient lcHttpClient = new HttpClient())
        //        {
        //            HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync(
        //                 //$"http://localhost:60064/api/shop/DeleteGame?prGame={prGame}");
        //                 $"http://localhost:60064/api/shop/DeleteGame?GameName={prGame.GameName}&GenreGenreName={prGame.GenreGenreName}");

        //            return await lcRespMessage.Content.ReadAsStringAsync();
        //        }

        //        //throw new NotImplementedException();
        //    }

        //    //api/controller/MethodName?ParameterName=what you want in the parameter.
    }
}
