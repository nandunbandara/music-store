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

        public IEnumerable<ArtistDTO> GetArtists()
        {
            return _context.Artists.ToList().Select(Mapper.Map<Artist, ArtistDTO>);
        }

        public ArtistDTO GetArtist(int id)
        {
            var artist = _context.Artists.SingleOrDefault(c => c.Id == id);

            if (artist == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Artist, ArtistDTO>(artist);
        }

        [HttpPost]
        public ArtistDTO AddArtist(ArtistDTO artistDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var artist = Mapper.Map<ArtistDTO, Artist>(artistDto);

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return Mapper.Map<Artist, ArtistDTO>(artist);
        }

        [HttpPut]
        public void UpdateArtist(int id, ArtistDTO artistDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var artistInDb = _context.Artists.SingleOrDefault(c => c.Id == id);

            Mapper.Map<ArtistDTO, Artist>(artistDto, artistInDb);

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
