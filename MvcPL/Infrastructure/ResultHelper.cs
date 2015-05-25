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
            try
            {
                string[] array = result.Split(new char[] { ';' });
                var newDateArray = array[0].Split(new char[] { '.', '-', ' ' })
                                    .Where(n => !String.IsNullOrEmpty(n)).ToArray();
                return new ResultsAddModel()
                {
                    AthleteName = array[4],
                    HorseName = array[5],
                    Place = Int32.Parse(array[3]),
                    Points = Double.Parse(array[6]),
                    CompetitionTitle = array[1],
                    CompetitionProgram = array[2],
                    DateBegin = new DateTime(int.Parse(newDateArray[4]), int.Parse(newDateArray[1]), int.Parse(newDateArray[0])),
                    DateEnd = new DateTime(int.Parse(newDateArray[4]), int.Parse(newDateArray[3]), int.Parse(newDateArray[2]))
                };
            }
            catch
            {
                return null;
            }
        }
    }
}