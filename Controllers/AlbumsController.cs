using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore.DB;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AlbumsController : ApiController
    {
        private ApplicationDbContext _context;

        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Album> GetAlbums()
        {
            return _context.Albums.ToList();
        }

        public Album GetAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return album;
        }

        [HttpPost]
        public Album CreateAlbum(Album album)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Albums.Add(album);
            _context.SaveChanges();

            return album;
        }

        [HttpPut]
        public void UpdateAlbum(int id, Album album)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var albumInDB = _context.Albums.SingleOrDefault(c => c.Id == id);

            albumInDB.Title = album.Title;
            albumInDB.Genre = album.Genre;
            albumInDB.Label = album.Label;
            albumInDB.Released = album.Released;
            albumInDB.Recorded = album.Recorded;
            albumInDB.Length = album.Length;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Albums.Remove(album);
        }
    }
}
