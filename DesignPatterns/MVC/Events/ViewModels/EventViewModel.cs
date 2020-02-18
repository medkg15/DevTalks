using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace MVC.ViewModels
{
    public class EventViewModel
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public HtmlString Description { get; set; }
        public bool HasRegistration { get; set; }
        public decimal RegistrationCost { get; set; }
        public string RegistrationUrl { get; set; }
    }
}
