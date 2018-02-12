using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MusicStore.Models;
using MusicStore.DTOs;

namespace MusicStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Artist, ArtistDTO>();
            Mapper.CreateMap<Album, AlbumDTO>();
        }
    }
}