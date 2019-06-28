using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PeakAndPlatePredictor.Business
{
    /// <summary>
    /// interface class to allow to inherit and create several peak and plate mechanisms
    /// </summary>
    interface IPeakAndPlateRules
    {
        bool IsAllow(string plateFullNumber, DateTime targetDate, TimeSpan targetTime);

        bool IsExoneratedPlate(string plateFullNumber);
    }
}
