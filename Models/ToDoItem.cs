﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace To_Do__MVC.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime DateAdded { get; set; }
    }
}