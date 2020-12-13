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
        public List<MovieModel> JsonMovieDetails()
        {
            string allText = System.IO.File.ReadAllText(@"E:\moviedata.json");


            var movieList = JsonConvert.DeserializeObject<List<MovieModel>>(allText);


            return movieList;
        }

        public IHttpActionResult GetMovieNames()
        {
            List<MovieModel> EmpInfo = JsonMovieDetails();

            return Ok(EmpInfo);
        }

      
    }
}
