using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieDemoApplication.Models;
using Newtonsoft.Json;

namespace MovieDemoApplication.Controllers.api
{
    public class MoviesController : ApiController
    {
        public List<MovieModel> GetJsonMovieDetails()
        {
            List<MovieModel> movieList = new List<MovieModel>();
            string allText = System.IO.File.ReadAllText(@"E:\moviedata.json");

            if (!String.IsNullOrEmpty(allText))
            {
                movieList = JsonConvert.DeserializeObject<List<MovieModel>>(allText);

            }
            return movieList;
        }

        public IHttpActionResult GetMovieNames()
        {
            List<MovieModel> EmpInfo = GetJsonMovieDetails();

            return Ok(EmpInfo);
        }

      
    }
}
