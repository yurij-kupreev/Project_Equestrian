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
            var model = athleteService.GetAllAthleteEntities(0, null)
                .Select(athlete => athlete.ToAthleteView());
            ViewBag.NumOfPage = 0;
            ViewBag.Name = null;
            return View(model);
        }

        [Authorize]
        public ActionResult AthletesListPartial(int? pageNum, string predicate)
        {
            if (pageNum == null || pageNum.Value < 0)
                return HttpNotFound();
            var model = athleteService.GetAllAthleteEntities(pageNum.Value, predicate)
                .Select(athlete => athlete.ToAthleteView());
            if (model == null || model.Count() == 0) return HttpNotFound();
            ViewBag.NumOfPage = pageNum.Value;
            ViewBag.Name = predicate;
            return PartialView("AthletesPartial", model);
        }

        [Authorize]
        public ActionResult CompetitionList()
        {
            var model = competitionService.GetAllCompetitionEntities(0)
                .Select(competition => competition.ToCompetitionView());
            ViewBag.NumOfPage = 0;
            return View(model);
        }

        [Authorize]
        public ActionResult CompetitionsListPartial(int? pageNum)
        {
            if (pageNum == null || pageNum.Value < 0)
                return HttpNotFound();
            var model = competitionService.GetAllCompetitionEntities(pageNum.Value)
                .Select(competition => competition.ToCompetitionView());
            if (model == null || model.Count() == 0) return HttpNotFound();
            ViewBag.NumOfPage = pageNum.Value;
            return PartialView("CompetitionsPartial", model);
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
                return PartialView("ResultsListPartial", model);
            }
        }

        [Authorize]
        public ActionResult AthleteSearch(string predicate)
        {
            var athletes = athleteService.GetAllAthleteEntities(0, predicate).Select(item => item.ToAthleteView());
            ViewBag.NumOfPage = 0;
            ViewBag.Name = predicate;
            return View("AthleteList", athletes);
        }
    }
}