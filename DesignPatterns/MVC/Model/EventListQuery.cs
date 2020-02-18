using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Model
{
    public class EventListQuery
    {
        public IEnumerable<Event> GetEvents()
        {
            return new []
            {
                new Event(),
                new Event(),
                new Event(),
            };
        }
    }
}
