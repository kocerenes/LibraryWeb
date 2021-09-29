using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryWeb.Models.Classes
{
    public class Enumerable_
    {
        public IEnumerable<Books> bookValues { get; set; }
        public IEnumerable<AboutUs> aboutUsValues { get; set; }
    }
}