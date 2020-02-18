using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace MVC.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<EventTeaserViewModel> Events { get; set; }

        public class EventTeaserViewModel
        {
            public string Title { get; set; }
            public string Location { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public HtmlString Teaser { get; set; }
        }
    }
}
