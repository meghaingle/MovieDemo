using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieDemoApplication.Models
{
    public class MovieModel
    {

        [Display(Name = "Release Year")]
        public int year { get; set; }
        [Display(Name = "Movie Name")]
        public string title { get; set; }
        public Info info { get; set; }
    }

        public class Info
        {
        [Display(Name = "Directors")]
        public List<string> directors { get; set; }
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime release_date { get; set; }
        [Display(Name = "Rating")]
        public float rating { get; set; }
        [Display(Name = "Genres")]
        public List<string> genres { get; set; }
        [Display(Name = "Image")]
        public string image_url { get; set; }
        [Display(Name = "Plot")]
        public string plot { get; set; }
        [Display(Name = "Rank")]
        public int rank { get; set; }
        [Display(Name = "Running Time in Seconds")]
        public int running_time_secs { get; set; }
        [Display(Name = "Actors")]
        public List<string> actors { get; set; }
        }
    }
