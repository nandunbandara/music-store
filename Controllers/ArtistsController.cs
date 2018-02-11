using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore.Models;
using MusicStore.DB;

namespace MusicStore.Controllers
{
    public class ArtistsController : ApiController
    {
        private ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _context.Artists.ToList(); 
        }

        public Artist GetArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return artist;
        }

        [HttpPost]
        public Artist AddArtist(Artist artist)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return artist;
        }

        [HttpPut]
        public void UpdateArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

            artistInDb.Name = artist.Name;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Artists.Remove(artist);

        }
    }
}
