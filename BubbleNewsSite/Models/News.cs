using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleNewsSite.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public string NewsType { get; set; }
        public string Img { get; set; } //Temporarily by reference  
    }
}
