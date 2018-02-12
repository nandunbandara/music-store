using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public string Genre { get; set; }
        public List<string> Label { get; set; }
        public string Length { get; set; }
        public int Recorded { get; set; }
        public Artist Artist { get; set; }
    }
}