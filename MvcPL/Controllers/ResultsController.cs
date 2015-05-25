using BLL.Interface.Entities;
using BLL.Interface.Services;
using MvcPL.Infrastructure;
using MvcPL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPL.Controllers
{
    [CustomExceptionFilter]
    [Authorize(Roles = "admin")]
    public class ResultsController : Controller
    {
        private readonly IResultService resultService;
        private readonly IAthleteService athleteService;
        private readonly ICompetitionService competitionService;
        public ResultsController(IResultService resultService, IAthleteService athleteService, ICompetitionService competitionService)
        {
            this.resultService = resultService;
            this.athleteService = athleteService;
            this.competitionService = competitionService;
        }

        public ActionResult ResultList()
        {
            return View(resultService.GetAllResultEntities()
                .Select(result => result.ToResultView()));
        }

        [HttpGet]
        public ActionResult AddResults()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResults(HttpPostedFileBase file)
        {
            String destinationPath = Server.MapPath("~/Uploads");
            String fileName = file.FileName;
            String path = Path.Combine(destinationPath, fileName);
            file.SaveAs(path);
            ResultsAddModel newResult = null;
            string fileFormat = ConfigurationManager.AppSettings["FileFormat"];
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string data = sr.ReadLine();
                    if (data != fileFormat)
                    {
                        newResult = ResultHelper.ParseAndWriteResultString(data);
                        if (newResult != null)
                            if (newResult.DateEnd >= newResult.DateBegin)
                                resultService.CreateResult(newResult.ToResultEntity(),
                                           newResult.ToAthleteEntity(), newResult.ToCompetitionEntity());
                    }
                }
            }

            return RedirectToAction("ResultList");
        }

        [HttpGet]
        public ActionResult EditResult(int? index)
        {
            if (index == null)
            {
                return HttpNotFound();
            }
            var result = resultService.GetResultById(index.Value);
            var competition = competitionService.GetCompetitionById(result.CompetitionId);
            var athlete = athleteService.GetAthleteById(result.AthleteId);
            ViewBag.ResultId = result.Id;
            ViewBag.AthleteId = athlete.Id;
            ViewBag.CompetitionId = competition.Id;
            ViewBag.Action = "Edit";
            return View("AddResult", new ResultsAddModel()
                {
                    AthleteName = athlete.AthleteName,
                    HorseName = athlete.HorseName,
                    Place = result.Place,
                    Points = result.Points,
                    CompetitionTitle = competition.Title,
                    CompetitionProgram = competition.Program,
                    DateBegin = competition.DateBegin,
                    DateEnd = competition.DateEnd,
                });
        }
        [HttpPost]
        public ActionResult EditResult(ResultsAddModel changedResult, int resultId,
            int athleteId, int competitionId)
        {
            resultService.EditResult(changedResult.ToResultEntity(resultId));
            athleteService.EditAthlete(changedResult.ToAthleteEntity(athleteId));
            competitionService.EditCompetition(changedResult.ToCompetitionEntity(competitionId));
            return RedirectToAction("ResultList");
        }

        [HttpGet]
        public ActionResult AddResult()
        {
            ViewBag.Action = "Add";
            return View();
        }

        [HttpPost]
        public ActionResult AddResult(ResultsAddModel newResult)
        {
            if (newResult.DateEnd >= newResult.DateBegin)
                resultService.CreateResult(newResult.ToResultEntity(), newResult.ToAthleteEntity(),
                    newResult.ToCompetitionEntity());
            return RedirectToAction("ResultList");
        }

        [HttpGet]
        public ActionResult DeleteResult(int index)
        {
            ViewBag.Index = index;
            return View("ConfirmAction");
        }

        [HttpPost]
        public ActionResult DeleteResult(int? index)
        {
            if (index == null)
            {
                return HttpNotFound();
            }
            resultService.DeleteResult(index.Value);
            return RedirectToAction("ResultList");
        }

        [HttpGet]
        public ActionResult DeleteAllResults(int? index)
        {
            return View("ConfirmAction");
        }

        [HttpPost]
        public ActionResult DeleteAllResults()
        {
            resultService.DeleteAllResults();
            return RedirectToAction("ResultList");
        }
    }
}
