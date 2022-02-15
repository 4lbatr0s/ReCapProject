using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message):base(false) //just pass the string value, and send true to the base class Result, it's an IResult
        {
            
        }

        public ErrorResult():base(false)
        {
            
        }
    }
}
