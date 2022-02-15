using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string text):base(data, true,text)
        {}

        public SuccessDataResult(T data):base(data, true)
        {}

        public SuccessDataResult(string text) : base(default, false, text)
        {}

        public SuccessDataResult() : base(default, true)
        {}
    }
}
