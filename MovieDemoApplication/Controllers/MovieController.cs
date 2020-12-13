using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MovieDemoApplication.Models;
using System.Net.Http;

namespace MovieDemoApplication.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index(string Search_Data, string Filter_Value, int? Page_No)
        {
            IEnumerable<MovieModel> movies = null;
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44329/api/");
                var responseTask = client.GetAsync("movies");

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MovieModel>>();
                    readTask.Wait();

                    ViewBag.FilterValue = Search_Data;
                    movies = readTask.Result;
                    if (!String.IsNullOrEmpty(Search_Data))
                    {
                        movies = movies.Where(s => s.title.ToLower() == Search_Data.ToLower()).OrderByDescending(s => s.year);
                    }
                    else
                    {
                        movies = movies.OrderByDescending(s => s.year);
                    }

                }
                else
                {
                    movies = Enumerable.Empty<MovieModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }
            return View(movies.ToPagedList(No_Of_Page, Size_Of_Page));
        }


        public ActionResult Details(string title)
        {
            ViewBag.title = title;
            IEnumerable<MovieModel> movie = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44329/api/");
                var responseTask = client.GetAsync("movies");


                var result = responseTask.Result;


                if (result.IsSuccessStatusCode)
                {
                   
                    var readTask = result.Content.ReadAsAsync<IList<MovieModel>>();
                    readTask.Wait();

                    movie = readTask.Result;

                    movie = movie.Where(s => s.title.ToLower() == title.ToLower());                   

                }
                else
                {
                    movie = Enumerable.Empty<MovieModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }
            return View(movie);

        }
    }
}