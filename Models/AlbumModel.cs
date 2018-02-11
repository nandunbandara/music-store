using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class AlbumModel
    {
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public string genre { get; set; }
        public List<string> label { get; set; }
        public string length { get; set; }
        public int recorded { get; set; }
        public ArtistModel Artist { get; set; }
    }
}