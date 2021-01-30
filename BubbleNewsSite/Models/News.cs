﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleNewsSite.Models
{
    public class News
    {
        public int Id { get; set; }
        [Display(Name = "Article")]
        public string Article { get; set; }
        [Display(Name = "Desription")]
        public string Description { get; set; }
        [Display(Name = "NewsType")]
        public string NewsType { get; set; }
        [Display(Name = "Img")]
        public string Img { get; set; } //Temporarily by reference  
    }
}
