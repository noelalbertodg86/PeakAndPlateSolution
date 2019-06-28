using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeakAndPlatePredictor.Models;

namespace PeakAndPlatePredictor.Business
{
    public class LastNumberRule: IPeakAndPlateRules
    {

        PeakAndPlatePredictorEntities2 peakAndPlatePredictorEntities;


        public LastNumberRule()
        {
            peakAndPlatePredictorEntities = new PeakAndPlatePredictorEntities2();
        }

        /// <summary>
        ///  this function will return whether or not that car can be on the road by the rule of last digit 
        /// </summary>
        /// <param name="plateFullNumber" value="full plate value"></param>
        ///  <param name="targetDate" value="date for the search"</param>
        ///  <param name="targetTime" value="time  for the search"</param>
        /// <returns>if the plate is allow to road</returns>
        public bool IsAllow(string plateFullNumber, DateTime targetDate, TimeSpan targetTime)
        {
            char lastPlateDigit = plateFullNumber[plateFullNumber.Length - 1];
            int targetWeekDay = (int)targetDate.DayOfWeek;
            List<PeakAndPlateManager> peakAndPlateManager = peakAndPlatePredictorEntities.PeakAndPlateManagers.Where(p => p.LastPlateDigit == lastPlateDigit
                                                                                                                    && p.RestrictionRule.DateRule.WeekDay == targetWeekDay
                                                                                                                    && p.RestrictionRule.TimeInterval.StartTime <= targetTime
                                                                                                                    && p.RestrictionRule.TimeInterval.EndTime >= targetTime).ToList();
            return (peakAndPlateManager.Count > 0) ? false : true;

        }

        /// <summary>
        ///  this function will return if the plate are exonerated from peask and plate
        /// </summary>
        /// <param name="plateFullNumber" value="full plate value"></param>
        /// <returns>true or false</returns>
        public bool IsExoneratedPlate(string plateFullNumber)
        {
            List<ExceptionPlate> exceptionPlates = peakAndPlatePredictorEntities.ExceptionPlates.Where(p => p.PlateValue == plateFullNumber).ToList();
            return (exceptionPlates.Count > 0) ? true:false;
        }
    }
}