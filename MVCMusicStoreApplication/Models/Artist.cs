using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    [Bind(Exclude = "ArtistId")]
    public class Artist
    {
        public virtual int ArtistId { get; set; }

        [Display(Name = "Artist")]
        public virtual string Name { get; set; }
    }
}