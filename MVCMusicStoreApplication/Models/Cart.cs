using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; } //Not unique
        public int AlbumId { get; set; }
        public int Count { get; set; }

        public virtual Album AlbumSelected { get; set; }
        public DateTime DateCreated { get; set; }
    }
}