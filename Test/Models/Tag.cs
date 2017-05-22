using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string name { get; set; }
        public virtual ICollection<Item> Item { get; set; } = new HashSet<Item>();
    }
}