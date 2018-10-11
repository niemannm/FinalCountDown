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

        // GET: Dictionary
        public ActionResult Index()
        {
            ViewBag.MyDictionary = dUserDictionary;
            ViewBag.display = isDisplay;
            return View();
        }
        public ActionResult AddOne()
        {
            isDisplay = "AddOne";
            ViewBag.display = isDisplay;
            myKey = "Entry #" + myCount.ToString();
            dUserDictionary.Add(myKey, myCount);
            ViewBag.MyDictionary = dUserDictionary;
            ++myCount;
            return View("Index");
        }
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
        public ActionResult Display()
        {
            isDisplay = "Display";
            ViewBag.display = isDisplay;
            ViewBag.MyDictionary = dUserDictionary;
            return View("Index");
        }
        public ActionResult Delete()
        {
            isDisplay = "Delete";
            ViewBag.display = isDisplay;


            return View("Index");
        }

        public ActionResult Clear()
        {
            isDisplay = "Clear";
            ViewBag.display = isDisplay;

            dUserDictionary.Clear();
            return View("Index");
        }
        public ActionResult Search()
        {
            isDisplay = "Search";
            ViewBag.display = isDisplay;
            String searchValue = "New Entry #1";
            foreach (var item in dUserDictionary)
            {
                if (item.Key == searchValue)
                {
                    ViewBag.SearchItem = item;
                }
            }


            return View("Index");
        }
    }
}