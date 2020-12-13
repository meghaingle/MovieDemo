using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDemoApplication.Controllers;
using System.Web.Mvc;

namespace MovieDemoApplicationTest
{
    [TestClass]
    public class MovieControllerTest
    {
        [TestMethod]
        public void IndexView()
        {
            string Search_Data = "Avatar";
            string Filter_Value = "Avatar";
            int? Page_No = 1;
            MovieController movieController = new MovieController();
            // Act
            ViewResult result = movieController.Index(Search_Data, Filter_Value, Page_No) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsView()
        {
            string Search_Data = "Avatar";
           
            MovieController movieController = new MovieController();
            // Act
            ViewResult result = movieController.Details(Search_Data) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
