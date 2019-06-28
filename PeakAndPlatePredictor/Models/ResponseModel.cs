using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeakAndPlatePredictor.Models
{
    /// <summary>
    /// Response structure for response to request
    /// </summary>
    /// <returns></returns>
    public class ResponseModel
    {
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        public ResponseModel()
        {
            ReturnCode = string.Empty;
            ReturnMessage = string.Empty;
        }

        public ResponseModel(string CodigoParam, string MensajeRetornoParam)
        {
            ReturnCode = CodigoParam;
            ReturnMessage = MensajeRetornoParam;
        }
    }
}