using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAdmin
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

        internal async static Task<clsAllGames> GetGameAsync(string Code)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<clsAllGames>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetGame?Code=" + Code));
        }

        internal async static Task<List<clsOrders>> GetOrdersAsync()
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsOrders>>
                    (await lcHttpClient.GetStringAsync("http://localhost:60064/api/shop/GetOrders"));

            //throw new NotImplementedException();
        }

        internal async static Task<List<clsAllGames>> GetGenreGamesAsync(string GenreGenreName)
        {
            using (HttpClient lcHttpClient = new HttpClient())
                return JsonConvert.DeserializeObject<List<clsAllGames>>
                    (await lcHttpClient.GetStringAsync(
                        "http://localhost:60064/api/shop/GetGenreGames?GenreGenreName=" + GenreGenreName));
        }

        internal async static Task<string> InsertGameAsync(clsAllGames prGame)
        {
            return await InsertOrUpdateAsync(prGame, "http://localhost:60064/api/shop/PostGame", "POST");
        }

        internal async static Task<string> UpdateGameAsync(clsAllGames prGame)
        {
            return await InsertOrUpdateAsync(prGame, "http://localhost:60064/api/shop/PutGame", "PUT");
        }
        internal async static Task<string> UpdateOrderAsync(clsOrders prOrder)
        {
            return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/shop/PutOrder", "PUT");
        }

        private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
        {
            using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
            using (lcReqMessage.Content =
                new StringContent(JsonConvert.SerializeObject(prItem), Encoding.Default, "application/json"))
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> DeleteGameAsync(int prGameID)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync(
                     $"http://localhost:60064/api/shop/DeleteGame?GameID={prGameID}");

                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }

        internal async static Task<string> DeleteOrderAsync(int prOrderNo)
        {
            using (HttpClient lcHttpClient = new HttpClient())
            {
                HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync(
                     $"http://localhost:60064/api/shop/DeleteOrder?OrderNo={prOrderNo}");
                return await lcRespMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
