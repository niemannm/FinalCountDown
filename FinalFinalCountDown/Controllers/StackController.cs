﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalFinalCountDown.Controllers
{
    public class StackController : Controller
    {
        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        //declare vars
        static Stack<string> myStack = new Stack<string>();
        int iStackCount = 0;

        //method for adding to stack
        public ActionResult addToStack()
        {
            myStack.Push("New Entry " + (myStack.Count + 1) + " ");

            return View("Index");
        }

        //method for adding huge list of 2000 items to stack
        public ActionResult addListToStack()
        {
            myStack.Clear();

            for (iStackCount = 1; iStackCount < 2001; iStackCount++)
            {
                myStack.Push("\nNew Entry " + iStackCount + " \t");
            }

            return View("Index");
        }

        //method to display the stack for the user to see.
        public ActionResult displayStack()
        {
            foreach (string s in myStack)
            {
                ViewBag.displayStack += s;
            }
            return View("Index");

        }

        //method to delete an item from the stack
        public ActionResult deleteFromStack()
        {
            myStack.Pop();

            return View("Index");

        }

        //method to clear the stack
        public ActionResult clearStack()
        {
            myStack.Clear();

            return View("Index");
        }

        public ActionResult searchStack()
        {
            System.Diagnostics.Stopwatch timeMe = new System.Diagnostics.Stopwatch();

            timeMe.Start();

            bool isFound = false;
            foreach (string s in myStack)
            {
                if (s == "New Entry 12 ")
                {
                    ViewBag.isFound = "The number twelve was found in the stack. It took:";
                    isFound = true;
                }
            }

            timeMe.Stop();

            if (isFound == false)
            {
                ViewBag.isFound = "The number twelve was not found in the stack. We searched for:";
            }

            TimeSpan ts = timeMe.Elapsed;

            ViewBag.time = ts + " seconds";
            return View("Index");

        }
    }
}
