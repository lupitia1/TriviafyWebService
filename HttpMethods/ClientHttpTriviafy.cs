using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using Newtonsoft.Json;
using Entities;
//using TriviaFy;
//using TriviaFy.JsonModels;

namespace HttpMethods
{

       public class ClientHttpTriviafy : IClientHttpTriviafy
    {
       static HttpClient client = new HttpClient();

        public async Task<AccessToken> GenerateToken()
        {
            ClientCredentials spotifyClient = new ClientCredentials
            {
                ClientID = "8a5cb9ed6fa44409a8379c7dc186c1e7",
                ClientSecret = "6afa8191a22a4e55ac55c60c3db3711b"
            };

            //client.BaseAddress = new Uri("https://accounts.spotify.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string credentials = String.Format("{0}:{1}", spotifyClient.ClientID, spotifyClient.ClientSecret);

            //Define Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };
            FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
            var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
            var response = await request.Content.ReadAsStringAsync();
            Console.WriteLine(response);

            // return the Access Token
            return JsonConvert.DeserializeObject<AccessToken>(response);

        }

        public async Task<PlaylistsReceived> GetPlaylist(String tokenAuth)
        {
            //Define Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAuth);

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
            //requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            //FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
            //var url = "https://api.spotify.com/v1/browse/featured-playlists";

            UriBuilder uriBuilder = new UriBuilder("https://api.spotify.com/v1/browse/featured-playlists");
            UriBuilder builder = uriBuilder;
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["limit"] = "1";
            query["timestamp"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            query["country"] = "ES";

            builder.Query = query.ToString();
            string url = builder.ToString();

            var request = await client.GetAsync(url);
            var response = await request.Content.ReadAsStringAsync();

            // return the received playlist
            return JsonConvert.DeserializeObject<PlaylistsReceived>(response);
        }

        public async Task<TracksInfo> GetPlaylistTracks(String tokenAuth, String playlistID)
        {
            //Define Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAuth);

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
            String urlWithtId = "https://api.spotify.com/v1/playlists/" + playlistID + "/tracks";
            UriBuilder uriBuilder = new UriBuilder(urlWithtId);
            UriBuilder builder = uriBuilder;
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            //query["limit"] = "1";
            query["market"] = "ES";
            query["fields"] = "items(track(name,href, id, uri, album(name,href,images)))";

            builder.Query = query.ToString();
            string url = builder.ToString();

            var request = await client.GetAsync(url);
            var response = await request.Content.ReadAsStringAsync();

            // return the received tracks info
            return JsonConvert.DeserializeObject<TracksInfo>(response);
        }

       /* public async Task<AccessToken> GetSeveralTracks(ClientCredentials spotifyClient)
        {
            string credentials = String.Format("{0}:{1}", spotifyClient.ClientID, spotifyClient.ClientSecret);

            //Define Headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };
            FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
            var request = await client.PostAsync("https://accounts.spotify.com/api/token", requestBody);
            var response = await request.Content.ReadAsStringAsync();
            Console.WriteLine(response);

            // return the Access Token
            return JsonConvert.DeserializeObject<AccessToken>(response);
        }*/

        public List<Track> SelectTracks(TracksInfo o)
        {
            var numberOfTracks = o.items.Count;

            // Crear objeto. Utiliza el reloj del sistema para crear una semilla.
            Random rnd = new Random();
            int randomNumber;
            List<int> tracksRandomNumbers = new List<int>();
            List<Track> listOfSelectedTracks = new List<Track>();

            for (int i = 0; i < 4; i++)
            {

                randomNumber = rnd.Next(numberOfTracks - 1);
                tracksRandomNumbers.Add(randomNumber);
            }
            foreach (int number in tracksRandomNumbers)
            {
                listOfSelectedTracks.Add(o.items[number].track);
            }
            return listOfSelectedTracks;
        }

        






    }
    public class AccessToken
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public long Expires_in { get; set; }
    }

}
