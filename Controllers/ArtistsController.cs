using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicStore.Models;
using MusicStore.DB;
using MusicStore.DTOs;
using AutoMapper;

namespace MusicStore.Controllers
{
    public class ArtistsController : ApiController
    {
        private ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetArtists()
        {
            return Ok(_context.Artists.ToList().Select(Mapper.Map<Artist, ArtistDTO>));
        }

        public IHttpActionResult GetArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                return NotFound();

            return Ok(Mapper.Map<Artist, ArtistDTO>(artist));
        }

        [HttpPost]
        public IHttpActionResult AddArtist(ArtistDTO artistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artist = Mapper.Map<ArtistDTO, Artist>(artistDto);

            _context.Artists.Add(artist);
            _context.SaveChanges();

            artistDto.Id = artist.Id;

            return Created(new Uri(Request.RequestUri + "/" + artist.Id), artistDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateArtist(int id, ArtistDTO artistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artistInDb == null)
                return NotFound();

            Mapper.Map<ArtistDTO, Artist>(artistDto, artistInDb);

            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                return NotFound(); ;

            _context.Artists.Remove(artist);

            return Ok();

        }
    }
}
