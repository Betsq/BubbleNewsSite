using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BubbleNewsSite.Util
{
    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetNewsType()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Phone", Value = "Phone"},
                new SelectListItem{Text = "PC", Value = "PC"},
                new SelectListItem{Text = "Laptop", Value = "Laptop"},
                new SelectListItem{Text = "IT Company", Value = "IT Company"},
                new SelectListItem{Text = "Messenger", Value = "Messenger"},
                new SelectListItem{Text = "Social network", Value = "Social network"},
                new SelectListItem{Text = "Computer hardware", Value = "Computer hardware"},
            };
            return items;
        }
    }
}
