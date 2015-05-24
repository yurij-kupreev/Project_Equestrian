using System.Linq;
using System.Web.Mvc;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Models;
using MvcPL.Infrastructure;
using System;
using System.Web;
using System.IO;
using System.Configuration;

namespace MvcPL.Controllers
{
    [CustomExceptionFilter]
    public class HomeController : Controller
    {
        private readonly IResultService resultService;
        private readonly IAthleteService athleteService;
        private readonly ICompetitionService competitionService;
        public HomeController(IResultService resultService, IAthleteService athleteService, ICompetitionService competitionService)
        {
            this.resultService = resultService;
            this.athleteService = athleteService;
            this.competitionService = competitionService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AthleteList()
        {
            var model = athleteService.GetAllAthleteEntities()
                .Select(athlete => athlete.ToAthleteView());
            return View(model);
        }

        [Authorize]
        public ActionResult CompetitionList()
        {
            var model = competitionService.GetAllCompetitionEntities()
                .Select(competition => competition.ToCompetitionView());
            return View(model);
        }

        [Authorize]
        public ActionResult AthleteResultsPartial(int? athleteKey)
        {
            if (athleteKey == null)
            {
                return HttpNotFound();
            }
            else
            {
                var model = resultService.GetAtheleteResults(athleteKey.Value)
                             .Select(result => result.ToResultView());
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        public ActionResult CompetitionResultsPartial(int? competitionKey)
        {
            if (competitionKey == null)
            {
                return HttpNotFound();
            }
            else
            {
                var model = resultService.GetCompetitionResults(competitionKey.Value)
                           .Select(result => result.ToResultView());
                ViewBag.ViewTitle = model.First().CompetitionProgram;
                return PartialView("ResultsPartial", model);
            }
        }
    }
}