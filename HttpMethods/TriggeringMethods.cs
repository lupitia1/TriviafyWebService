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
using StructureMap;

namespace HttpMethods
{
    public class TriggeringMethods : ITriggeringMethods
    {
        public Container container;
        List<Track> selectedTracks = new List<Track>();

        public List<Track> Trigger()
        {
          container = new Container(c => { c.AddRegistry<Boostrapper>(); });
            RunAsync().GetAwaiter().GetResult();

            return selectedTracks;
        }

        public async Task RunAsync()
        {
            var service = container.GetInstance<IClientHttpTriviafy>();
            try
            {
                // Get a Token  (OAuth)
                ClientCredentials spotifyClient = new ClientCredentials
                {
                    ClientID = "8a5cb9ed6fa44409a8379c7dc186c1e7",
                    ClientSecret = "6afa8191a22a4e55ac55c60c3db3711b"
                };

                //Get the OAuth Token
                var tokenReceived = await service.GenerateToken();
                var tokenReceivedString = tokenReceived.Access_token;

                //Get a Playlist
                var playlistReceived = await service.GetPlaylist(tokenReceivedString);
                PlaylistSelected playlistSelected = new PlaylistSelected(playlistReceived);

                //Get a Playlist Tracks (And extra info about them)
                var playlistTracksReceived = await service.GetPlaylistTracks(tokenReceivedString, playlistSelected.id);

                //Choose the four tracks to send
                selectedTracks = service.SelectTracks(playlistTracksReceived);
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
