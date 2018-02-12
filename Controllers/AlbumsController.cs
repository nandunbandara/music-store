using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore.DB;
using MusicStore.Models;
using MusicStore.DTOs;
using AutoMapper;

namespace MusicStore.Controllers
{
    public class AlbumsController : ApiController
    {
        private ApplicationDbContext _context;

        public AlbumsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<AlbumDTO> GetAlbums()
        {
            return _context.Albums.ToList().Select(Mapper.Map<Album, AlbumDTO>);
        }

        public AlbumDTO GetAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Album, AlbumDTO>(album);
        }

        [HttpPost]
        public AlbumDTO CreateAlbum(AlbumDTO albumDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var album = Mapper.Map<AlbumDTO, Album>(albumDTO);

            _context.Albums.Add(album);
            _context.SaveChanges();

            return Mapper.Map<Album, AlbumDTO>(album);
        }

        [HttpPut]
        public void UpdateAlbum(int id, AlbumDTO albumDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var albumInDB = _context.Albums.SingleOrDefault(c => c.Id == id);

            Mapper.Map<AlbumDTO, Album>(albumDto, albumInDB);

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
