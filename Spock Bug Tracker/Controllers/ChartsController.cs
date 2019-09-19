using Spock_Bug_Tracker.Models;
using Spock_Bug_Tracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spock_Bug_Tracker.Controllers
{
    public class ChartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public JsonResult GetRealMorrisData()
        {
            var dataSet = new List<MorrisBarChartData>();
            foreach(var ticketStatus in db.TicketStatuses.ToList())
            {
                var value = db.TicketStatuses.Find(ticketStatus.Id).Tickets.Count();
                dataSet.Add(new MorrisBarChartData { label = ticketStatus.Name, value = value });
            }

            return Json(dataSet);
        }
        public JsonResult GetRealFusionByType()
        {
            var dataSet = new List<FusionPieChartData>();
            foreach (var ticketTypes in db.TicketTypes.ToList())
            {
                var value = db.TicketTypes.Find(ticketTypes.Id).Tickets.Count();
                dataSet.Add(new FusionPieChartData { label = ticketTypes.Name, value = value.ToString() });
            }

            return Json(dataSet);
        }
    }
}