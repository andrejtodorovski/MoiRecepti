using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MoiRecepti.Models
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        [DataType(DataType.MultilineText)]
        public string Sostojki { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        [DataType(DataType.MultilineText)]
        public string Alergeni { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        [DataType(DataType.MultilineText)]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public string Vid { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public string NivoNaTezina { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public int ZaKolkuLica { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public int VremePodgotovka { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public string Slika { get; set; }
        public string UserEmail { get; set; }
        public List<Review> Reviews { get; set; }
        public float AverageRating { get; set; }
        public int TotalViews { get; set; }
        public DateTime TimeCreated { get; set; }

    }
}