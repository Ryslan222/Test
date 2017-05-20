using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public virtual Item Item { get; set; }
        public string name { get; set; }             
        public int order { get; set; }
        public int ItemId { get; set; }



    }
}