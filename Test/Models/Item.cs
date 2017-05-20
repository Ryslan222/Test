﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool IsComplate { get; set; }
        public DateTime FirstData { get; set; }
        public DateTime LastData { get; set; }
        public int rating { get; set; }
        public virtual ICollection<SubTask> Subtasks { get; set; } = new HashSet<SubTask>();



    }
}