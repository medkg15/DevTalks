using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Model;
using MVC.ViewModels;

namespace MVC.Controllers
{
    public class EventController : Controller
    {
        private readonly EventQuery _eventQuery;
        private readonly EventListQuery _listQuery;
        private readonly IMapper _mapper;

        public EventController(EventQuery eventQuery, EventListQuery listQuery, IMapper mapper)
        {
            _eventQuery = eventQuery;
            _listQuery = listQuery;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var events = _listQuery.GetEvents();

            var model = new EventsViewModel
            {
                Events = events.Select(e => _mapper.Map<EventsViewModel.EventTeaserViewModel>(e)),
            };

            return View(model);
        }

        public IActionResult Detail(string id)
        {
            var @event = _eventQuery.GetEvent(id);

            var model = _mapper.Map<EventViewModel>(@event);

            return View(model);
        }
    }
}
