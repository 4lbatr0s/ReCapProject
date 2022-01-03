
namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    { 
        T Data {get;}

        //this value type will return data too.

    }

}
