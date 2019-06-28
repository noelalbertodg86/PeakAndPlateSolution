using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeakAndPlatePredictor.Models
{
    /// <summary>
    /// model for data entry from requests
    /// </summary>
    public class InputModel
    {
        public string plateValue { get; set; }
        public DateTime targetDate { get; set; }

        public TimeSpan targetTime { get; set; }

        public string strTargetDate { get; set; }

        public InputModel()
        {
            
        }

    }
}