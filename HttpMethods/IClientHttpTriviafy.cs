using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpMethods
{
    public interface IClientHttpTriviafy
    {
        Task<AccessToken> GenerateToken();
        Task<PlaylistsReceived> GetPlaylist(String tokenAuth);
        Task<TracksInfo> GetPlaylistTracks(String tokenAuth, String playlistID);
        Task<AccessToken> GetSeveralTracks(ClientCredentials spotifyClient);
        List<Track> SelectTracks(TracksInfo o);
    }
}
