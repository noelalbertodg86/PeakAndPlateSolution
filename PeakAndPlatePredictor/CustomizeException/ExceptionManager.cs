using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeakAndPlatePredictor.CustomizeException
{
    public class EmptyPlateNumberException : Exception
    {
        public EmptyPlateNumberException() : base("The plate number is empty.")
        {
        }

        public EmptyPlateNumberException(string message) : base(message)
        {
        }
    }

    public class DateBadFormatException : Exception
    {
        public DateBadFormatException() : base("The entry date format is incorrect")
        {
        }

        public DateBadFormatException(string message) : base(message)
        {
        }
    }

}