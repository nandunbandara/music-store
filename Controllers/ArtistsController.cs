using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class ArtistsController : ApiController
    {
        public IEnumerable<ArtistModel> GetArtists()
        {
            return null;
        }

        public ArtistModel GetArtist(int id)
        {
            return null;
        }

        [HttpPost]
        public ArtistModel AddArtist(ArtistModel artist)
        {
            return null;
        }

        [HttpPut]
        public void UpdateArtist(int id, ArtistModel artist)
        {

        }

        [HttpDelete]
        public void DeleteArtist(int id)
        {

        }
    }
}
