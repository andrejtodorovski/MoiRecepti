using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MoiRecepti.Models
{
    public class Review
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Полето е задолжително")]
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int RecipeID { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}