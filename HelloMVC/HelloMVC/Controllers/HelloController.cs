using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web;

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        /*public IActionResult Index(string name = "world")
        {
            //return Content("<h1>Hello world</h1>","text/HTML");
            if (string.IsNullOrEmpty(name))
            {
                name = "World";
            }
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/HTML");
        }
        */

        static public int visits = 0;
        static public string tempUser = "";
        static public int userID = 0;
        
        


        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
                "<input type='text' name='name' />" +
                "<input type='submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/HTML");
            //return Redirect("/Hello/Goodbye");
        }

        /*
         * public IActionResult Index()
        {
            string html = "<form method='post' action='/Hello/Display'>" +
                "<input type='text' name='name' />" +
                "<input type='submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/HTML");
        }
        */


        /*
         * //Hello/Goodbye
        // alter the route to this controller to be: /Hello/Aloha
        [Route("/Hello/Aloha")]
         public IActionResult Display(string name = "World")
        */

        //Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "World")
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/HTML");
        }


        //Handle requests to /Hello/NAME (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/HTML");
        }



        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }


        //GET: /<controller>/
        [Route("/Studio")]
        [HttpGet]
        
        public IActionResult Studio()
        {
            
            //string html = "<form method='post' action='/Hello/Greet'>" + 
            string html = "<form method='post' >" +
                "<input type='text' name='name' />" +
                "<select name='language'> " +
                "<option value = 'english' selected> English </option>"+
                "<option value = 'spanish' > Spanish </option>"+
                "<option value = 'french' > French </option>"+
                "<option value = 'portuguese' > Portuguese </option>" +
                "<option value = 'german' > German</option>"+
                "</select>"+
                "<input type='submit' value = 'Greet me!' />" +
                "</form>";
            return Content(html, "text/HTML");
            //return Redirect("/Hello/Goodbye");
        }

        //Hello
        [Route("/Studio")]
        [HttpPost]
        public IActionResult Greet(string language = "", string name = "")
        {
            
            int counter = 0;
            string userid;

            var cookieOptions = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true, //<- there
                //Expires = System.DateTime.Now.AddMonths(1),
            };

            if (Request.Cookies["userName"] != null)
            {
                Request.Cookies.TryGetValue("userName", out userid);
                Request.Cookies.TryGetValue("greet", out string greetCount);
                counter = int.Parse(greetCount) +1;
                Response.Cookies.Append("userName", userid, cookieOptions);
                Response.Cookies.Append("greet", counter.ToString(), cookieOptions);
            }
            else
            {
                counter = 1;
                userid = (++userID).ToString();
                Response.Cookies.Append("userName", userid, cookieOptions);
                Response.Cookies.Append("greet", counter.ToString(), cookieOptions);
            }

            visits = counter;
            tempUser = userid;

            return Content(CreateMessage2(language,name), "text/HTML");
        }


        public static string CreateMessage(string languaje, string name)
        {
            string newMessage = "";
            switch (languaje)
            {
                case "english":
                    newMessage = string.Format("<h1>Hello {0}</h1>", name);
                    break;
                case "spanish":
                    newMessage = string.Format("<h1>Hola {0}</h1>", name);
                    break;
                case "french":
                    newMessage = string.Format("<h1>Bonjour {0}</h1>", name);
                    break;
                case "portuguese":
                    newMessage = string.Format("<h1>Ol&#225 {0}</h1>", name);
                    break;
                case "german":
                    newMessage = string.Format("<h1>Hallo {0}</h1>", name);
                    break;
                default:
                    newMessage = "<h1>Default</h1>";
                    break;
            }
            
            return newMessage;
        }

        public static string CreateMessage2(string languaje, string name)
        {
            string newMessage = "";
            Dictionary<string, string> translator = new Dictionary<string, string>();
            translator.Add("english", "Hello");
            translator.Add("spanish", "Hola");
            translator.Add("french", "Bonjour");
            translator.Add("portuguese", "Ol&#225");
            translator.Add("german", "Hallo");

            newMessage = "<h1>" + translator[languaje] + " " + name + "</h1><br><h2> This is your visit number: " + visits + "</h2> (UserID: " + tempUser + ")";

            return newMessage;
        }

    }



    

}