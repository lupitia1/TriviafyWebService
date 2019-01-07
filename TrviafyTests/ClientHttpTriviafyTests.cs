using Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviafyTests
{
    class ClientHttpTriviafyTests : TestBase
    {
        [Test]
        public async Task CanGetOAuthAsync() {

            var service = container.GetInstance<HttpMethods.IClientHttpTriviafy>();
            var token = await service.GenerateToken();

                        
            Assert.AreNotEqual("",token.Access_token);
        }

        [Test]
        public async Task CanGetPlaylist()
        {

            var service = container.GetInstance<HttpMethods.IClientHttpTriviafy>();
            var token = await service.GenerateToken();
            var playlist = await service.GetPlaylist(token.Access_token);

            Assert.AreEqual(1, playlist.playlists.items.Count);
        }

        [Test]
        public async Task CanGetAPlaylistTracks()
        {

            var service = container.GetInstance<HttpMethods.IClientHttpTriviafy>();
            var token = await service.GenerateToken();
            var playlistID = await service.GetPlaylist(token.Access_token);
            var playlistTracks = await service.GetPlaylistTracks(token.Access_token, playlistID.playlists.items[0].id);

            Assert.AreNotEqual(0, playlistTracks.items.Count);
        }
    }
}
