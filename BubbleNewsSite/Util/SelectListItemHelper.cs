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
                new SelectListItem{Text = "IT Company", Value = "ITCompany"},
                new SelectListItem{Text = "Messenger", Value = "Messenger"},
                new SelectListItem{Text = "Social network", Value = "SocialNetwork"},
                new SelectListItem{Text = "Computer hardware", Value = "ComputerHardware"},
            };
            return items;
        }
    }
}
