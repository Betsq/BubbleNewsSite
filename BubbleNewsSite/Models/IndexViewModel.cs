using BubbleNewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleNewsSite.Models
{
    public class IndexViewModel
    {
        public IEnumerable<News> News { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
