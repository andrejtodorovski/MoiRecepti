using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MoiRecepti.Models
{
    public class HomePageView
    {
        public List<Recipe> TopRated { get; set; }
        public List<Recipe> MostVisited { get; set; }
        public List<Recipe> Newest { get; set; }
    }
}