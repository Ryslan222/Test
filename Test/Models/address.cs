using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class address

    {
        public int Id { get; set; }
        public string addres { get; set; }
        public virtual Item item { get; set; }
        public int itemId { get; set; }
    }
}