using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStoreApplication.Models
{
    [Bind(Exclude = "GenreId")]
    public class Genre
    {
        public virtual int GenreId { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre cannot be blank")]
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }        
    }
}