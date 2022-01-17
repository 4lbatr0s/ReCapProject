using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {

        public SuccessResult(string message):base(true) //create string and send true to the base class which is Result
        {

        }


        public SuccessResult() :base(true)
        {

        }
    }
}
