using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFinalCountDown.Controllers
{
    public class DictionaryController : Controller
    {
        public static Dictionary<String, int> dUserDictionary = new Dictionary<string, int>();
        public static int myCount = 1;
        public static String myKey = "";
        public static String isDisplay = "";
        public static String message = "";

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = dUserDictionary;
            ViewBag.display = isDisplay;
            ViewBag.message = message;
            return View();
        }
        //Add one item to the dictionary
        public ActionResult AddOne()
        {
            isDisplay = "AddOne";
            ViewBag.display = isDisplay;
            myKey = "New Entry #" + myCount.ToString();
            dUserDictionary.Add(myKey, myCount);
            ViewBag.MyDictionary = dUserDictionary;
            ++myCount;
            return View("Index");
        }
        //Adds 2000 items to the dictionary
        public ActionResult AddMany()
        {
            isDisplay = "AddMany";
            ViewBag.display = isDisplay;
            dUserDictionary.Clear();
            myCount = 1;
            int i = 0;
            while (i < 2000)
            {
                myKey = "New Entry #" + myCount.ToString();
                dUserDictionary.Add(myKey, myCount);
                ViewBag.MyDictionary = dUserDictionary;
                ++myCount;
                ++i;
            }
            return View("Index");
        }
        //Displays the dictionary - Used alongside razor code in the view
        public ActionResult Display()
        {
            isDisplay = "Display";
            ViewBag.display = isDisplay;
            ViewBag.MyDictionary = dUserDictionary;
            return View("Index");
        }
        //Searches for "New Entry #6" in the dictionary and deletes it
        public ActionResult Delete()
        {
            isDisplay = "Delete";
            ViewBag.display = isDisplay;
            String itemToDelete = "New Entry #6";
            bool exists = false;
            int Value = 0;
            String key = "";

            foreach (var item in dUserDictionary)
            {
                if (item.Key == itemToDelete)
                {
                    exists = true;

                    Value = item.Value;
                    key = item.Key;
                }
            }
            if (exists)
            {
                dUserDictionary.Remove(key);
                //Sends a message if it was found
                message = itemToDelete + " and its associated value was deleted.";
                ViewBag.message = message;
                
            }
            else
            {
                //sends a message if it was not found
                message = itemToDelete + " could not be deleted because it was not found";
                ViewBag.message = message;
            }

            return View("Index");
        }

        //Clears everything from the dictionary and resets the count
        public ActionResult Clear()
        {
            isDisplay = "Clear";
            ViewBag.display = isDisplay;
            myCount = 1;


            dUserDictionary.Clear();
            return View("Index");
        }
        //Searches for an item in the dictionary and sends the result + the time required to search to the view
        public ActionResult Search()
        {
            isDisplay = "Search";
            ViewBag.display = isDisplay;
            String searchValue = "New Entry #2";
            bool exists = false;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            int Value = 0;
            sw.Start();
            foreach (var item in dUserDictionary)
            {
                if (item.Key == searchValue)
                {
                    exists = true;
                    
                    Value = item.Value;
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            if (exists)
            {
                message = searchValue + " was found in the dictionary. The value associated with the key is: " + Value.ToString() + "<br> It took " + sw.Elapsed + " to search the dictionary";
                ViewBag.message = message;
            }
            else
            {
                message = searchValue + " was not found as a key in this dictionary" + "<br> It took " + sw.Elapsed + " to search the dictionary";
                ViewBag.message = message;
            }
                     
            


            return View("Index");
        }
    }
}