using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models;

namespace MvcPL.Infrastructure
{
    public static class ResultHelper
    {
        public static ResultsAddModel ParseAndWriteResultString(string result)
        {
            string[] array = result.Split(new char[] { ';' });
            string[] dateArray = array[0].Split(new char[] { '.', '-'});
            return new ResultsAddModel()
            {
                AthleteName = array[4],
                HorseName = array[5],
                Place = Int32.Parse(array[3]),
                Points = Double.Parse(array[6]),
                CompetitionTitle = array[1],
                CompetitionProgram = array[2],
                DateBegin = new DateTime(int.Parse(dateArray[5]), int.Parse(dateArray[1]), int.Parse(dateArray[0])),
                DateEnd = new DateTime(int.Parse(dateArray[5]), int.Parse(dateArray[4]), int.Parse(dateArray[3]))
            };
        }
    }
}