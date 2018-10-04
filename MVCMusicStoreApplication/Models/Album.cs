using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }

        [Display(Name = "Album Title")]
        [Required(ErrorMessage = "Album Title cannot be blank")]
        public virtual string Title { get; set; }

        [Display(Name = "Album Price")]
        [Required]
        [Range(0.01,100.00,ErrorMessage ="Album price must be between $0.01 and $100.00")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public virtual decimal Price { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        [Display(Name = "Album Art Url")]
        public virtual string AlbumArtUrl {get;set;}

        [Display(Name = "Additional Information")]
        public virtual string AdditionalInfo { get; set; }

        [Display(Name = "Country Of Origin")]
        public virtual string CountryOfOrigin { get; set; }

        [Display(Name = "In Stock")]
        public virtual bool InStock { get; set; }
    }
}