using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BubbleNewsSite.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Article")]
        [StringLength(160, MinimumLength = 1, ErrorMessage = "The length must be between 1 and 160 characters")]
        public string Article { get; set; }

        [Display(Name = "Desription")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "NewsType")]
        public string NewsType { get; set; }

        [Display(Name = "Img")]
        public string Img { get; set; } //Temporarily by reference 
        public DateTime DateCreateNews { get; set; }
        public string WhoCreated { get; set; }
        
        [Display(Name = "Hide news?")]
        public bool HideNews { get; set; }

        [Display(Name = "Is this the news of the week?")]
        public bool IsNewsWeek { get; set; }

        [Display(Name = "Is this the news of the day?")]
        public bool IsNewsDay { get; set; }

        public int CountViews { get; set; }
    }
}
