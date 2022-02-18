
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get;}

        public  Result(bool success, string message):this(success) //return success value with the message.
        {
            Message = message;
        }

        public Result(bool success) //without any messages.
        {
            Success = success;
        }
    }

}
