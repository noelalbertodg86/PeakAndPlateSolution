using System;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using PeakAndPlatePredictor.Models;
using PeakAndPlatePredictor.Business;
using PeakAndPlatePredictor.CustomizeException;

namespace PeakAndPlatePredictor.Controllers
{
    public class PredictorController : ApiController
    {

        /// <summary>
        ///  this function will return whether or not that car can be on the road
        /// </summary>
        /// <param name="plateNumber"></param>
        /// <param name="strTargetDate" value="27/06/2019"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/PeakAndPlate/check")]
        public async Task<string> Check(InputModel inputData)
        {
            ResponseModel responseMessage = new ResponseModel();
            try
            {
                #region validate input data
                if (String.IsNullOrEmpty(inputData.plateValue))
                {
                    throw new EmptyPlateNumberException();
                }

                DateTime targetDateTemp;
                if (DateTime.TryParse(inputData.strTargetDate, out targetDateTemp))
                {
                    inputData.targetDate = targetDateTemp;
                }
                else
                {
                    throw new DateBadFormatException();
                }

                #endregion validate input data

                //Initialize the field because it applies in this case, if necessary another rule 
                //can be created by inheriting from the interfaces and changing cases
                IPeakAndPlateRules lastNumberRule = new LastNumberRule();

                //Case of public transport
                if (lastNumberRule.IsExoneratedPlate(inputData.plateValue))
                {
                    responseMessage.ReturnCode = "0";
                    responseMessage.ReturnMessage = "Your registration is exempt from peak and plate";
                    return JsonConvert.SerializeObject(responseMessage);
                }

                //Validate the peak and plate rule
                if (lastNumberRule.IsAllow(inputData.plateValue, inputData.targetDate, inputData.targetTime))
                {
                    responseMessage.ReturnCode = "0";
                    responseMessage.ReturnMessage = "Congratulations, you can be on the road";
                    return JsonConvert.SerializeObject(responseMessage);
                }
                else
                {
                    responseMessage.ReturnCode = "0";
                    responseMessage.ReturnMessage = "Sorry, you are on a restricted schedule.";
                    return JsonConvert.SerializeObject(responseMessage);
                }

            }
            catch (Exception e)
            {
                string error = e.Message;
                responseMessage.ReturnCode = "9999";
                responseMessage.ReturnMessage = error;
                return JsonConvert.SerializeObject(responseMessage);
            }


        }
    }
}
