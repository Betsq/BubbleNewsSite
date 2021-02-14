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
                new SelectListItem{Text = "IT", Value = "IT"},
                new SelectListItem{Text = "Messenger", Value = "Messenger"},
                new SelectListItem{Text = "Social network", Value = "Social Network"},
                new SelectListItem{Text = "Computer hardware", Value = "Computer Hardware"},
            };
            return items;
        }

        public static IEnumerable<SelectListItem> Gender()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "Male", Value = "Male"},
                new SelectListItem{Text = "Female", Value = "Female"},
            };
            return items;
        }
    }
}
