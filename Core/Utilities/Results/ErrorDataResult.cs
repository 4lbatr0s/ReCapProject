using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string text):base(data, false, text)
        {

        }

        public ErrorDataResult(T data):base(data, false)
        {

        }

        public ErrorDataResult(string text):base(default, false, text)
        {

        }

        public ErrorDataResult():base(default,false)
        {
                
        }
    }
}
