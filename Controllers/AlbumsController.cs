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

        public IHttpActionResult GetAlbums()
        {
            return Ok(_context.Albums.ToList().Select(Mapper.Map<Album, AlbumDTO>));
        }

        public IHttpActionResult GetAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
                return NotFound();

            return Ok(Mapper.Map<Album, AlbumDTO>(album));
        }

        [HttpPost]
        public IHttpActionResult CreateAlbum(AlbumDTO albumDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var album = Mapper.Map<AlbumDTO, Album>(albumDTO);

            _context.Albums.Add(album);
            _context.SaveChanges();

            albumDTO.Id = album.Id;

            return Created(new Uri(Request.RequestUri + "/" + album.Id), albumDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateAlbum(int id, AlbumDTO albumDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var albumInDB = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (albumInDB == null)
                return NotFound();

            Mapper.Map<AlbumDTO, Album>(albumDto, albumInDB);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAlbum(int id)
        {
            var album = _context.Albums.SingleOrDefault(c => c.Id == id);

            if (album == null)
                return NotFound();

            _context.Albums.Remove(album);

            return Ok();
        }
    }
}
